namespace Smelt.Tests.Logic.Rom.LoadRom
{
    using System.IO;
    using Shouldly;
    using Smelt.Data;
    using Smelt.Logic;
    using Smelt.Logic.Rom;

    public class WhenLoadingAHeaderedRom
    {
        private readonly AppState appState;
        private readonly string testRom = "Metroid Legacy.smc";
        private readonly byte[] rawBytes;

        public WhenLoadingAHeaderedRom()
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

        public void ShouldMatchRawFileSizeMinusHeader()
        {
            appState.Rom.RawData.Length.ShouldBe(rawBytes.Length - 0x200);
        }
    }
}
