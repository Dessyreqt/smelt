namespace Smelt.Tests.Data.RomMakeup
{
    using Shouldly;
    using Smelt.Data;

    public class WhenWritingRomMakeupToString
    {
        public void ShouldWriteLoRom()
        {
            var makeup = new RomMakeup
            {
                Mapping = Mapping.LoRom,
                ExHiRom = false,
                ExLoRom = false,
                FastRom = false,
                Sa1 = false
            };

            makeup.ToString().ShouldBe("LoRom");
        }

        public void ShouldWriteHiRom()
        {
            var makeup = new RomMakeup
            {
                Mapping = Mapping.HiRom,
                ExHiRom = false,
                ExLoRom = false,
                FastRom = false,
                Sa1 = false
            };

            makeup.ToString().ShouldBe("HiRom");
        }

        public void ShouldWriteExHiRom()
        {
            var makeup = new RomMakeup
            {
                Mapping = Mapping.HiRom,
                ExHiRom = true,
                ExLoRom = false,
                FastRom = false,
                Sa1 = false
            };

            makeup.ToString().ShouldBe("ExHiRom");
        }

        public void ShouldWriteExLoRom()
        {
            var makeup = new RomMakeup
            {
                Mapping = Mapping.LoRom,
                ExHiRom = false,
                ExLoRom = true,
                FastRom = false,
                Sa1 = false
            };

            makeup.ToString().ShouldBe("ExLoRom");

        }

        public void ShouldWriteLoRomFastRom()
        {
            var makeup = new RomMakeup
            {
                Mapping = Mapping.LoRom,
                ExHiRom = false,
                ExLoRom = false,
                FastRom = true,
                Sa1 = false
            };

            makeup.ToString().ShouldBe("LoRom + FastRom");
        }

        public void ShouldWriteHiRomFastRom()
        {
            var makeup = new RomMakeup
            {
                Mapping = Mapping.HiRom,
                ExHiRom = false,
                ExLoRom = false,
                FastRom = true,
                Sa1 = false
            };

            makeup.ToString().ShouldBe("HiRom + FastRom");
        }

        public void ShouldWriteSa1()
        {
            var makeup = new RomMakeup
            {
                Mapping = Mapping.HiRom,
                ExHiRom = false,
                ExLoRom = false,
                FastRom = false,
                Sa1 = true
            };

            makeup.ToString().ShouldBe("SA-1");
        }
    }
}
