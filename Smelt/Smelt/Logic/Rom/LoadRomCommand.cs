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
            CheckFileSize(filename);

            var rom = new Rom();
            var rawData = File.ReadAllBytes(filename);

            rom.RawData = RemoveSmcHeader(rawData);

            var formatByte = rom.GetByteAt(0x7FD9);
            rom.Format = formatByte > 1 ? RomFormat.PAL : RomFormat.NTSC;

            if (rom.Format == RomFormat.PAL)
            {
                throw new Exception("This is a PAL Rom. PAL Roms are not supported.");
            }

            rom.PlmBank = rom.GetByteAt(0x204AC);
            rom.ScrollPlmBank = rom.GetByteAt(0x20B60);

            AppState.Rom = rom;
        }

        private void CheckFileSize(string filename)
        {
            var fileInfo = new FileInfo(filename);
            
            if (fileInfo.Length < 0x8000)
            {
                throw new Exception("Rom file is too small.");
            }

            // max length 0xFFFFFF, file might include SMC header (length 0x200)
            if (fileInfo.Length > 0x10001FF)
            {
                throw new Exception("Rom file is too large.");
            }
        }

        private byte[] RemoveSmcHeader(byte[] rawData)
        {
            var headerSize = rawData.Length % 1024;

            if (headerSize != 0 && headerSize != 512)
            {
                throw new Exception("Rom has a malformed SMC header.");
            }

            if (headerSize == 512)
            {
                return rawData.Skip(512).ToArray();
            }

            return rawData;
        }
    }
}
