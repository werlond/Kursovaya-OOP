namespace Kursik
{
    partial class StartForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.lblProgramTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadDb = new System.Windows.Forms.Button();
            this.btnCreateDb = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblRecent = new System.Windows.Forms.Label();
            this.lnkClearRecent = new System.Windows.Forms.Label();
            this.lstRecent = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.picBackground.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBackground
            // 
            this.picBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.picBackground.Controls.Add(this.lblProgramTitle);
            this.picBackground.Controls.Add(this.lblSubtitle);
            this.picBackground.Controls.Add(this.pnlButtons);
            this.picBackground.Controls.Add(this.pnlInfo);
            this.picBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBackground.Image = global::Kursik.Properties.Resources.start_background;
            this.picBackground.Location = new System.Drawing.Point(0, 0);
            this.picBackground.Margin = new System.Windows.Forms.Padding(2);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(675, 422);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackground.TabIndex = 0;
            this.picBackground.TabStop = false;
            // 
            // lblProgramTitle
            // 
            this.lblProgramTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblProgramTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblProgramTitle.ForeColor = System.Drawing.Color.White;
            this.lblProgramTitle.Location = new System.Drawing.Point(15, 16);
            this.lblProgramTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProgramTitle.Name = "lblProgramTitle";
            this.lblProgramTitle.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblProgramTitle.Size = new System.Drawing.Size(450, 41);
            this.lblProgramTitle.TabIndex = 1;
            this.lblProgramTitle.Text = "ИС «Фестиваль фильмов»";
            this.lblProgramTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Silver;
            this.lblSubtitle.Location = new System.Drawing.Point(15, 62);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(383, 18);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Информационная система учёта фильмов кинофестиваля";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlButtons.BackColor = System.Drawing.Color.Transparent;
            this.pnlButtons.Controls.Add(this.btnLoadDb);
            this.pnlButtons.Controls.Add(this.btnCreateDb);
            this.pnlButtons.Controls.Add(this.btnExit);
            this.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlButtons.Location = new System.Drawing.Point(22, 227);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(2);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlButtons.Size = new System.Drawing.Size(224, 173);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnLoadDb
            // 
            this.btnLoadDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadDb.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadDb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLoadDb.Location = new System.Drawing.Point(8, 10);
            this.btnLoadDb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoadDb.Name = "btnLoadDb";
            this.btnLoadDb.Size = new System.Drawing.Size(181, 42);
            this.btnLoadDb.TabIndex = 2;
            this.btnLoadDb.Text = "Открыть существующую БД";
            this.btnLoadDb.UseVisualStyleBackColor = false;
            this.btnLoadDb.Click += new System.EventHandler(this.btnLoadDb_Click);
            // 
            // btnCreateDb
            // 
            this.btnCreateDb.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateDb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCreateDb.Location = new System.Drawing.Point(8, 62);
            this.btnCreateDb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreateDb.Name = "btnCreateDb";
            this.btnCreateDb.Size = new System.Drawing.Size(120, 42);
            this.btnCreateDb.TabIndex = 1;
            this.btnCreateDb.Text = "Создать новую БД";
            this.btnCreateDb.UseVisualStyleBackColor = false;
            this.btnCreateDb.Click += new System.EventHandler(this.btnCreateDb_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExit.Location = new System.Drawing.Point(8, 114);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 42);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlInfo.Controls.Add(this.lblRecent);
            this.pnlInfo.Controls.Add(this.lnkClearRecent);
            this.pnlInfo.Controls.Add(this.lstRecent);
            this.pnlInfo.Location = new System.Drawing.Point(308, 174);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Padding = new System.Windows.Forms.Padding(12);
            this.pnlInfo.Size = new System.Drawing.Size(355, 226);
            this.pnlInfo.TabIndex = 4;
            // 
            // lblRecent
            // 
            this.lblRecent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRecent.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRecent.Location = new System.Drawing.Point(15, 12);
            this.lblRecent.Name = "lblRecent";
            this.lblRecent.Size = new System.Drawing.Size(185, 20);
            this.lblRecent.TabIndex = 2;
            this.lblRecent.Text = "Недавние базы";
            //
            // lnkClearRecent
            //
            this.lnkClearRecent.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lnkClearRecent.ForeColor = System.Drawing.Color.Silver;
            this.lnkClearRecent.Location = new System.Drawing.Point(203, 13);
            this.lnkClearRecent.Name = "lnkClearRecent";
            this.lnkClearRecent.Size = new System.Drawing.Size(120, 18);
            this.lnkClearRecent.TabIndex = 4;
            this.lnkClearRecent.Text = "Очистить список";
            this.lnkClearRecent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkClearRecent.Click += new System.EventHandler(this.lnkClearRecent_LinkClicked);
            //
            // lstRecent
            // 
            this.lstRecent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRecent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.lstRecent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRecent.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lstRecent.Items.AddRange(new object[] {
            "(пусто)"});
            this.lstRecent.Location = new System.Drawing.Point(15, 35);
            this.lstRecent.Name = "lstRecent";
            this.lstRecent.Size = new System.Drawing.Size(330, 184);
            this.lstRecent.TabIndex = 3;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 422);
            this.Controls.Add(this.picBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Фестиваль фильмов — главное меню";
            this.Shown += new System.EventHandler(this.StartForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.picBackground.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBackground;
        private System.Windows.Forms.Label lblProgramTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnCreateDb;
        private System.Windows.Forms.Button btnLoadDb;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblRecent;
        private System.Windows.Forms.Label lnkClearRecent;
        private System.Windows.Forms.ListBox lstRecent;
    }
}
