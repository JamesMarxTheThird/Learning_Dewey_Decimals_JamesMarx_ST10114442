
namespace Learning_Dewey_Decimals_JamesMarx_ST10114442
{
    partial class Book_Areas
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
            this.button2 = new System.Windows.Forms.Button();
            this.BA_HomeB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Image = global::Learning_Dewey_Decimals_JamesMarx_ST10114442.Properties.Resources.reseticon;
            this.button2.Location = new System.Drawing.Point(75, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 45);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // BA_HomeB
            // 
            this.BA_HomeB.Image = global::Learning_Dewey_Decimals_JamesMarx_ST10114442.Properties.Resources.homeiconyuh;
            this.BA_HomeB.Location = new System.Drawing.Point(12, 12);
            this.BA_HomeB.Name = "BA_HomeB";
            this.BA_HomeB.Size = new System.Drawing.Size(47, 45);
            this.BA_HomeB.TabIndex = 0;
            this.BA_HomeB.UseVisualStyleBackColor = true;
            this.BA_HomeB.Click += new System.EventHandler(this.BA_HomeB_Click);
            // 
            // Book_Areas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BA_HomeB);
            this.Name = "Book_Areas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book_Areas";
            this.Load += new System.EventHandler(this.Book_Areas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BA_HomeB;
        private System.Windows.Forms.Button button2;
    }
}