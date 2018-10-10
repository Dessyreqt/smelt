namespace Smelt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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
            }
        }
    }
}
