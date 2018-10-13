namespace Smelt.Logic.Rom
{
    using Data;

    public class GetRomInfoCommand : Command
    {
        public GetRomInfoCommand(AppState appState) : base(appState)
        {
        }

        protected override void Handle()
        {
            var rom = AppState.Rom;

            DetermineMapping(rom);
            ReadHeader(rom);

            // this doesn't go here, eventually it will be part of an SM specific command
            rom.PlmBank = rom.Byte(0x204AC);
            rom.ScrollPlmBank = rom.Byte(0x20B60);

            if (rom.Region == RomRegion.NTSC && rom.PlmBank == 0x8F && rom.ScrollPlmBank == 0x8F)
            {
                rom.Editable = true;
            }
        }

        private void ReadHeader(Rom rom)
        {
            var startAddress = rom.BankSize - 0x40;

            rom.Header.Title = rom.String(startAddress, 21);
            rom.Header.Makeup = RomMakeup.Parse(rom.Byte(startAddress + 0x15));
            rom.Header.Type = rom.Byte(startAddress + 0x16);
            rom.Header.RomSize = rom.Byte(startAddress + 0x17);
            rom.Header.SramSize = rom.Byte(startAddress + 0x18);
            rom.Header.CreatorLicenseIdCode = rom.Byte(startAddress + 0x19);
            rom.Header.VersionNum = rom.Byte(startAddress + 0x1B);
            rom.Header.ChecksumComplement = rom.Word(startAddress + 0x1C);
            rom.Header.Checksum = rom.Word(startAddress + 0x1E);
        }

        private void DetermineMapping(Rom rom)
        {
            var hiRomScore = GetHiRomScore(rom);
            var loRomScore = GetLoRomScore(rom);

            rom.Header.Makeup.Mapping = hiRomScore > loRomScore ? Mapping.HiRom : Mapping.LoRom;
        }

        private int GetLoRomScore(Rom rom)
        {
            int score = 0;

            if (rom.Word(0x7FDC) + rom.Word(0x7FDE) == 0xFFFF)
            {
                score += 2;
            }

            if (rom.Byte(0x7FDA) == 0x33)
            {
                score += 2;
            }

            if ((rom.Byte(0x7FD5) & 0xf) < 4)
            {
                score += 2;
            }

            if ((rom.Byte(0x7FFD) & 0x80) == 0)
            {
                score -= 4;
            }

            if ((1 << (rom.Byte(0x7FD7) - 7)) > 48)
            {
                score -= 1;
            }

            if (!IsAsciiString(rom, 0x7FB0, 6))
            {
                score -= 1;
            }

            if (!IsAsciiString(rom, 0x7FC0, 20))
            {
                score -= 1;
            }

            return score;
        }

        private int GetHiRomScore(Rom rom)
        {
            int score = 0;

            if (rom.Word(0xFFDC) + rom.Word(0xFFDE) == 0xFFFF)
            {
                score += 2;
            }

            if (rom.Byte(0xFFDA) == 0x33)
            {
                score += 2;
            }

            if ((rom.Byte(0xFFD5) & 0xf) < 4)
            {
                score += 2;
            }

            if ((rom.Byte(0xFFFD) & 0x80) == 0)
            {
                score -= 4;
            }

            if ((1 << (rom.Byte(0xFFD7) - 7)) > 48)
            {
                score -= 1;
            }

            if (!IsAsciiString(rom, 0xFFB0, 6))
            {
                score -= 1;
            }

            if (!IsAsciiString(rom, 0xFFC0, 20))
            {
                score -= 1;
            }

            return score;
        }

        private bool IsAsciiString(Rom rom, int start, int length)
        {
            for (int i = start; i < start + length; i++)
            {
                if (rom.Byte(i) < 0x20 || rom.Byte(i) > 0x7E)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
