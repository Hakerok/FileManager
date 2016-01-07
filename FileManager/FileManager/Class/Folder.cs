using System.Collections.Generic;
using System.IO;

namespace FileManager.Class
{
    public class Folder : AbstractFolder
    {
        public Folder(string abstractPath)
        {
            AbstractPath = abstractPath;
            var currentDirInfo = new DirectoryInfo(AbstractPath);
            AbstractName = currentDirInfo.Name;
            AbstractDateOfCreation = currentDirInfo.CreationTime.ToShortDateString();
            FilesList = new List<AbstractFile>();
            DirectoriesList = new List<AbstractFolder>();
        }

        public override void AbstractOpen()
        {
            var currentDirInfo = new DirectoryInfo(AbstractPath);

            foreach (var item in currentDirInfo.GetFiles())
            {
                var newFile = new File(Path.Combine(AbstractPath, item.Name));
                FilesList.Add(newFile);
            }
            foreach (var item in currentDirInfo.GetDirectories())
            {
                var newDirectory = new Folder(Path.Combine(AbstractPath, item.Name));
                DirectoriesList.Add(newDirectory);
            }
        }

        public override void AbstractRemove()
        {
            Directory.Delete(AbstractPath, true);
        }

        public override void AbstractReplace(AbstractFolder nodeElement)
        {
            if (nodeElement is Folder)
                Directory.Move(AbstractPath, nodeElement.AbstractPath);
            else
            {
                foreach (var progressInfo in AbstractCopy(nodeElement))
                {

                }
                AbstractRemove();
            }
        }

        public override AbstractFile AbstractCreateFile(string fileName)
        {
            return new File(Path.Combine(AbstractPath, fileName));
        }

        public override AbstractFolder AbstractCreateFolder(string folderName)
        {
            var newFolderPath = Path.Combine(AbstractPath, folderName);
            Directory.CreateDirectory(newFolderPath);
            return new Folder(newFolderPath);
        }
    }
}
