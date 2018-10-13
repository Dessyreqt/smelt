namespace Smelt.Tests.Logic.Rom.GetRomInfo
{
    using Shouldly;
    using Smelt.Data;
    using Smelt.Logic;
    using Smelt.Logic.Rom;

    public class WhenGettingPALRom
    {
        private readonly AppState appState;
        private readonly string testRom = "Super Metroid (E).sfc";

        public WhenGettingPALRom()
        {
            appState = new AppState();
            TestRoms.Include(testRom);
            Command.Run(new LoadRomCommand(appState, testRom));
        }

        public void ShouldHaveCorrectRegion()
        {
            appState.Rom.Region.ShouldBe(RomRegion.PAL);
        }

        public void ShouldHaveCorrectEditableStatus()
        {
            appState.Rom.Editable.ShouldBe(false);
        }

        public void ShouldHaveCorrectHeaderCreatorLicenseIdCode()
        {
            appState.Rom.Header.CreatorLicenseIdCode.ShouldBe(0x2);
        }
    }
}
