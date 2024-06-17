﻿namespace CineVerse.Views.UserControls
{
    partial class MovieCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMovieTitle = new Label();
            pnMoviePoster = new Panel();
            pnActions = new Panel();
            btnLike = new Button();
            btnMore = new Button();
            btnWatch = new Button();
            pnMoviePoster.SuspendLayout();
            pnActions.SuspendLayout();
            SuspendLayout();
            // 
            // lblMovieTitle
            // 
            lblMovieTitle.Dock = DockStyle.Bottom;
            lblMovieTitle.Font = new Font("Segoe UI", 10F);
            lblMovieTitle.ForeColor = Color.White;
            lblMovieTitle.Location = new Point(0, 206);
            lblMovieTitle.Name = "lblMovieTitle";
            lblMovieTitle.Size = new Size(228, 30);
            lblMovieTitle.TabIndex = 1;
            lblMovieTitle.Text = "Furiosa";
            lblMovieTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnMoviePoster
            // 
            pnMoviePoster.BackColor = Color.FromArgb(13, 15, 16);
            pnMoviePoster.Controls.Add(pnActions);
            pnMoviePoster.Dock = DockStyle.Fill;
            pnMoviePoster.Location = new Point(0, 0);
            pnMoviePoster.Name = "pnMoviePoster";
            pnMoviePoster.Size = new Size(228, 206);
            pnMoviePoster.TabIndex = 2;
            // 
            // pnActions
            // 
            pnActions.Anchor = AnchorStyles.Bottom;
            pnActions.BackColor = Color.FromArgb(20, 20, 20);
            pnActions.Controls.Add(btnLike);
            pnActions.Controls.Add(btnMore);
            pnActions.Controls.Add(btnWatch);
            pnActions.Location = new Point(54, 168);
            pnActions.Name = "pnActions";
            pnActions.Size = new Size(118, 34);
            pnActions.TabIndex = 0;
            // 
            // btnLike
            // 
            btnLike.BackColor = Color.Transparent;
            btnLike.Dock = DockStyle.Fill;
            btnLike.FlatAppearance.BorderSize = 0;
            btnLike.FlatStyle = FlatStyle.Flat;
            btnLike.Image = Properties.Resources.love;
            btnLike.Location = new Point(38, 0);
            btnLike.Name = "btnLike";
            btnLike.Size = new Size(42, 34);
            btnLike.TabIndex = 3;
            btnLike.UseVisualStyleBackColor = false;
            // 
            // btnMore
            // 
            btnMore.BackColor = Color.Transparent;
            btnMore.Dock = DockStyle.Right;
            btnMore.FlatAppearance.BorderSize = 0;
            btnMore.FlatStyle = FlatStyle.Flat;
            btnMore.Image = Properties.Resources.more;
            btnMore.Location = new Point(80, 0);
            btnMore.Name = "btnMore";
            btnMore.Size = new Size(38, 34);
            btnMore.TabIndex = 2;
            btnMore.UseVisualStyleBackColor = false;
            // 
            // btnWatch
            // 
            btnWatch.BackColor = Color.Transparent;
            btnWatch.Dock = DockStyle.Left;
            btnWatch.FlatAppearance.BorderSize = 0;
            btnWatch.FlatStyle = FlatStyle.Flat;
            btnWatch.Image = Properties.Resources.watch;
            btnWatch.Location = new Point(0, 0);
            btnWatch.Name = "btnWatch";
            btnWatch.Size = new Size(38, 34);
            btnWatch.TabIndex = 0;
            btnWatch.UseVisualStyleBackColor = false;
            // 
            // MovieCard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(19, 20, 26);
            Controls.Add(pnMoviePoster);
            Controls.Add(lblMovieTitle);
            Name = "MovieCard";
            Size = new Size(228, 236);
            pnMoviePoster.ResumeLayout(false);
            pnActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label lblMovieTitle;
        private Panel pnMoviePoster;
        private Panel pnActions;
        private Button btnLike;
        private Button btnMore;
        private Button btnWatch;
    }
}
