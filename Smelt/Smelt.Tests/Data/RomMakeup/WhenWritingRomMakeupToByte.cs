namespace Smelt.Tests.Data.RomMakeup
{
    using Shouldly;
    using Smelt.Data;

    public class WhenWritingRomMakeupToByte
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

            makeup.ToByte().ShouldBe((byte)0x20);
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

            makeup.ToByte().ShouldBe((byte)0x21);
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

            makeup.ToByte().ShouldBe((byte)0x25);
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

            makeup.ToByte().ShouldBe((byte)0x22);

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

            makeup.ToByte().ShouldBe((byte)0x30);
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

            makeup.ToByte().ShouldBe((byte)0x31);
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

            makeup.ToByte().ShouldBe((byte)0x23);
        }
    }
}
