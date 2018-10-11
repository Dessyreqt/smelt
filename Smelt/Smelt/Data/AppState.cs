namespace Smelt.Data
{
    public class AppState
    {
        public Rom Rom { get; set; }

        public string InputAddress { get; set; }
        public string OutputAddress { get; set; }

        public AppState()
        {
            InputAddress = "";
            OutputAddress = "";
        }
    }
}
