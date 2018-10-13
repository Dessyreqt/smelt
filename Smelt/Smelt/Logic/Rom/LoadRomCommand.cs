namespace Smelt.Logic.Rom
{
    using System;
    using System.IO;
    using System.Linq;
    using Data;

    public class LoadRomCommand : Command
    {
        private readonly string filename;

        public LoadRomCommand(AppState appState, string filename) : base(appState)
        {
            this.filename = filename;
        }

        protected override void Handle()
        {
            CheckFileSize();

            var rom = new Rom();
            var rawData = File.ReadAllBytes(filename);

            rom.RawData = RemoveSmcHeader(rawData);

            AppState.Rom = rom;
            Run(new GetRomInfoCommand(AppState));
        }

        private void CheckFileSize()
        {
            var fileInfo = new FileInfo(filename);
            
            if (fileInfo.Length < 0x8000)
            {
                throw new LoadRomException("Rom file is too small.");
            }

            // max length 0x1000000, file might include SMC header (length 0x200)
            if (fileInfo.Length > 0x1000200)
            {
                throw new LoadRomException("Rom file is too large.");
            }
        }

        private byte[] RemoveSmcHeader(byte[] rawData)
        {
            var headerSize = rawData.Length % 1024;

            if (headerSize != 0 && headerSize != 512)
            {
                throw new LoadRomException("Rom has a malformed SMC header.");
            }

            if (headerSize == 512)
            {
                return rawData.Skip(512).ToArray();
            }

            return rawData;
        }
    }

    public class LoadRomException : Exception
    {
        public LoadRomException(string message) : base(message)
        {
        }
    }
}
