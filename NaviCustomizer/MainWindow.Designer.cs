namespace NaviCustomizer
{
    partial class MainWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainGrid = new System.Windows.Forms.DataGridView();
            this.pieceList = new System.Windows.Forms.ListBox();
            this.chooseLabel = new System.Windows.Forms.Label();
            this.editPieceBtn = new System.Windows.Forms.Button();
            this.deletePieceBtn = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewPieceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearNaviCustomizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllPiecesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBugsBtn = new System.Windows.Forms.Button();
            this.colorLine = new System.Windows.Forms.DataGridView();
            this.colorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainGrid)).BeginInit();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorLine)).BeginInit();
            this.SuspendLayout();
            // 
            // mainGrid
            // 
            this.mainGrid.AllowUserToAddRows = false;
            this.mainGrid.AllowUserToDeleteRows = false;
            this.mainGrid.AllowUserToResizeColumns = false;
            this.mainGrid.AllowUserToResizeRows = false;
            this.mainGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mainGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainGrid.ColumnHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mainGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.mainGrid.Location = new System.Drawing.Point(24, 66);
            this.mainGrid.MultiSelect = false;
            this.mainGrid.Name = "mainGrid";
            this.mainGrid.ReadOnly = true;
            this.mainGrid.RowHeadersVisible = false;
            this.mainGrid.RowTemplate.Height = 40;
            this.mainGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mainGrid.Size = new System.Drawing.Size(200, 200);
            this.mainGrid.TabIndex = 0;
            this.mainGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainGrid_CellClick);
            this.mainGrid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainGrid_CellMouseEnter);
            this.mainGrid.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainGrid_CellMouseLeave);
            this.mainGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainGrid_KeyDown);
            this.mainGrid.MouseEnter += new System.EventHandler(this.mainGrid_MouseEnter);
            this.mainGrid.MouseLeave += new System.EventHandler(this.mainGrid_MouseLeave);
            // 
            // pieceList
            // 
            this.pieceList.FormattingEnabled = true;
            this.pieceList.Location = new System.Drawing.Point(308, 33);
            this.pieceList.Name = "pieceList";
            this.pieceList.Size = new System.Drawing.Size(120, 160);
            this.pieceList.TabIndex = 2;
            this.pieceList.SelectedIndexChanged += new System.EventHandler(this.pieceList_SelectedIndexChanged);
            // 
            // chooseLabel
            // 
            this.chooseLabel.AutoSize = true;
            this.chooseLabel.Location = new System.Drawing.Point(305, 17);
            this.chooseLabel.Name = "chooseLabel";
            this.chooseLabel.Size = new System.Drawing.Size(118, 13);
            this.chooseLabel.TabIndex = 3;
            this.chooseLabel.Text = "Select a piece to insert:";
            // 
            // editPieceBtn
            // 
            this.editPieceBtn.Location = new System.Drawing.Point(308, 200);
            this.editPieceBtn.Name = "editPieceBtn";
            this.editPieceBtn.Size = new System.Drawing.Size(120, 23);
            this.editPieceBtn.TabIndex = 4;
            this.editPieceBtn.Text = "Edit Selected Piece";
            this.editPieceBtn.UseVisualStyleBackColor = true;
            this.editPieceBtn.Click += new System.EventHandler(this.editPieceBtn_Click);
            // 
            // deletePieceBtn
            // 
            this.deletePieceBtn.Location = new System.Drawing.Point(308, 229);
            this.deletePieceBtn.Name = "deletePieceBtn";
            this.deletePieceBtn.Size = new System.Drawing.Size(131, 23);
            this.deletePieceBtn.TabIndex = 5;
            this.deletePieceBtn.Text = "Delete Selected Piece";
            this.deletePieceBtn.UseVisualStyleBackColor = true;
            this.deletePieceBtn.Click += new System.EventHandler(this.deletePieceBtn_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(449, 24);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewPieceToolStripMenuItem,
            this.clearNaviCustomizerToolStripMenuItem,
            this.deleteAllPiecesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createNewPieceToolStripMenuItem
            // 
            this.createNewPieceToolStripMenuItem.Name = "createNewPieceToolStripMenuItem";
            this.createNewPieceToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.createNewPieceToolStripMenuItem.Text = "Create New Piece";
            this.createNewPieceToolStripMenuItem.Click += new System.EventHandler(this.createNewPieceToolStripMenuItem_Click);
            // 
            // clearNaviCustomizerToolStripMenuItem
            // 
            this.clearNaviCustomizerToolStripMenuItem.Name = "clearNaviCustomizerToolStripMenuItem";
            this.clearNaviCustomizerToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.clearNaviCustomizerToolStripMenuItem.Text = "Clear Navi Customizer";
            this.clearNaviCustomizerToolStripMenuItem.Click += new System.EventHandler(this.clearNaviCustomizerToolStripMenuItem_Click);
            // 
            // deleteAllPiecesToolStripMenuItem
            // 
            this.deleteAllPiecesToolStripMenuItem.Name = "deleteAllPiecesToolStripMenuItem";
            this.deleteAllPiecesToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.deleteAllPiecesToolStripMenuItem.Text = "Delete All Pieces";
            this.deleteAllPiecesToolStripMenuItem.Click += new System.EventHandler(this.deleteAllPiecesToolStripMenuItem_Click);
            // 
            // checkBugsBtn
            // 
            this.checkBugsBtn.Location = new System.Drawing.Point(174, 285);
            this.checkBugsBtn.Name = "checkBugsBtn";
            this.checkBugsBtn.Size = new System.Drawing.Size(96, 23);
            this.checkBugsBtn.TabIndex = 7;
            this.checkBugsBtn.Text = "Check For Bugs";
            this.checkBugsBtn.UseVisualStyleBackColor = true;
            this.checkBugsBtn.Click += new System.EventHandler(this.checkBugsBtn_Click);
            // 
            // colorLine
            // 
            this.colorLine.AllowUserToAddRows = false;
            this.colorLine.AllowUserToDeleteRows = false;
            this.colorLine.AllowUserToResizeColumns = false;
            this.colorLine.AllowUserToResizeRows = false;
            this.colorLine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.colorLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.colorLine.ColumnHeadersVisible = false;
            this.colorLine.Location = new System.Drawing.Point(144, 33);
            this.colorLine.MultiSelect = false;
            this.colorLine.Name = "colorLine";
            this.colorLine.ReadOnly = true;
            this.colorLine.RowHeadersVisible = false;
            this.colorLine.RowHeadersWidth = 20;
            this.colorLine.RowTemplate.Height = 20;
            this.colorLine.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.colorLine.Size = new System.Drawing.Size(80, 20);
            this.colorLine.TabIndex = 8;
            this.colorLine.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.colorLine_CellContentClick);
            this.colorLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.colorLine_KeyDown);
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorLabel.Location = new System.Drawing.Point(51, 33);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(87, 20);
            this.colorLabel.TabIndex = 9;
            this.colorLabel.Text = "COLORS:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 320);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.colorLine);
            this.Controls.Add(this.checkBugsBtn);
            this.Controls.Add(this.deletePieceBtn);
            this.Controls.Add(this.editPieceBtn);
            this.Controls.Add(this.chooseLabel);
            this.Controls.Add(this.pieceList);
            this.Controls.Add(this.mainGrid);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Navi Customizer";
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.Click += new System.EventHandler(this.MainWindow_Click);
            ((System.ComponentModel.ISupportInitialize)(this.mainGrid)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mainGrid;
        private System.Windows.Forms.ListBox pieceList;
        private System.Windows.Forms.Label chooseLabel;
        private System.Windows.Forms.Button editPieceBtn;
        private System.Windows.Forms.Button deletePieceBtn;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewPieceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearNaviCustomizerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllPiecesToolStripMenuItem;
        private System.Windows.Forms.Button checkBugsBtn;
        private System.Windows.Forms.DataGridView colorLine;
        private System.Windows.Forms.Label colorLabel;
    }
}

