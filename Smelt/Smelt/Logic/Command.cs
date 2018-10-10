namespace Smelt.Logic
{
    using System;
    using System.Windows.Forms;
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
            try
            {
                command.Handle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        protected abstract void Handle();
    }
}
