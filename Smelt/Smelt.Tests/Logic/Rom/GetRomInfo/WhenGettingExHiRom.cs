namespace Smelt.Tests.Logic.Rom.GetRomInfo
{
    using Shouldly;
    using Smelt.Data;
    using Smelt.Logic;
    using Smelt.Logic.Rom;

    public class WhenGettingExHiRom
    {
        private readonly AppState appState;
        private readonly string testRom = "Tales of Phantasia (J).sfc";

        public WhenGettingExHiRom()
        {
            appState = new AppState();
            TestRoms.Include(testRom);
            Command.Run(new LoadRomCommand(appState, testRom));
        }

        public void ShouldHaveCorrectEditableStatus()
        {
            appState.Rom.Editable.ShouldBe(false);
        }

        public void ShouldHaveCorrectHeaderMakeupSa1()
        {
            appState.Rom.Header.Makeup.ExHiRom.ShouldBe(true);
        }

        public void ShouldHaveCorrectHeaderMakeupMapping()
        {
            appState.Rom.Header.Makeup.Mapping.ShouldBe(Mapping.HiRom);
        }
    }
}
