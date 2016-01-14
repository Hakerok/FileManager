using System;
using System.Linq;
using System.Windows.Forms;
using FileManager.Class;
namespace FileManager
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
            toolTip1.SetToolTip(CopyLeft, "Копировать (F3)");
            toolTip1.SetToolTip(ReplaceLeft, "Переместить (F4)");
            toolTip1.SetToolTip(RemoveLeft, "Удалить (Delete)");
            toolTip1.SetToolTip(Exit, "Выход (Alt+X)");
            KeyPreview = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                CopyLeft.PerformClick();
            }

            if (e.KeyCode == Keys.F4)
            {
               ReplaceLeft.PerformClick();
            }

            if (e.KeyCode == Keys.Delete)
            {
                RemoveLeft.PerformClick();
            }

            if (e.KeyCode == Keys.X && e.Alt)
            {
                Exit.PerformClick();
            }

        }

        private void Copy_Click(object sender, EventArgs e)
        {
            foreach (var item in LeftKontrol.ActiveDirectory.DirectoriesList.Where(item => item.AbstractName == LeftKontrol.ClickItem))
            {
                AbstractFolder CopiedItem = new Folder(RightKontrol.ActiveDirectory.AbstractPath + @"\" + LeftKontrol.ClickItem);
                foreach (var progressInfo in item.AbstractCopy(CopiedItem))
                {
                    pgsCopy.Maximum = progressInfo.All;
                    pgsCopy.Value = progressInfo.Current;                    
                }
                break;
            }
            foreach (var item in LeftKontrol.ActiveDirectory.FilesList.Where(item => item.AbstractName == LeftKontrol.ClickItem))
            {
                AbstractFile CopiedItem = new File(RightKontrol.ActiveDirectory.AbstractPath + @"\" + LeftKontrol.ClickItem);
                item.AbstractCopy(CopiedItem);
                break;
            }

            KontrolsUpdates();
            pgsCopy.Value = 0;
        }

        private void CopyRight_Click(object sender, EventArgs e)
        {
            foreach (var item in RightKontrol.ActiveDirectory.DirectoriesList.Where(item => item.AbstractName == RightKontrol.ClickItem))
            {
                AbstractFolder CopiedItem = new Folder(LeftKontrol.ActiveDirectory.AbstractPath + @"\" + RightKontrol.ClickItem);
                foreach (var progressInfo in item.AbstractCopy(CopiedItem))
                {
                    pgsCopy.Maximum = progressInfo.All;
                    pgsCopy.Value = progressInfo.Current;
                }
                break;
            }
            foreach (var item in RightKontrol.ActiveDirectory.FilesList.Where(item => item.AbstractName == RightKontrol.ClickItem))
            {
                AbstractFile CopiedItem = new File(LeftKontrol.ActiveDirectory.AbstractPath + @"\" + RightKontrol.ClickItem);
                item.AbstractCopy(CopiedItem);
                break;
            }

            KontrolsUpdates();
            pgsCopy.Value = 0;
        }

        private void Replace_Click(object sender, EventArgs e)
        {
            foreach (var item in LeftKontrol.ActiveDirectory.DirectoriesList.Where(item => item.AbstractName == LeftKontrol.ClickItem))
            {
                var folderToReplace = new Folder(RightKontrol.ActiveDirectory.AbstractPath + @"\" + item.AbstractName);
                item.AbstractReplace(folderToReplace);
            }
            foreach (var item in LeftKontrol.ActiveDirectory.FilesList.Where(item => item.AbstractName == LeftKontrol.ClickItem))
            {
                var fileToReplace = new Folder(RightKontrol.ActiveDirectory.AbstractPath);
                item.AbstractReplace(fileToReplace);
            }
            KontrolsUpdates();
        }

        private void ReplaceRight_Click(object sender, EventArgs e)
        {
            foreach (var item in RightKontrol.ActiveDirectory.DirectoriesList.Where(item => item.AbstractName == RightKontrol.ClickItem))
            {
                var folderToReplace = new Folder(LeftKontrol.ActiveDirectory.AbstractPath + @"\" + item.AbstractName);
                item.AbstractReplace(folderToReplace);
            }
            foreach (var item in RightKontrol.ActiveDirectory.FilesList.Where(item => item.AbstractName == RightKontrol.ClickItem))
            {
                var fileToReplace = new Folder(LeftKontrol.ActiveDirectory.AbstractPath);
                item.AbstractReplace(fileToReplace);
            }
            KontrolsUpdates();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить", "Удалить", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            foreach (var item in LeftKontrol.ActiveDirectory.DirectoriesList.Where(item => item.AbstractName == LeftKontrol.ClickItem))
            {
                item.AbstractRemove();
                break;
            }
            foreach (var item in LeftKontrol.ActiveDirectory.FilesList.Where(item => item.AbstractName == LeftKontrol.ClickItem))
            {
                item.AbstractRemove();
                break;
            }
            KontrolsUpdates();
         }

        private void RemoveRight_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить", "Удалить", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            foreach (var item in RightKontrol.ActiveDirectory.DirectoriesList.Where(item => item.AbstractName == RightKontrol.ClickItem))
            {
                item.AbstractRemove();
            }
             foreach (var item in RightKontrol.ActiveDirectory.FilesList.Where(item => item.AbstractName == RightKontrol.ClickItem))
            {
                item.AbstractRemove();
            }
            KontrolsUpdates();
        }
        
        private void Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Вы действительно хотите выйти", @"Выход", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
               Application.Exit(); 
            }
        }

        protected void KontrolsUpdates()
        {
            LeftKontrol.ActiveDirectory = new Folder(LeftKontrol.ActiveDirectory.AbstractPath);
            RightKontrol.ActiveDirectory = new Folder(RightKontrol.ActiveDirectory.AbstractPath);
        }    
    }
}
