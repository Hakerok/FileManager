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
            this.Replace = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.Remove = new System.Windows.Forms.Button();
            this.Copy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Replace
            // 
            this.Replace.Location = new System.Drawing.Point(57, 12);
            this.Replace.Name = "Replace";
            this.Replace.Size = new System.Drawing.Size(39, 32);
            this.Replace.TabIndex = 1;
            this.Replace.UseVisualStyleBackColor = true;
            this.Replace.Click += new System.EventHandler(this.Replace_Click);
            // 
            // Exit
            // 
            this.Exit.BackgroundImage = global::FileManager.Properties.Resources.Exit;
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Exit.Location = new System.Drawing.Point(147, 12);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(39, 32);
            this.Exit.TabIndex = 3;
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Remove
            // 
            this.Remove.BackgroundImage = global::FileManager.Properties.Resources.Delete;
            this.Remove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Remove.Location = new System.Drawing.Point(102, 12);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(39, 32);
            this.Remove.TabIndex = 2;
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // Copy
            // 
            this.Copy.BackgroundImage = global::FileManager.Properties.Resources.Сopy;
            this.Copy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Copy.Location = new System.Drawing.Point(12, 12);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(39, 32);
            this.Copy.TabIndex = 0;
            this.Copy.UseVisualStyleBackColor = true;
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 468);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.Replace);
            this.Controls.Add(this.Copy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Файловый менеджер";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Copy;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button Replace;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.Button Exit;
    }
}

