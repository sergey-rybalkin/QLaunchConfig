namespace QLaunchConfig
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lvQLaunchItems = new System.Windows.Forms.ListView();
            this.cName = new System.Windows.Forms.ColumnHeader();
            this.cPath = new System.Windows.Forms.ColumnHeader();
            this.cHotkey = new System.Windows.Forms.ColumnHeader();
            this.gbItemEditor = new System.Windows.Forms.GroupBox();
            this.hkcLaunchHotkey = new exscape.HotkeyControl();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbMonitor = new System.Windows.Forms.ComboBox();
            this.cbWindowState = new System.Windows.Forms.ComboBox();
            this.txtCmdParams = new System.Windows.Forms.TextBox();
            this.txtExecutablePath = new System.Windows.Forms.TextBox();
            this.btnBrowseForExecutable = new System.Windows.Forms.Button();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbItemEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvQLaunchItems
            // 
            this.lvQLaunchItems.AllowColumnReorder = true;
            this.lvQLaunchItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvQLaunchItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cName,
            this.cPath,
            this.cHotkey});
            this.lvQLaunchItems.FullRowSelect = true;
            this.lvQLaunchItems.GridLines = true;
            this.lvQLaunchItems.Location = new System.Drawing.Point(12, 12);
            this.lvQLaunchItems.MultiSelect = false;
            this.lvQLaunchItems.Name = "lvQLaunchItems";
            this.lvQLaunchItems.Size = new System.Drawing.Size(642, 339);
            this.lvQLaunchItems.TabIndex = 0;
            this.lvQLaunchItems.UseCompatibleStateImageBehavior = false;
            this.lvQLaunchItems.View = System.Windows.Forms.View.Details;
            this.lvQLaunchItems.SelectedIndexChanged += new System.EventHandler(this.lvQLaunchItems_SelectedIndexChanged);
            // 
            // cName
            // 
            this.cName.Text = "Name";
            this.cName.Width = 100;
            // 
            // cPath
            // 
            this.cPath.Text = "File path";
            this.cPath.Width = 450;
            // 
            // cHotkey
            // 
            this.cHotkey.Text = "Hotkey";
            this.cHotkey.Width = 86;
            // 
            // gbItemEditor
            // 
            this.gbItemEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbItemEditor.Controls.Add(this.hkcLaunchHotkey);
            this.gbItemEditor.Controls.Add(this.btnAdd);
            this.gbItemEditor.Controls.Add(this.btnSave);
            this.gbItemEditor.Controls.Add(this.cbMonitor);
            this.gbItemEditor.Controls.Add(this.cbWindowState);
            this.gbItemEditor.Controls.Add(this.txtCmdParams);
            this.gbItemEditor.Controls.Add(this.txtExecutablePath);
            this.gbItemEditor.Controls.Add(this.btnBrowseForExecutable);
            this.gbItemEditor.Controls.Add(this.txtItemName);
            this.gbItemEditor.Controls.Add(this.label7);
            this.gbItemEditor.Controls.Add(this.label6);
            this.gbItemEditor.Controls.Add(this.label5);
            this.gbItemEditor.Controls.Add(this.label3);
            this.gbItemEditor.Controls.Add(this.label2);
            this.gbItemEditor.Controls.Add(this.label1);
            this.gbItemEditor.Location = new System.Drawing.Point(660, 12);
            this.gbItemEditor.Name = "gbItemEditor";
            this.gbItemEditor.Size = new System.Drawing.Size(343, 339);
            this.gbItemEditor.TabIndex = 1;
            this.gbItemEditor.TabStop = false;
            this.gbItemEditor.Text = "Edit item";
            // 
            // hkcLaunchHotkey
            // 
            this.hkcLaunchHotkey.Hotkey = System.Windows.Forms.Keys.None;
            this.hkcLaunchHotkey.HotkeyModifiers = System.Windows.Forms.Keys.None;
            this.hkcLaunchHotkey.Location = new System.Drawing.Point(105, 156);
            this.hkcLaunchHotkey.Name = "hkcLaunchHotkey";
            this.hkcLaunchHotkey.Size = new System.Drawing.Size(231, 20);
            this.hkcLaunchHotkey.TabIndex = 17;
            this.hkcLaunchHotkey.Text = "None";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(176, 310);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(261, 310);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbMonitor
            // 
            this.cbMonitor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonitor.FormattingEnabled = true;
            this.cbMonitor.Location = new System.Drawing.Point(105, 217);
            this.cbMonitor.Name = "cbMonitor";
            this.cbMonitor.Size = new System.Drawing.Size(231, 21);
            this.cbMonitor.TabIndex = 14;
            // 
            // cbWindowState
            // 
            this.cbWindowState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWindowState.FormattingEnabled = true;
            this.cbWindowState.Items.AddRange(new object[] {
            "SW_HIDE",
            "SW_NORMAL",
            "SW_MINIMIZE",
            "SW_MAXIMIZE"});
            this.cbWindowState.Location = new System.Drawing.Point(105, 186);
            this.cbWindowState.Name = "cbWindowState";
            this.cbWindowState.Size = new System.Drawing.Size(231, 21);
            this.cbWindowState.TabIndex = 13;
            // 
            // txtCmdParams
            // 
            this.txtCmdParams.Location = new System.Drawing.Point(10, 126);
            this.txtCmdParams.Name = "txtCmdParams";
            this.txtCmdParams.Size = new System.Drawing.Size(326, 20);
            this.txtCmdParams.TabIndex = 10;
            // 
            // txtExecutablePath
            // 
            this.txtExecutablePath.Location = new System.Drawing.Point(10, 73);
            this.txtExecutablePath.Name = "txtExecutablePath";
            this.txtExecutablePath.Size = new System.Drawing.Size(294, 20);
            this.txtExecutablePath.TabIndex = 9;
            // 
            // btnBrowseForExecutable
            // 
            this.btnBrowseForExecutable.Location = new System.Drawing.Point(310, 73);
            this.btnBrowseForExecutable.Name = "btnBrowseForExecutable";
            this.btnBrowseForExecutable.Size = new System.Drawing.Size(26, 20);
            this.btnBrowseForExecutable.TabIndex = 8;
            this.btnBrowseForExecutable.Text = "...";
            this.btnBrowseForExecutable.UseVisualStyleBackColor = true;
            this.btnBrowseForExecutable.Click += new System.EventHandler(this.btnBrowseForExecutable_Click);
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(73, 20);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(264, 20);
            this.txtItemName.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Select monitor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Window state:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Hot key:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Command line parameters:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Executable path:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item name:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 363);
            this.Controls.Add(this.gbItemEditor);
            this.Controls.Add(this.lvQLaunchItems);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quick Launch configuration";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbItemEditor.ResumeLayout(false);
            this.gbItemEditor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvQLaunchItems;
        private System.Windows.Forms.ColumnHeader cName;
        private System.Windows.Forms.ColumnHeader cPath;
        private System.Windows.Forms.GroupBox gbItemEditor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Button btnBrowseForExecutable;
        private System.Windows.Forms.TextBox txtExecutablePath;
        private System.Windows.Forms.TextBox txtCmdParams;
        private System.Windows.Forms.ComboBox cbWindowState;
        private System.Windows.Forms.ComboBox cbMonitor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ColumnHeader cHotkey;
        private System.Windows.Forms.Button btnAdd;
        private exscape.HotkeyControl hkcLaunchHotkey;
        private System.Windows.Forms.Label label5;
    }
}

