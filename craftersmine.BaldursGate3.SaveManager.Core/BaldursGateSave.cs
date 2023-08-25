using System;
using System.Collections.Generic;
using System.Text.Json;
using LSLib;
using LSLib.LS;

namespace craftersmine.BaldursGate3.SaveManager.Core
{
    public class BaldursGateSave
    {
        private Package package;

        public string FullPath { get; }
        public SaveInformation SaveInformation { get; }
        public string ScreenshotPath { get; }
        public string LeaderName { get; }
        public DateTime LastModified { get; }

        public BaldursGateSave(string fullPath)
        {
            if (!File.Exists(fullPath))
                throw new FileNotFoundException("Save file not found in the specified location!", fullPath);

            if (!Path.GetExtension(fullPath).Contains("lsv"))
                throw new InvalidFormatException("File doesn't appear as an LSV package!");

            FullPath = fullPath;
            using (PackageReader reader = new PackageReader(FullPath))
            {
                package = reader.Read();

                AbstractFileInfo? fileInfo = package.Files.FirstOrDefault(p => p.Name.ToLowerInvariant() == "saveinfo.json");

                if (fileInfo is null)
                    throw new InvalidFormatException("File missing SaveInfo.json. Probably not a saved game!");

                using (Stream fileStream = package.Files
                           .FirstOrDefault(p => p.Name.ToLowerInvariant() == "saveinfo.json")!.MakeStream())
                    SaveInformation = JsonSerializer.Deserialize<SaveInformation>(fileStream)!;

                LastModified = File.GetLastWriteTimeUtc(FullPath);
                
                ScreenshotPath = Path.ChangeExtension(FullPath, "webp");

                AbstractFileInfo? meta = package.Files.FirstOrDefault(p => p.Name.ToLowerInvariant() == "meta.lsf");
                if (fileInfo is null)
                    throw new InvalidFormatException("File missing meta.lsf. Probably not a saved game!");

                using (LSFReader metaReader = new LSFReader(meta.MakeStream()))
                {
                    Resource res = metaReader.Read();
                    LeaderName = res.Regions["MetaData"].Children["MetaData"][0].Attributes["LeaderName"].ToString();
                }
            }
        }

        public override string ToString()
        {
            return LeaderName + " - " + SaveInformation.Name;
        }

        public void Delete()
        {
            Directory.Delete(Path.GetDirectoryName(FullPath), true);
        }
    }
}
