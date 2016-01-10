namespace FileManager
{
    partial class LvKontrol
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>       
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lsvPanel = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lbActiveDirectory = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvPanel
            // 
            this.lsvPanel.Location = new System.Drawing.Point(0, 25);
            this.lsvPanel.Name = "lsvPanel";
            this.lsvPanel.Size = new System.Drawing.Size(600, 400);
            this.lsvPanel.TabIndex = 0;
            this.lsvPanel.UseCompatibleStateImageBehavior = false;
            this.lsvPanel.Click += new System.EventHandler(this.lsvPanel_Click);
            this.lsvPanel.DoubleClick += new System.EventHandler(this.lsvPanel_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.lsvPanel);
            this.panel1.Controls.Add(this.lbActiveDirectory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = global::FileManager.Properties.Resources.back;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Location = new System.Drawing.Point(0, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(30, 25);
            this.btnBack.TabIndex = 0;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lbActiveDirectory
            // 
            this.lbActiveDirectory.AutoSize = true;
            this.lbActiveDirectory.Location = new System.Drawing.Point(30, 0);
            this.lbActiveDirectory.Name = "lbActiveDirectory";
            this.lbActiveDirectory.Size = new System.Drawing.Size(87, 13);
            this.lbActiveDirectory.TabIndex = 0;
            this.lbActiveDirectory.Text = "lbActiveDirectory";
            // 
            // LvKontrol
            // 
            this.Controls.Add(this.panel1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbActiveDirectory;
        private System.Windows.Forms.Button btnBack;
    }
}
