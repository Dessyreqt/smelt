namespace Smelt.Logic.Rom
{
    using System;
    using System.IO;
    using Data;

    public class LoadRomCommand : Command
    {
        private string filename;

        public LoadRomCommand(AppState appState, string filename) : base(appState)
        {
            this.filename = filename;
        }

        protected override void Handle()
        {
            AppState.Rom = null;

            var rom = new Rom();
            rom.RawData = File.ReadAllBytes(filename);

            rom.HeaderSize = rom.RawData.Length % 32768 == 0 ? 0 : 512;

            var formatByte = rom.GetByteAt(0x7FD9);
            rom.Format = formatByte > 1 ? RomFormat.PAL : RomFormat.NTSC;

            if (rom.Format == RomFormat.PAL)
            {
                throw new Exception("This is a PAL Rom!");
            }

            rom.PlmBank = rom.GetByteAt(0x204AC);
            rom.ScrollPlmBank = rom.GetByteAt(0x20B60);

            AppState.Rom = rom;
        }
    }
}
