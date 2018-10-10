namespace Smelt
{
    using System;
    using System.Windows.Forms;
    using Data;
    using Logic;
    using Logic.Rom;

    public partial class MainForm : Form
    {
        private AppState appState;

        public MainForm()
        {
            InitializeComponent();

            appState = new AppState();
        }

        private void loadROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
                                    {
                                        Title = "Open Super Metroid ROM File",
                                        Filter = "SNES ROM files|*.sfc;*.smc;*.swc;*.fig|All files|*.*"
                                    };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Command.Run(new LoadRomCommand(appState, dialog.FileName));
                SetRomInfoLabelText();
            }
        }

        private void SetRomInfoLabelText()
        {
            var rom = appState.Rom;

            romInfoLabel.Text = $@"Title: {rom.Header.Title}
Makeup: {rom.Header.Makeup}
Version: {rom.Header.VersionNum}
Checksum complement: 0x{rom.Header.ChecksumComplement:X4}
Checksum: 0x{rom.Header.Checksum:X4}

Region: {rom.Region}
Editable: {rom.Editable}";
        }

        private void saveROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (appState.Rom == null)
            {
                throw new Exception("No rom loaded.");
            }

            SaveFileDialog dialog = new SaveFileDialog
                                    {
                                        Title = "Save Super Metroid ROM File",
                                        Filter = "SNES ROM file|*.sfc"
                                    };

            dialog.ShowDialog();

            if (dialog.FileName != "")
            {
                if (!dialog.FileName.EndsWith(".sfc"))
                {
                    dialog.FileName += ".sfc";
                }

                Command.Run(new SaveRomCommand(appState, dialog.FileName));
            }
        }
    }
}
