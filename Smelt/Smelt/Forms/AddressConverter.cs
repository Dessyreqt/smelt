namespace Smelt.Forms
{
    using System;
    using System.Windows.Forms;
    using Data;
    using Logic.AddressConverter;

    public partial class AddressConverter : Form
    {
        private readonly AppState appState;

        public AddressConverter(AppState appState)
        {
            InitializeComponent();

            this.appState = appState;
            inputAddressTextBox.Text = appState.InputAddress;
            outputAddressTextBox.Text = appState.OutputAddress;
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            appState.InputAddress = inputAddressTextBox.Text;
            UiCommand.Run(new ConvertAddressCommand(appState));
            outputAddressTextBox.Text = appState.OutputAddress;
        }
    }
}
