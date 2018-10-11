namespace Smelt.Forms
{
    using System;
    using System.Windows.Forms;
    using Data;
    using Logic;

    public abstract class UiCommand : Command
    {
        protected UiCommand(AppState appState) : base(appState)
        {
        }

        public new static void Run(Command command)
        {
            try
            {
                Command.Run(command);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}
