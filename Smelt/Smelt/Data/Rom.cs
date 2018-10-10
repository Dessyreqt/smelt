namespace Smelt.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum RomFormat
    {
        NTSC,
        PAL
    }

    public class Rom
    {
        public RomFormat Format { get; set; }
        public byte PlmBank { get; set; }
        public byte ScrollPlmBank { get; set; }
        
        public byte[] RawData { private get; set; }

        public byte GetByteAt(int location)
        {
            return RawData[location];
        }
    }
}
