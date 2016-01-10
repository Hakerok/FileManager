using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using FileManager.Archives;
using FileManager.Class;

namespace FileManager
{
    public partial class LvKontrol : Panel
    {
        AbstractFolder _activeFolder;

        protected AbstractFolder ActiveDirectory
        {
            get
            {
                return _activeFolder;
            }
            set
            {
                _activeFolder = value;
                _activeFolder.AbstractOpen();

               
                lbActiveDirectory.Text = value.AbstractPath;
                lsvPanel.Items.Clear();

                foreach (var item in _activeFolder.DirectoriesList)
                {
                    var lvi = new ListViewItem { Text = item.AbstractName };
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add(item.AbstractDateOfCreation);
                    lsvPanel.Items.Add(lvi);
                }

                foreach (var item in _activeFolder.FilesList)
                {
                    var lvi = new ListViewItem {Text = item.AbstractName};
                    lvi.SubItems.Add(item.AbstractSize.ToString(CultureInfo.InvariantCulture));
                    lvi.SubItems.Add(item.DateOfCreation);
                    lvi.SubItems.Add(item.DateOfChange);
                    lvi.SubItems.Add(item.DateOfLastAppeal);
                    lsvPanel.Items.Add(lvi);
                   
                }
            }
        }

        public LvKontrol()
        {
            InitializeComponent();
           
        }

        public LvKontrol(IContainer container)
        {
           
            container.Add(this);

            InitializeComponent();
            toolTip1.SetToolTip(btnBack, "Назад");
            lsvPanel.View = View.Details;
            lsvPanel.Columns.Add("Имя");
            lsvPanel.Columns.Add("Размер");
            lsvPanel.Columns.Add("Дата создания");
            lsvPanel.Columns.Add("Дата изменения");
            lsvPanel.Columns.Add("Дата последнего доступа");
            ActiveDirectory = new Folder(@"D:\");
            
        }

        private void lsvPanel_DoubleClick(object sender, EventArgs e)
        {
            if (lsvPanel.SelectedIndices.Count != 1)
                return;

            var clickedItem = lsvPanel.Items[lsvPanel.SelectedIndices[0]].SubItems[0].Text;

            foreach (var item in ActiveDirectory.DirectoriesList.Where(item => item.AbstractName == clickedItem))
            {
                ActiveDirectory = item;
                break;
            }

            foreach (var item in ActiveDirectory.FilesList.Where(item => item.AbstractName == clickedItem))
            {
                if (item.AbstractName.EndsWith(@".zip"))
                {
                    ActiveDirectory = new ArchiveFolder(item.AbstractPath, "");
                }
                else
                {
                    item.AbstractOpen();
                    break;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (ActiveDirectory.AbstractPath.EndsWith(@".zip"))
            {
                var af = (ArchiveFolder)ActiveDirectory;                
                string backPath;

                if (af.InnerPath == "")
                {
                    backPath = af.AbstractPath.Substring(0, af.AbstractPath.LastIndexOf(@"\", StringComparison.Ordinal));

                    if (backPath.Length == 2)
                        backPath += @"\";

                    ActiveDirectory = new Folder(backPath);
                }
                else
                {
                    backPath = af.InnerPath.IndexOf(@"/", StringComparison.Ordinal) == -1 ? "" :
                    af.InnerPath.Substring(0, af.InnerPath.LastIndexOf(@"/", af.InnerPath.Length - 2, StringComparison.Ordinal) + 1);

                    ActiveDirectory = new ArchiveFolder(ActiveDirectory.AbstractPath, backPath);
                }
            }
            else
            {
                var backPath = ActiveDirectory.AbstractPath.Substring(0, ActiveDirectory.AbstractPath.LastIndexOf(@"\", StringComparison.Ordinal));

                if (backPath.Length == 2)
                    backPath += @"\";

                ActiveDirectory = new Folder(backPath);
            }
        }

       
       
        }
    }

