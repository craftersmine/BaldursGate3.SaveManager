using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.BaldursGate3.SaveManager.Core
{
    internal static class ZipArchiveExtensions
    {
        public static void CreateEntryFromAny(this ZipArchive archive, string sourcePath, string entryName = "")
        {
            string fileName = Path.GetFileName(sourcePath);
            if (File.GetAttributes(sourcePath).HasFlag(FileAttributes.Directory))
                archive.CreateEntryFromDirectory(sourcePath, Path.Combine(entryName, fileName));
            else
                archive.CreateEntryFromFile(sourcePath, Path.Combine(entryName, fileName),
                    CompressionLevel.SmallestSize);
        }

        public static void CreateEntryFromDirectory(this ZipArchive archive, string sourceDirPath,
            string entryName = "")
        {
            string[] files = Directory.GetFiles(sourceDirPath).Concat(Directory.GetDirectories(sourceDirPath)).ToArray();

            foreach (string file in files)
                archive.CreateEntryFromAny(file, entryName);
        }
    }
}
