namespace Smelt.Tests.Logic.Rom.LoadRom
{
    using System.IO;
    using Shouldly;
    using Smelt.Data;
    using Smelt.Logic;
    using Smelt.Logic.Rom;

    public class WhenLoadingAnUnheaderedRom
    {
        private readonly AppState appState;
        private readonly string testRom = "Super Metroid (J,U).sfc";
        private readonly byte[] rawBytes;

        public WhenLoadingAnUnheaderedRom()
        {
            appState = new AppState();
            TestRoms.Include(testRom);
            Command.Run(new LoadRomCommand(appState, testRom));
            rawBytes = File.ReadAllBytes(testRom);
        }

        public void ShouldLoadRom()
        {
            appState.Rom.ShouldNotBeNull();
        }

        public void ShouldMatchRawFileSize()
        {
            appState.Rom.RawData.Length.ShouldBe(rawBytes.Length);
        }
    }
}
