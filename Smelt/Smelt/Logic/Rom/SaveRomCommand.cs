namespace Smelt.Logic.Rom
{
    using System.IO;
    using Data;

    public class SaveRomCommand : Command
    {
        private readonly string filename;

        public SaveRomCommand(AppState appState, string filename) : base(appState)
        {
            this.filename = filename;
        }

        protected override void Handle()
        {
            File.WriteAllBytes(filename, AppState.Rom.RawData);
        }
    }
}
