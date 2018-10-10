namespace Smelt.Data
{
    using System.Globalization;
    using System.Text;

    public enum RomRegion
    {
        NTSC,
        PAL
    }

    public class Rom
    {
        public RomRegion Region => Header.CreatorLicenseIdCode < 2 ? RomRegion.NTSC : RomRegion.PAL;
        public RomHeader Header { get; }
        public int BankSize => Header.Makeup.Mapping == Mapping.HiRom ? 0x10000 : 0x8000;
        public byte PlmBank { get; set; }
        public byte ScrollPlmBank { get; set; }
        
        public byte[] RawData { get; set; }

        public bool Editable { get; set; }

        public Rom()
        {
            Header = new RomHeader();
        }

        public byte Byte(int location)
        {
            return RawData[location];
        }

        public int Word(int location)
        {
            return RawData[location] + RawData[location + 1] * 0x100;
        }

        public string String(int location, int size)
        {
            var retVal = new StringBuilder();

            for (var i = location; i < location + size; i++)
            {
                retVal.Append((char)RawData[i]);
            }

            return retVal.ToString();
        }
    }
}
