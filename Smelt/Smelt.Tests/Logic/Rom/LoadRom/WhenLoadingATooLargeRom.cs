namespace Smelt.Tests.Logic.Rom.LoadRom
{
    using Shouldly;
    using Smelt.Data;
    using Smelt.Logic;
    using Smelt.Logic.Rom;

    public class WhenLoadingATooLargeRom
    {
        private readonly AppState appState;
        private readonly string testRom = "toolarge.sfc";

        public WhenLoadingATooLargeRom()
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
