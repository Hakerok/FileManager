using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileManager.Properties;

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
           
        }

        private void Replace_Click(object sender, EventArgs e)
        {
           
        }

        private void Remove_Click(object sender, EventArgs e)
        {
           
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
