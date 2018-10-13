namespace Smelt.Tests.Logic.Rom.GetRomInfo
{
    using Shouldly;
    using Smelt.Data;
    using Smelt.Logic;
    using Smelt.Logic.Rom;

    public class WhenGettingSa1Rom
    {
        private readonly AppState appState;
        private readonly string testRom = "Super Mario RPG (U).sfc";

        public WhenGettingSa1Rom()
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
            appState.Rom.Header.Makeup.Sa1.ShouldBe(true);
        }

        public void ShouldHaveCorrectHeaderMakeupMapping()
        {
            appState.Rom.Header.Makeup.Mapping.ShouldBe(Mapping.HiRom);
        }
    }
}
