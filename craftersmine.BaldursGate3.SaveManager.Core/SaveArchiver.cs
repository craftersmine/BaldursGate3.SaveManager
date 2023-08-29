using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.BaldursGate3.SaveManager.Core
{
    public class SaveArchiver : IDisposable
    {
        private CancellationTokenSource _cancellationTokenSource;
        private FileStream _stream;
        private ZipArchive _archive;
        private BaldursGateSave[] _saves;
        private int _processed = 0;
        private int _total = 0;

        public event EventHandler<ArchivingStatusEventArgs> OnArchivingStatusChanged;
        public event EventHandler<ArchivingCompletedEventArgs> OnArchiveCreated;
        public string OutputFile { get; init; }

        public SaveArchiver(BaldursGateSave[] saves, string outputFile)
        {
            if (saves is null || !saves.Any())
                throw new ArgumentNullException(nameof(saves), "No saves provided!");

            _saves = saves;

            if (!Directory.Exists(Path.GetDirectoryName(outputFile)))
                throw new DirectoryNotFoundException("Unable to find part of specified path \"" + outputFile + "\"");

            OutputFile = outputFile;
            if (File.Exists(OutputFile))
                File.Delete(OutputFile);

            _cancellationTokenSource = new CancellationTokenSource();

            _stream = File.Open(outputFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            _archive = new ZipArchive(_stream, ZipArchiveMode.Update, false);
        }

        public async Task CreateArchiveAsync()
        {
            try
            {
                await Task.Run(() =>
                {
                    _total = _saves.Length;
                    foreach (var save in _saves)
                    {
                        OnArchivingStatusChanged?.Invoke(this, new ArchivingStatusEventArgs(save, _total, _processed));
                        _archive.CreateEntryFromDirectory(save.SaveRoot, Path.GetFileName(save.SaveRoot));
                        _processed++;
                        if (_cancellationTokenSource.IsCancellationRequested)
                            break;
                    }

                    OnArchiveCreated?.Invoke(this, new ArchivingCompletedEventArgs(false));
                }, _cancellationTokenSource.Token);
            }
            catch (Exception e)
            {
                if (e is TaskCanceledException)
                    OnArchiveCreated?.Invoke(this, new ArchivingCompletedEventArgs(true));
            }
        }

        public void Cancel()
        {
            _cancellationTokenSource.Cancel();
        }

        public void Dispose()
        {
            _archive.Dispose();
            _stream.Dispose();
        }
    }

    public class ArchivingStatusEventArgs : EventArgs
    {
        public BaldursGateSave Save { get; }
        public int Processed { get; }
        public int Total { get; }

        public ArchivingStatusEventArgs(BaldursGateSave save, int total, int processed)
        {
            Save = save;
            Processed = processed;
            Total = total;
        }
    }

    public class ArchivingCompletedEventArgs : EventArgs
    {
        public bool IsCancelled { get; }

        public ArchivingCompletedEventArgs(bool isCancelled)
        {
            IsCancelled = isCancelled;
        }
    }
}
