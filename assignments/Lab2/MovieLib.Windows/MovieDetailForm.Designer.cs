namespace MovieLib.Windows {
    partial class MovieDetailForm {
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
			this.label1 = new System.Windows.Forms.Label();
			this._txtTitle = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this._txtDescription = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this._txtLength = new System.Windows.Forms.TextBox();
			this._chkOwned = new System.Windows.Forms.CheckBox();
			this._btnSave = new System.Windows.Forms.Button();
			this._btnCancel = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(45, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Title";
			// 
			// _txtTitle
			// 
			this._txtTitle.Location = new System.Drawing.Point(78, 12);
			this._txtTitle.Name = "_txtTitle";
			this._txtTitle.Size = new System.Drawing.Size(361, 20);
			this._txtTitle.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Description";
			// 
			// _txtDescription
			// 
			this._txtDescription.Location = new System.Drawing.Point(78, 38);
			this._txtDescription.Multiline = true;
			this._txtDescription.Name = "_txtDescription";
			this._txtDescription.Size = new System.Drawing.Size(361, 101);
			this._txtDescription.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(32, 148);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Length";
			// 
			// _txtLength
			// 
			this._txtLength.Location = new System.Drawing.Point(78, 145);
			this._txtLength.Name = "_txtLength";
			this._txtLength.Size = new System.Drawing.Size(100, 20);
			this._txtLength.TabIndex = 5;
			// 
			// _chkOwned
			// 
			this._chkOwned.AutoSize = true;
			this._chkOwned.Location = new System.Drawing.Point(78, 171);
			this._chkOwned.Name = "_chkOwned";
			this._chkOwned.Size = new System.Drawing.Size(60, 17);
			this._chkOwned.TabIndex = 6;
			this._chkOwned.Text = "Owned";
			this._chkOwned.UseVisualStyleBackColor = true;
			// 
			// _btnSave
			// 
			this._btnSave.Location = new System.Drawing.Point(283, 195);
			this._btnSave.Name = "_btnSave";
			this._btnSave.Size = new System.Drawing.Size(75, 23);
			this._btnSave.TabIndex = 7;
			this._btnSave.Text = "Save";
			this._btnSave.UseVisualStyleBackColor = true;
			this._btnSave.Click += new System.EventHandler(this.OnSave);
			// 
			// _btnCancel
			// 
			this._btnCancel.Location = new System.Drawing.Point(364, 195);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 23);
			this._btnCancel.TabIndex = 8;
			this._btnCancel.Text = "Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			this._btnCancel.Click += new System.EventHandler(this.OnCancel);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(184, 148);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "minutes";
			// 
			// MovieDetailForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(463, 235);
			this.Controls.Add(this.label4);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnSave);
			this.Controls.Add(this._chkOwned);
			this.Controls.Add(this._txtLength);
			this.Controls.Add(this.label3);
			this.Controls.Add(this._txtDescription);
			this.Controls.Add(this.label2);
			this.Controls.Add(this._txtTitle);
			this.Controls.Add(this.label1);
			this.Name = "MovieDetailForm";
			this.Text = "Movie Details";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _txtLength;
        private System.Windows.Forms.CheckBox _chkOwned;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Label label4;
    }
}