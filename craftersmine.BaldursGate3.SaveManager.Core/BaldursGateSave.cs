using System;
using System.Collections.Generic;
using LSLib;
using LSLib.LS;

namespace craftersmine.BaldursGate3.SaveManager.Core
{
    public class BaldursGateSave
    {
        private Package package;

        public string FullPath { get; }

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

                Json package.Files.FirstOrDefault(p => p.Name.ToLowerInvariant() == "saveinfo.json").MakeStream()
            }
        }
    }
}
