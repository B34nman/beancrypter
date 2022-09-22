namespace BeanCrypter_File
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.file_select = new System.Windows.Forms.Button();
            this.file_path = new System.Windows.Forms.TextBox();
            this.decrypt = new System.Windows.Forms.Button();
            this.encrypt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // file_select
            // 
            resources.ApplyResources(this.file_select, "file_select");
            this.file_select.BackColor = System.Drawing.Color.Gray;
            this.file_select.Name = "file_select";
            this.file_select.UseVisualStyleBackColor = false;
            this.file_select.Click += new System.EventHandler(this.file_select_Click);
            // 
            // file_path
            // 
            resources.ApplyResources(this.file_path, "file_path");
            this.file_path.BackColor = System.Drawing.Color.White;
            this.file_path.Name = "file_path";
            // 
            // decrypt
            // 
            resources.ApplyResources(this.decrypt, "decrypt");
            this.decrypt.BackColor = System.Drawing.Color.Gray;
            this.decrypt.Name = "decrypt";
            this.decrypt.UseVisualStyleBackColor = false;
            this.decrypt.Click += new System.EventHandler(this.decrypt_Click);
            // 
            // encrypt
            // 
            resources.ApplyResources(this.encrypt, "encrypt");
            this.encrypt.BackColor = System.Drawing.Color.Gray;
            this.encrypt.Name = "encrypt";
            this.encrypt.UseVisualStyleBackColor = false;
            this.encrypt.Click += new System.EventHandler(this.encrypt_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Name = "label2";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.Black;
            this.CausesValidation = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.file_path);
            this.Controls.Add(this.encrypt);
            this.Controls.Add(this.decrypt);
            this.Controls.Add(this.file_select);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button file_select;
        private System.Windows.Forms.TextBox file_path;
        private System.Windows.Forms.Button decrypt;
        private System.Windows.Forms.Button encrypt;
        private System.Windows.Forms.Label label2;
    }
}

