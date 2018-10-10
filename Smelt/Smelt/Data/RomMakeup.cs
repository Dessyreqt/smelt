namespace Smelt.Data
{
    using System;
    using System.Text;

    public enum Mapping
    {
        Unknown,
        LoRom,
        HiRom,
    }


    public class RomMakeup
    {
        public Mapping Mapping { get; set; }

        public bool FastRom { get; set; }
        public bool ExLoRom { get; set; }
        public bool ExHiRom { get; set; }
        public bool Sa1 { get; set; }

        public static RomMakeup Parse(byte input)
        {
            var makeup = new RomMakeup();

            if ((input & 0x20) == 0)
            {
                throw new Exception("Unrecognized Rom makeup");
            }

            if ((input & 0x1) == 0x1)
            {
                makeup.Mapping = Mapping.HiRom;
            }
            else
            {
                makeup.Mapping = Mapping.LoRom;
            }

            if ((input & 0x2) == 0x2)
            {
                makeup.ExLoRom = true;
            }

            if ((input & 0x4) == 0x4)
            {
                makeup.ExHiRom = true;
            }

            if (makeup.ExLoRom && makeup.ExHiRom)
            {
                throw new Exception("Unrecognized Rom makeup");
            }

            if ((input & 0x10) == 0x10)
            {
                makeup.FastRom = true;
            }

            if (makeup.Mapping == Mapping.HiRom && makeup.ExLoRom)
            {
                makeup.ExLoRom = false;
                makeup.Sa1 = true;
            }

            return makeup;
        }

        public byte ToByte()
        {
            byte retVal = 0x20;

            if (Sa1)
            {
                return 0x23;
            }

            if (Mapping == Mapping.HiRom)
            {
                retVal += 0x1;
            }

            if (ExLoRom)
            {
                retVal += 0x2;
            }

            if (ExHiRom)
            {
                retVal += 0x4;
            }

            if (FastRom)
            {
                retVal += 0x10;
            }

            return retVal;
        }

        public override string ToString()
        {
            if (Sa1)
            {
                return "SA-1";
            }
            if (ExHiRom)
            {
                return "ExHiRom";
            }
            if (ExLoRom)
            {
                return "ExLoRom";
            }

            var retVal = new StringBuilder();

            retVal.Append(Mapping);
            if (FastRom)
            {
                retVal.Append(" + FastRom");
            }

            return retVal.ToString();
        }
    }
}
