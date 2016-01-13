namespace FileManager
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ReplaceLeft = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.RemoveLeft = new System.Windows.Forms.Button();
            this.CopyLeft = new System.Windows.Forms.Button();
            this.RightKontrol = new FileManager.LvKontrol(this.components);
            this.LeftKontrol = new FileManager.LvKontrol(this.components);
            this.CopyRight = new System.Windows.Forms.Button();
            this.ReplaceRight = new System.Windows.Forms.Button();
            this.RemoveRight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReplaceLeft
            // 
            this.ReplaceLeft.Location = new System.Drawing.Point(57, 12);
            this.ReplaceLeft.Name = "ReplaceLeft";
            this.ReplaceLeft.Size = new System.Drawing.Size(39, 32);
            this.ReplaceLeft.TabIndex = 1;
            this.ReplaceLeft.UseVisualStyleBackColor = true;
            this.ReplaceLeft.Click += new System.EventHandler(this.Replace_Click);
            // 
            // Exit
            // 
            this.Exit.BackgroundImage = global::FileManager.Properties.Resources.Exit;
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Exit.Location = new System.Drawing.Point(1186, 12);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(39, 32);
            this.Exit.TabIndex = 3;
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // RemoveLeft
            // 
            this.RemoveLeft.BackgroundImage = global::FileManager.Properties.Resources.Delete;
            this.RemoveLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RemoveLeft.Location = new System.Drawing.Point(102, 12);
            this.RemoveLeft.Name = "RemoveLeft";
            this.RemoveLeft.Size = new System.Drawing.Size(39, 32);
            this.RemoveLeft.TabIndex = 2;
            this.RemoveLeft.UseVisualStyleBackColor = true;
            this.RemoveLeft.Click += new System.EventHandler(this.Remove_Click);
            // 
            // CopyLeft
            // 
            this.CopyLeft.BackgroundImage = global::FileManager.Properties.Resources.Сopy;
            this.CopyLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CopyLeft.Location = new System.Drawing.Point(12, 12);
            this.CopyLeft.Name = "CopyLeft";
            this.CopyLeft.Size = new System.Drawing.Size(39, 32);
            this.CopyLeft.TabIndex = 0;
            this.CopyLeft.UseVisualStyleBackColor = true;
            this.CopyLeft.Click += new System.EventHandler(this.Copy_Click);
            // 
            // RightKontrol
            // 
            
            this.RightKontrol.Location = new System.Drawing.Point(622, 50);
            this.RightKontrol.Name = "RightKontrol";
            this.RightKontrol.Size = new System.Drawing.Size(613, 432);
            this.RightKontrol.TabIndex = 5;
            // 
            // LeftKontrol
            // 
           
            this.LeftKontrol.Location = new System.Drawing.Point(12, 50);
            this.LeftKontrol.Name = "LeftKontrol";
            this.LeftKontrol.Size = new System.Drawing.Size(604, 453);
            this.LeftKontrol.TabIndex = 4;
            // 
            // CopyRight
            // 
            this.CopyRight.BackgroundImage = global::FileManager.Properties.Resources.Сopy;
            this.CopyRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CopyRight.Location = new System.Drawing.Point(622, 12);
            this.CopyRight.Name = "CopyRight";
            this.CopyRight.Size = new System.Drawing.Size(39, 32);
            this.CopyRight.TabIndex = 6;
            this.CopyRight.UseVisualStyleBackColor = true;
            this.CopyRight.Click += new System.EventHandler(this.CopyRight_Click);
            // 
            // ReplaceRight
            // 
            this.ReplaceRight.Location = new System.Drawing.Point(667, 12);
            this.ReplaceRight.Name = "ReplaceRight";
            this.ReplaceRight.Size = new System.Drawing.Size(39, 32);
            this.ReplaceRight.TabIndex = 7;
            this.ReplaceRight.UseVisualStyleBackColor = true;
            this.ReplaceRight.Click += new System.EventHandler(this.ReplaceRight_Click);
            // 
            // RemoveRight
            // 
            this.RemoveRight.BackgroundImage = global::FileManager.Properties.Resources.Delete;
            this.RemoveRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RemoveRight.Location = new System.Drawing.Point(712, 12);
            this.RemoveRight.Name = "RemoveRight";
            this.RemoveRight.Size = new System.Drawing.Size(39, 32);
            this.RemoveRight.TabIndex = 8;
            this.RemoveRight.UseVisualStyleBackColor = true;
            this.RemoveRight.Click += new System.EventHandler(this.RemoveRight_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 526);
            this.Controls.Add(this.RemoveRight);
            this.Controls.Add(this.ReplaceRight);
            this.Controls.Add(this.CopyRight);
            this.Controls.Add(this.RightKontrol);
            this.Controls.Add(this.LeftKontrol);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.RemoveLeft);
            this.Controls.Add(this.ReplaceLeft);
            this.Controls.Add(this.CopyLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Файловый менеджер";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CopyLeft;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button ReplaceLeft;
        private System.Windows.Forms.Button RemoveLeft;
        private System.Windows.Forms.Button Exit;
        private LvKontrol LeftKontrol;
        private LvKontrol RightKontrol;
        private System.Windows.Forms.Button CopyRight;
        private System.Windows.Forms.Button ReplaceRight;
        private System.Windows.Forms.Button RemoveRight;
    }
}

