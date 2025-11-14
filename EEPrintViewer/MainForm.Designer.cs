namespace EPrintViewer
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView gridJobs;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.TextBox txtOriginalFile;
        private System.Windows.Forms.TextBox txtLayoutWidth;
        private System.Windows.Forms.TextBox txtLayoutHeight;
        private System.Windows.Forms.NumericUpDown numCopies;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.CheckBox chkStepRepeat;

        private System.Windows.Forms.Label lblOriginalFile;
        private System.Windows.Forms.Label lblLayoutWidth;
        private System.Windows.Forms.Label lblLayoutHeight;
        private System.Windows.Forms.Label lblCopies;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblStepRepeat;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem openFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeStatusMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gridJobs = new System.Windows.Forms.DataGridView();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.txtOriginalFile = new System.Windows.Forms.TextBox();
            this.txtLayoutWidth = new System.Windows.Forms.TextBox();
            this.txtLayoutHeight = new System.Windows.Forms.TextBox();
            this.numCopies = new System.Windows.Forms.NumericUpDown();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.chkStepRepeat = new System.Windows.Forms.CheckBox();

            this.lblOriginalFile = new System.Windows.Forms.Label();
            this.lblLayoutWidth = new System.Windows.Forms.Label();
            this.lblLayoutHeight = new System.Windows.Forms.Label();
            this.lblCopies = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblStepRepeat = new System.Windows.Forms.Label();

            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();

            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeStatusMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.gridJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCopies)).BeginInit();
            this.SuspendLayout();

            // --- MenuStrip ---
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.fileMenu, this.toolsMenu, this.helpMenu});
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Top;

            this.fileMenu.Text = "File";
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.openFileMenuItem, this.exitMenuItem});
            this.toolsMenu.Text = "Tools";
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.changeStatusMenuItem});
            this.helpMenu.Text = "Help";
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.aboutMenuItem });

            this.openFileMenuItem.Text = "Open File";
            this.openFileMenuItem.Click += new System.EventHandler(this.OpenFile_Click);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.Exit_Click);
            this.changeStatusMenuItem.Text = "Change Status";
            this.changeStatusMenuItem.Click += new System.EventHandler(this.ChangeStatus_Click);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.About_Click);

            // --- SplitContainer ---
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.splitContainer.SplitterDistance = 700;

            // --- Panel1: grid ---
            this.gridJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridJobs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridJobs.ReadOnly = true;
            this.gridJobs.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Job Name", DataPropertyName = "Name" });
            this.gridJobs.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Original File", DataPropertyName = "OriginalFileName" });
            this.gridJobs.Columns.Add(new System.Windows.Forms.DataGridViewCheckBoxColumn { HeaderText = "Is Hold", DataPropertyName = "IsHold" });
            this.gridJobs.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Layout Width", DataPropertyName = "LayoutWidth" });
            this.gridJobs.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Layout Height", DataPropertyName = "LayoutHeight" });
            this.gridJobs.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Copies", DataPropertyName = "Copies" });
            this.gridJobs.Columns.Add(new System.Windows.Forms.DataGridViewCheckBoxColumn { HeaderText = "Step Repeat Enabled", DataPropertyName = "StepRepeatEnabled" });
            this.gridJobs.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Comment", DataPropertyName = "Comment" });
            this.gridJobs.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Added Date", DataPropertyName = "CreatedAt" });
            this.splitContainer.Panel1.Controls.Add(this.gridJobs);

            // --- Panel2 (prawy) ---
            int top = 10;
            int labelWidth = 120;
            int offsetX = 10;

            // Preview
            this.previewBox.Location = new System.Drawing.Point(10, top);
            this.previewBox.Size = new System.Drawing.Size(300, 200);
            this.previewBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.splitContainer.Panel2.Controls.Add(this.previewBox);
            //top += 210;

            // Original File
            this.lblOriginalFile.Text = "Original File:";
            this.lblOriginalFile.Location = new System.Drawing.Point(10, top);
            this.lblOriginalFile.Width = labelWidth;
            this.splitContainer.Panel2.Controls.Add(this.lblOriginalFile);

            this.txtOriginalFile.Location = new System.Drawing.Point(10 + labelWidth + offsetX, top);
            this.txtOriginalFile.Width = 200;
            this.splitContainer.Panel2.Controls.Add(this.txtOriginalFile);

            // Layout Width
            this.lblLayoutWidth.Text = "Layout Width:";
            this.lblLayoutWidth.Location = new System.Drawing.Point(10, top);
            this.lblLayoutWidth.Width = labelWidth;
            this.splitContainer.Panel2.Controls.Add(this.lblLayoutWidth);

            this.txtLayoutWidth.Location = new System.Drawing.Point(10 + labelWidth + offsetX, top);
            this.txtLayoutWidth.Width = 100;
            this.splitContainer.Panel2.Controls.Add(this.txtLayoutWidth);

            // Layout Height
            this.lblLayoutHeight.Text = "Layout Height:";
            this.lblLayoutHeight.Location = new System.Drawing.Point(10, top);
            this.lblLayoutHeight.Width = labelWidth;
            this.splitContainer.Panel2.Controls.Add(this.lblLayoutHeight);

            this.txtLayoutHeight.Location = new System.Drawing.Point(10 + labelWidth + offsetX, top);
            this.txtLayoutHeight.Width = 100;
            this.splitContainer.Panel2.Controls.Add(this.txtLayoutHeight);

            // Copies
            this.lblCopies.Text = "Copies:";
            this.lblCopies.Location = new System.Drawing.Point(10, top);
            this.lblCopies.Width = labelWidth;
            this.splitContainer.Panel2.Controls.Add(this.lblCopies);

            this.numCopies.Location = new System.Drawing.Point(10 + labelWidth + offsetX, top);
            this.numCopies.Width = 60;
            this.splitContainer.Panel2.Controls.Add(this.numCopies);

            this.lblComment.Text = "Comment:";
            this.lblComment.Location = new System.Drawing.Point(10, top);
            this.lblComment.Width = labelWidth;
            this.splitContainer.Panel2.Controls.Add(this.lblComment);

            this.txtComment.Location = new System.Drawing.Point(10 + labelWidth + offsetX, top);
            this.txtComment.Width = 200;
            this.txtComment.Height = 60;
            this.txtComment.Multiline = true;
            this.splitContainer.Panel2.Controls.Add(this.txtComment);

            // Step & Repeat
            this.lblStepRepeat.Text = "Step & Repeat:";
            this.lblStepRepeat.Location = new System.Drawing.Point(10, top);
            this.lblStepRepeat.Width = labelWidth;
            this.splitContainer.Panel2.Controls.Add(this.lblStepRepeat);

            this.chkStepRepeat.Location = new System.Drawing.Point(10 + labelWidth + offsetX, top + 3);
            this.splitContainer.Panel2.Controls.Add(this.chkStepRepeat);

            // --- Form ---
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Text = "EEPrintViewer";

            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCopies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
