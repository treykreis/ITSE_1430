﻿namespace MovieLib.Windows {
    partial class MainForm {
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._miFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.moviesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._miMovieAdd = new System.Windows.Forms.ToolStripMenuItem();
			this._miMovieEdit = new System.Windows.Forms.ToolStripMenuItem();
			this._miMovieDelete = new System.Windows.Forms.ToolStripMenuItem();
			this._miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.moviesToolStripMenuItem,
            this._miHelpAbout});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(684, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miFileExit});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// _miFileExit
			// 
			this._miFileExit.Name = "_miFileExit";
			this._miFileExit.Size = new System.Drawing.Size(92, 22);
			this._miFileExit.Text = "E&xit";
			this._miFileExit.Click += new System.EventHandler(this.OnFileExit);
			// 
			// moviesToolStripMenuItem
			// 
			this.moviesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miMovieAdd,
            this._miMovieEdit,
            this._miMovieDelete});
			this.moviesToolStripMenuItem.Name = "moviesToolStripMenuItem";
			this.moviesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.moviesToolStripMenuItem.Text = "&Movies";
			// 
			// _miMovieAdd
			// 
			this._miMovieAdd.Name = "_miMovieAdd";
			this._miMovieAdd.Size = new System.Drawing.Size(107, 22);
			this._miMovieAdd.Text = "&Add";
			this._miMovieAdd.Click += new System.EventHandler(this.OnMovieAdd);
			// 
			// _miMovieEdit
			// 
			this._miMovieEdit.Name = "_miMovieEdit";
			this._miMovieEdit.Size = new System.Drawing.Size(107, 22);
			this._miMovieEdit.Text = "&Edit";
			this._miMovieEdit.Click += new System.EventHandler(this.OnMovieEdit);
			// 
			// _miMovieDelete
			// 
			this._miMovieDelete.Name = "_miMovieDelete";
			this._miMovieDelete.Size = new System.Drawing.Size(107, 22);
			this._miMovieDelete.Text = "&Delete";
			this._miMovieDelete.Click += new System.EventHandler(this.OnMovieDelete);
			// 
			// _miHelpAbout
			// 
			this._miHelpAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this._miHelpAbout.Name = "_miHelpAbout";
			this._miHelpAbout.Size = new System.Drawing.Size(44, 20);
			this._miHelpAbout.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnHelpAbout);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 361);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Movie Library";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _miFileExit;
        private System.Windows.Forms.ToolStripMenuItem moviesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _miMovieAdd;
        private System.Windows.Forms.ToolStripMenuItem _miMovieEdit;
        private System.Windows.Forms.ToolStripMenuItem _miMovieDelete;
        private System.Windows.Forms.ToolStripMenuItem _miHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

