namespace WindowsFormsApp1
{
    partial class cantitate
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
            this.cantitate1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cantitate1
            // 
            this.cantitate1.Location = new System.Drawing.Point(0, 0);
            this.cantitate1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cantitate1.Name = "cantitate1";
            this.cantitate1.Size = new System.Drawing.Size(267, 64);
            this.cantitate1.TabIndex = 0;
            this.cantitate1.Text = "";
            this.cantitate1.TextChanged += new System.EventHandler(this.cantitate1_TextChanged);
            this.cantitate1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cantitate1_KeyPress);
            // 
            // cantitate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 64);
            this.Controls.Add(this.cantitate1);
            this.Font = new System.Drawing.Font("MS Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "cantitate";
            this.Text = "cantitate";
            this.Load += new System.EventHandler(this.cantitate_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox cantitate1;
    }
}