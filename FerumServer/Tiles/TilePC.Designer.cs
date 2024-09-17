namespace FerumServer.Tiles
{
    partial class TilePC
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lStatus = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.форматироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.майнитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выключитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lVersion = new System.Windows.Forms.Label();
            this.icPlay = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lStatus.Location = new System.Drawing.Point(114, 10);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(59, 20);
            this.lStatus.TabIndex = 2;
            this.lStatus.Text = "В сети";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.форматироватьToolStripMenuItem,
            this.майнитьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.выключитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(194, 92);
            // 
            // форматироватьToolStripMenuItem
            // 
            this.форматироватьToolStripMenuItem.Name = "форматироватьToolStripMenuItem";
            this.форматироватьToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.форматироватьToolStripMenuItem.Text = "Открыть калькулятор";
            this.форматироватьToolStripMenuItem.Click += new System.EventHandler(this.форматироватьToolStripMenuItem_Click);
            // 
            // майнитьToolStripMenuItem
            // 
            this.майнитьToolStripMenuItem.Name = "майнитьToolStripMenuItem";
            this.майнитьToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.майнитьToolStripMenuItem.Text = "Заблокировать";
            this.майнитьToolStripMenuItem.Click += new System.EventHandler(this.майнитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.удалитьToolStripMenuItem.Text = "Отключить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // выключитьToolStripMenuItem
            // 
            this.выключитьToolStripMenuItem.Name = "выключитьToolStripMenuItem";
            this.выключитьToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.выключитьToolStripMenuItem.Text = "Выключить";
            // 
            // lVersion
            // 
            this.lVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lVersion.ForeColor = System.Drawing.Color.Gray;
            this.lVersion.Location = new System.Drawing.Point(8, 232);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(157, 23);
            this.lVersion.TabIndex = 3;
            this.lVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // icPlay
            // 
            this.icPlay.Image = global::FerumServer.Properties.Resources.icons8_игра_96;
            this.icPlay.Location = new System.Drawing.Point(75, 71);
            this.icPlay.Name = "icPlay";
            this.icPlay.Size = new System.Drawing.Size(47, 39);
            this.icPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.icPlay.TabIndex = 4;
            this.icPlay.TabStop = false;
            this.icPlay.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FerumServer.Properties.Resources.pcIco;
            this.pictureBox1.Location = new System.Drawing.Point(37, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TilePC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.icPlay);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "TilePC";
            this.Size = new System.Drawing.Size(176, 260);
            this.Load += new System.EventHandler(this.TilePC_Load);
            this.Click += new System.EventHandler(this.TilePC_Click);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem форматироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem майнитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выключитьToolStripMenuItem;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.PictureBox icPlay;
    }
}
