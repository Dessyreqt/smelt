namespace Smelt.Tests.Logic.Rom.LoadRom
{
    using Shouldly;
    using Smelt.Data;
    using Smelt.Logic;
    using Smelt.Logic.Rom;

    public class WhenLoadingARomWithBadHeader
    {
        private readonly AppState appState;
        private readonly string testRom = "badheader.sfc";

        public WhenLoadingARomWithBadHeader()
        {
            appState = new AppState();
            TestRoms.Include(testRom);
        }

        public void ShouldThrowException()
        {
            Should.Throw<LoadRomException>(() => Command.Run(new LoadRomCommand(appState, testRom)));
        }
    }
}
