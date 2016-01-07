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
            toolTip1.SetToolTip(Copy, "Копирование");
            toolTip1.SetToolTip(Replace, "Перемещение");
            toolTip1.SetToolTip(Remove, "Удаление");
            toolTip1.SetToolTip(Exit, "Выход");
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
            if (MessageBox.Show("Вы действительно хотите выйти", "Выход", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
               Application.Exit(); 
            }
        }
    }
}
