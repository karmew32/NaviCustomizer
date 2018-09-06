namespace NaviCustomizer
{
    partial class PieceEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.editorGrid = new System.Windows.Forms.DataGridView();
            this.colorLabel = new System.Windows.Forms.Label();
            this.textureCheck = new System.Windows.Forms.CheckBox();
            this.colorDropDown = new System.Windows.Forms.ComboBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.createPieceBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.editorGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // editorGrid
            // 
            this.editorGrid.AllowUserToAddRows = false;
            this.editorGrid.AllowUserToDeleteRows = false;
            this.editorGrid.AllowUserToResizeColumns = false;
            this.editorGrid.AllowUserToResizeRows = false;
            this.editorGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.editorGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.editorGrid.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.editorGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.editorGrid.Location = new System.Drawing.Point(22, 12);
            this.editorGrid.MultiSelect = false;
            this.editorGrid.Name = "editorGrid";
            this.editorGrid.ReadOnly = true;
            this.editorGrid.RowHeadersVisible = false;
            this.editorGrid.RowTemplate.Height = 40;
            this.editorGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.editorGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.editorGrid.Size = new System.Drawing.Size(200, 200);
            this.editorGrid.TabIndex = 0;
            this.editorGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.editorGrid_CellClick);
            this.editorGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editorGrid_KeyDown);
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(267, 65);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(34, 13);
            this.colorLabel.TabIndex = 1;
            this.colorLabel.Text = "Color:";
            // 
            // textureCheck
            // 
            this.textureCheck.AutoSize = true;
            this.textureCheck.Location = new System.Drawing.Point(307, 110);
            this.textureCheck.Name = "textureCheck";
            this.textureCheck.Size = new System.Drawing.Size(68, 17);
            this.textureCheck.TabIndex = 2;
            this.textureCheck.Text = "Textured";
            this.textureCheck.UseVisualStyleBackColor = true;
            this.textureCheck.CheckedChanged += new System.EventHandler(this.textureCheck_CheckedChanged);
            // 
            // colorDropDown
            // 
            this.colorDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorDropDown.FormattingEnabled = true;
            this.colorDropDown.Location = new System.Drawing.Point(307, 62);
            this.colorDropDown.Name = "colorDropDown";
            this.colorDropDown.Size = new System.Drawing.Size(121, 21);
            this.colorDropDown.TabIndex = 3;
            this.colorDropDown.SelectedIndexChanged += new System.EventHandler(this.colorDropDown_SelectedIndexChanged);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(307, 26);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 20);
            this.nameBox.TabIndex = 4;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(266, 29);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 5;
            this.nameLabel.Text = "Name:";
            // 
            // createPieceBtn
            // 
            this.createPieceBtn.Location = new System.Drawing.Point(307, 205);
            this.createPieceBtn.Name = "createPieceBtn";
            this.createPieceBtn.Size = new System.Drawing.Size(100, 23);
            this.createPieceBtn.TabIndex = 6;
            this.createPieceBtn.Text = "Create Piece";
            this.createPieceBtn.UseVisualStyleBackColor = true;
            this.createPieceBtn.Click += new System.EventHandler(this.createPieceBtn_Click);
            // 
            // PieceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 262);
            this.Controls.Add(this.createPieceBtn);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.colorDropDown);
            this.Controls.Add(this.textureCheck);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.editorGrid);
            this.Name = "PieceEditor";
            this.Text = "Piece Editor";
            this.Load += new System.EventHandler(this.PieceEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.editorGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView editorGrid;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.CheckBox textureCheck;
        private System.Windows.Forms.ComboBox colorDropDown;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button createPieceBtn;
    }
}