namespace Smelt.Tests.Logic.Rom.SaveRom
{
    using System.IO;
    using Shouldly;
    using Smelt.Data;
    using Smelt.Logic;
    using Smelt.Logic.Rom;

    public class WhenSavingA0ByteRom
    {
        private readonly AppState appState;
        private readonly string testRomName = "testrom.sfc";
        private readonly FileInfo fileInfo;

        public WhenSavingA0ByteRom()
        {
            appState = new AppState { Rom = new Rom() };
            appState.Rom.RawData = new byte[0];
            Command.Run(new SaveRomCommand(appState, testRomName));
            fileInfo = new FileInfo(testRomName);
        }

        public void FileShouldExist()
        {
            fileInfo.Exists.ShouldBe(true);
        }

        public void FileShouldHave0Bytes()
        {
            fileInfo.Length.ShouldBe(0);
        }
    }
}
