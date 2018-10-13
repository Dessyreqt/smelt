namespace Smelt.Tests.Logic.Rom.GetRomInfo
{
    using Shouldly;
    using Smelt.Data;
    using Smelt.Logic;
    using Smelt.Logic.Rom;

    public class WhenGettingHiRom
    {
        private readonly AppState appState;
        private readonly string testRom = "Final Fantasy III (U).sfc";

        public WhenGettingHiRom()
        {
            appState = new AppState();
            TestRoms.Include(testRom);
            Command.Run(new LoadRomCommand(appState, testRom));
        }

        public void ShouldHaveCorrectEditableStatus()
        {
            appState.Rom.Editable.ShouldBe(false);
        }

        public void ShouldHaveCorrectHeaderMakeupMapping()
        {
            appState.Rom.Header.Makeup.Mapping.ShouldBe(Mapping.HiRom);
        }
    }
}
