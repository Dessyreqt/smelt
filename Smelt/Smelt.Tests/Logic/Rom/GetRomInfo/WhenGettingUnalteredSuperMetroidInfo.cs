namespace Smelt.Tests.Logic.Rom.GetRomInfo
{
    using Shouldly;
    using Smelt.Data;
    using Smelt.Logic;
    using Smelt.Logic.Rom;

    public class WhenGettingUnalteredSuperMetroidInfo
    {
        private readonly AppState appState;
        private readonly string testRom = "Super Metroid (J,U).sfc";

        public WhenGettingUnalteredSuperMetroidInfo()
        {
            appState = new AppState();
            TestRoms.Include(testRom);
            Command.Run(new LoadRomCommand(appState, testRom));
        }

        public void ShouldHaveCorrectRegion()
        {
            appState.Rom.Region.ShouldBe(RomRegion.NTSC);
        }

        public void ShouldHaveCorrectEditableStatus()
        {
            appState.Rom.Editable.ShouldBe(true);
        }

        public void ShouldHaveCorrectPlmBank()
        {
            appState.Rom.PlmBank.ShouldBe((byte)0x8F);
        }

        public void ShouldHaveCorrectScrollPlmBank()
        {
            appState.Rom.ScrollPlmBank.ShouldBe((byte)0x8F);
        }

        public void ShouldHaveCorrectBankSize()
        {
            appState.Rom.BankSize.ShouldBe(0x8000);
        }

        public void ShouldHaveCorrectHeaderTitle()
        {
            appState.Rom.Header.Title.ShouldBe("Super Metroid        ");
        }

        public void ShouldHaveCorrectHeaderType()
        {
            appState.Rom.Header.Type.ShouldBe(0x2);
        }

        public void ShouldHaveCorrectHeaderRomSize()
        {
            appState.Rom.Header.RomSize.ShouldBe(0xC);
        }

        public void ShouldHaveCorrectHeaderSramSize()
        {
            appState.Rom.Header.SramSize.ShouldBe(0x3);
        }

        public void ShouldHaveCorrectHeaderCreatorLicenseIdCode()
        {
            appState.Rom.Header.CreatorLicenseIdCode.ShouldBe(0);
        }

        public void ShouldHaveCorrectHeaderVersionNum()
        {
            appState.Rom.Header.VersionNum.ShouldBe(0);
        }

        public void ShouldHaveCorrectHeaderChecksumComplement()
        {
            appState.Rom.Header.ChecksumComplement.ShouldBe(0x720);
        }

        public void ShouldHaveCorrectHeaderChecksum()
        {
            appState.Rom.Header.Checksum.ShouldBe(0xF8DF);
        }

        public void ShouldHaveCorrectHeaderMakeupExHiRom()
        {
            appState.Rom.Header.Makeup.ExHiRom.ShouldBe(false);
        }

        public void ShouldHaveCorrectHeaderMakeupExLoRom()
        {
            appState.Rom.Header.Makeup.ExLoRom.ShouldBe(false);
        }

        public void ShouldHaveCorrectHeaderMakeupSa1()
        {
            appState.Rom.Header.Makeup.Sa1.ShouldBe(false);
        }

        public void ShouldHaveCorrectHeaderMakeupFastRom()
        {
            appState.Rom.Header.Makeup.FastRom.ShouldBe(true);
        }

        public void ShouldHaveCorrectHeaderMakeupMapping()
        {
            appState.Rom.Header.Makeup.Mapping.ShouldBe(Mapping.LoRom);
        }
    }
}
