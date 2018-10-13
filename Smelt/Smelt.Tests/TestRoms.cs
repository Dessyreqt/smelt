namespace Smelt.Tests
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;

    public sealed class TestRoms
    {
        private static readonly TestRoms instance = new TestRoms();

        static TestRoms()
        {
        }

        private TestRoms()
        {
            LoadWhitelist();
        }

        private void LoadWhitelist()
        {
            if (!File.Exists(whitelistFile))
            {
                return;
            }

            using (var reader = new StreamReader(whitelistFile))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        whitelist.Add(line);
                    }
                }
            }
        }

        private void SaveWhitelist()
        {
            using (var writer = new StreamWriter(whitelistFile, false))
            {
                foreach (var rom in whitelist)
                {
                    writer.WriteLine(rom);
                }
            }
        }

        private void AddRom(string romFilename)
        {
            if (!instance.whitelist.Contains(romFilename))
            {
                whitelist.Add(romFilename);
                SaveWhitelist();
            }
        }

        private readonly string whitelistFile = "whitelist.txt";
        private readonly List<string> whitelist = new List<string>();

        public static void Clear()
        {
            ClearFiles("*.sfc");
            ClearFiles("*.smc");
            ClearFiles("*.swc");
            ClearFiles("*.fig");
        }

        private static void ClearFiles(string pattern)
        {
            foreach (var filename in Directory.GetFiles(".\\", pattern))
            {
                if (!instance.whitelist.Contains(Path.GetFileName(filename)))
                {
                    File.Delete(filename);
                }
            }
        }

        public static void Include(string romFilename)
        {
            if (File.Exists($".\\{romFilename}"))
            {
                instance.AddRom(romFilename);

                return;
            }

            var romSources = ConfigurationManager.AppSettings["RomSources"].Split(';');

            foreach (var directory in romSources)
            {
                var foundFiles = Directory.GetFiles(directory, romFilename);

                if (foundFiles.Length == 0)
                {
                    continue;
                }

                instance.AddRom(romFilename);
                File.Copy(foundFiles[0], $".\\{romFilename}");

                return;
            }
        }
    }
}
