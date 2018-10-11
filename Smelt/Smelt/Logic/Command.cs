namespace Smelt.Logic
{
    using Data;

    public abstract class Command
    {
        protected readonly AppState AppState;

        protected Command(AppState appState)
        {
            AppState = appState;
        }

        public static void Run(Command command)
        {
            command.Handle();
        }

        protected abstract void Handle();
    }
}
