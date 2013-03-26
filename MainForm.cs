using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLaunchConfig
{
    /// <summary>
    /// Main form of the quick launch configuration editor application
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields

        private bool _isAddMode;

        #endregion
        
        #region Constructor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Helper methods

        private void RefreshItemsList()
        {
            lvQLaunchItems.Items.Clear();

            try
            {
                List<QLaunchItem> configuration = QLaunchConfiguration.ReadConfiguration();
                lvQLaunchItems.BeginUpdate();
                foreach (QLaunchItem qLaunchItem in configuration)
                {
                    string hotkey = String.Format("{0}-{1}",
                                                  qLaunchItem.AsyncKeyCode,
                                                  qLaunchItem.MainKeyCode);

                    ListViewItem item = new ListViewItem(
                        new[] { qLaunchItem.Name, 
                                qLaunchItem.FilePath, 
                                hotkey });
                    lvQLaunchItems.Items.Add(item);
                }
                lvQLaunchItems.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, 
                                ex.ToString(), 
                                "Could not read configuration", 
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void FillMonitorsList()
        {
            foreach (Screen screen in Screen.AllScreens)
                cbMonitor.Items.Add(screen.DeviceName + (screen.Primary ? " (primary)" : ""));
        }

        #endregion

        #region Event handlers

        /// <summary>
        /// Handles the Load event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.
        /// </param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshItemsList();
            FillMonitorsList();
        }

        /// <summary>
        /// Handles the Click event of the btnAdd control. Here we will prepare the form to add new 
        /// configuration item.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.
        /// </param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _isAddMode = true;

            txtItemName.Text = "";
            txtExecutablePath.Text = "";
            txtCmdParams.Text = "";
            cbWindowState.SelectedIndex = 1;
            cbMonitor.SelectedIndex = 0;
            hkcLaunchHotkey.Clear();
        }

        /// <summary>
        /// Handles the Click event of the btnSave control. Here we will update or create a new
        /// configuration section depending on _isAddMode value.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.
        /// </param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (0 == hkcLaunchHotkey.Text.Length ||
                -1 == cbMonitor.SelectedIndex ||
                -1 == cbWindowState.SelectedIndex ||
                String.IsNullOrEmpty(txtItemName.Text) ||
                String.IsNullOrEmpty(txtExecutablePath.Text))
            {
                MessageBox.Show(this, 
                                "Please fill all the required fields", 
                                "Validation error", 
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            QLaunchItem item = new QLaunchItem
                {
                    AsyncKeyCode = hkcLaunchHotkey.HotkeyModifiers,
                    MainKeyCode = hkcLaunchHotkey.Hotkey,
                    CmdParameters = txtCmdParams.Text,
                    FilePath = txtExecutablePath.Text,
                    MonitorIndex = cbMonitor.SelectedIndex,
                    Name = txtItemName.Text,
                    WindowState = (WindowState) Enum.Parse(typeof (WindowState), cbWindowState.Text)
                };

            if (_isAddMode)
                QLaunchConfiguration.AddItem(item);
            else
                QLaunchConfiguration.UpdateItem(item);

            RefreshItemsList();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the lvQLaunchItems control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.
        /// </param>
        private void lvQLaunchItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (0 == lvQLaunchItems.SelectedIndices.Count)
                return;

            _isAddMode = false;

            try
            {
                List<QLaunchItem> configuration = QLaunchConfiguration.ReadConfiguration();

                QLaunchItem item = configuration[lvQLaunchItems.SelectedIndices[0]];
                txtItemName.Text = item.Name;
                txtExecutablePath.Text = item.FilePath;
                txtCmdParams.Text = item.CmdParameters;
                hkcLaunchHotkey.Hotkey = item.MainKeyCode;
                hkcLaunchHotkey.HotkeyModifiers = item.AsyncKeyCode;
                cbMonitor.SelectedIndex = item.MonitorIndex;
                cbWindowState.Text = item.WindowState.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                                ex.ToString(),
                                "Could not read configuration",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnBrowseForExecutable control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.
        /// </param>
        private void btnBrowseForExecutable_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog {CheckFileExists = true, Multiselect = false};
            if (DialogResult.OK == dlg.ShowDialog(this))
            {
                txtExecutablePath.Text = dlg.FileName;
            }
        }

        #endregion
    }
}