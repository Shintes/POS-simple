namespace WindowsFormsApp1
{
    partial class MeniuStoc1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Searchprod = new MetroFramework.Controls.MetroTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantitate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.Searchprod);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 30);
            this.panel1.TabIndex = 2;
            // 
            // Searchprod
            // 
            this.Searchprod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Searchprod.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.Searchprod.CustomButton.Image = null;
            this.Searchprod.CustomButton.Location = new System.Drawing.Point(639, 1);
            this.Searchprod.CustomButton.Name = "";
            this.Searchprod.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.Searchprod.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Searchprod.CustomButton.TabIndex = 1;
            this.Searchprod.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Searchprod.CustomButton.UseSelectable = true;
            this.Searchprod.CustomButton.Visible = false;
            this.Searchprod.Icon = global::WindowsFormsApp1.Properties.Resources.searchpng_com_search_icon_png_image_free_download_6;
            this.Searchprod.Lines = new string[0];
            this.Searchprod.Location = new System.Drawing.Point(3, 4);
            this.Searchprod.MaxLength = 32767;
            this.Searchprod.Name = "Searchprod";
            this.Searchprod.PasswordChar = '\0';
            this.Searchprod.PromptText = "Cauta aici produs";
            this.Searchprod.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Searchprod.SelectedText = "";
            this.Searchprod.SelectionLength = 0;
            this.Searchprod.SelectionStart = 0;
            this.Searchprod.ShortcutsEnabled = true;
            this.Searchprod.Size = new System.Drawing.Size(661, 23);
            this.Searchprod.TabIndex = 18;
            this.Searchprod.UseSelectable = true;
            this.Searchprod.WaterMark = "Cauta aici produs";
            this.Searchprod.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Searchprod.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Searchprod.TextChanged += new System.EventHandler(this.Searchprod_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.Arrow_XRight_icon;
            this.pictureBox1.Location = new System.Drawing.Point(670, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Data,
            this.Data1,
            this.Produs,
            this.Cantitate,
            this.Select});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(704, 482);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Data
            // 
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Data.HeaderText = "Key";
            this.Data.Name = "Data";
            this.Data.Visible = false;
            this.Data.Width = 48;
            // 
            // Data1
            // 
            this.Data1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Data1.FillWeight = 172.2201F;
            this.Data1.HeaderText = "Cod Bare";
            this.Data1.Name = "Data1";
            this.Data1.Width = 72;
            // 
            // Produs
            // 
            this.Produs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Produs.HeaderText = "Produs";
            this.Produs.Name = "Produs";
            // 
            // Cantitate
            // 
            this.Cantitate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cantitate.HeaderText = "Cantitate";
            this.Cantitate.Name = "Cantitate";
            this.Cantitate.Width = 84;
            // 
            // Select
            // 
            this.Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Select.FillWeight = 27.78192F;
            this.Select.HeaderText = "";
            this.Select.Image = global::WindowsFormsApp1.Properties.Resources.edit1;
            this.Select.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Select.Name = "Select";
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Select.Width = 5;
            // 
            // MeniuStoc1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 513);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MeniuStoc1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantitate;
        private System.Windows.Forms.DataGridViewImageColumn Select;
        private MetroFramework.Controls.MetroTextBox Searchprod;
    }
}