namespace Smelt.Tests.Logic.Rom.GetRomInfo
{
    using Shouldly;
    using Smelt.Data;
    using Smelt.Logic;
    using Smelt.Logic.Rom;

    public class WhenGettingNonFastRom
    {
        private readonly AppState appState;
        private readonly string testRom = "F-Zero (U).sfc";

        public WhenGettingNonFastRom()
        {
            appState = new AppState();
            TestRoms.Include(testRom);
            Command.Run(new LoadRomCommand(appState, testRom));
        }

        public void ShouldHaveCorrectEditableStatus()
        {
            appState.Rom.Editable.ShouldBe(false);
        }

        public void ShouldHaveCorrectHeaderMakeupFastRom()
        {
            appState.Rom.Header.Makeup.FastRom.ShouldBe(false);
        }
    }
}
