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
            toolTip1.SetToolTip(Copy, "Копировать (F3)");
            toolTip1.SetToolTip(Replace, "Переместить (F4)");
            toolTip1.SetToolTip(Remove, "Удалить (Delete)");
            toolTip1.SetToolTip(Exit, "Выход (Alt+X)");
            KeyPreview = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Copy.PerformClick();
            }

            if (e.KeyCode == Keys.F4)
            {
               Replace.PerformClick();
            }

            if (e.KeyCode == Keys.Delete)
            {
                Remove.PerformClick();
            }

            if (e.KeyCode == Keys.X && e.Alt)
            {
                Exit.PerformClick();
            }

        }

        private void Copy_Click(object sender, EventArgs e)
        {
            foreach (var item1 in from item in LeftKontrol.ActiveDirectory.DirectoriesList.Where(item => item.AbstractName == LeftKontrol.ClickItem)
                                  let qwe = new Folder(RightKontrol.ActiveDirectory.AbstractPath + @"\" + item.AbstractName)
                                  from item1 in item.AbstractCopy(qwe)
                                  select item1)
            {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                item1.ToString();
            }
            foreach (var item in LeftKontrol.ActiveDirectory.FilesList.Where(item => item.AbstractName == LeftKontrol.ClickItem))
            {
                AbstractFile qwe = new File(RightKontrol.ActiveDirectory.AbstractPath + @"\" + item.AbstractName);
                item.AbstractCopy(qwe);
            }
        }

        private void Replace_Click(object sender, EventArgs e)
        {
            foreach (var item in LeftKontrol.ActiveDirectory.DirectoriesList.Where(item => item.AbstractName == LeftKontrol.ClickItem))
            {
                var qwe = new Folder(RightKontrol.ActiveDirectory.AbstractPath + @"\" + item.AbstractName);
                item.AbstractReplace(qwe);
            }
            foreach (var item in LeftKontrol.ActiveDirectory.FilesList.Where(item => item.AbstractName == LeftKontrol.ClickItem))
            {
                var qwe = new Folder(RightKontrol.ActiveDirectory.AbstractPath);
                item.AbstractReplace(qwe);
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {

            foreach (var item in LeftKontrol.ActiveDirectory.DirectoriesList.Where(item => item.AbstractName == LeftKontrol.ClickItem))
            {
                item.AbstractRemove();
            }
            foreach (var item in LeftKontrol.ActiveDirectory.FilesList.Where(item => item.AbstractName == LeftKontrol.ClickItem))
            {
                item.AbstractRemove();
            }
         }

        private void Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Вы действительно хотите выйти", @"Выход", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
               Application.Exit(); 
            }
        }

       
    }
}
