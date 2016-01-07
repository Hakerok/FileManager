using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileManager.Class
{
     public abstract class AbstractFile
    {
        public string AbstractName { get; set; }
        public string AbstractPath { get; set; }
        public string AbstractType { get; set; }
        public long   AbstractSize { get; set; }
        public string DateOfCreation { get; set; }
        public string DateOfChange { get; set; }
        public string DateOfLastAppeal { get; set; }

        public abstract void AbstractCopy(AbstractFile file);
        public abstract void AbstractWrite(byte[] bytesArr);
        public abstract void AbstractReplace(AbstractFolder inDirectory);
        public abstract void AbstractRemove();
        public abstract void AbstractOpen();
    }

    public abstract class AbstractFolder
    {
        public string AbstractName { get; set; }
        public string AbstractPath { get; set; }
        public string AbstractDateOfCreation { get; set; }
        public List<AbstractFile> FilesList { get; set; }
        public List<AbstractFolder> DirectoriesList { get; set; }

        public abstract void AbstractOpen();
        public abstract void AbstractRemove();
        public abstract void AbstractReplace(AbstractFolder nodeElement);
        public abstract AbstractFile AbstractCreateFile(string fileName);
        public abstract AbstractFolder AbstractCreateFolder(string folderName);

        public IEnumerable<ProgressInfo> AbstractCopy(AbstractFolder nodeElement)
        {
            var count = h_countFiles(this);

            var progressInfo = new ProgressInfo
            {
                All = count
            };

            Directory.CreateDirectory(nodeElement.AbstractPath);

            foreach (var item in FilesList)
            {
                var destination = nodeElement.AbstractCreateFile(item.AbstractName);
                item.AbstractCopy(destination);
                progressInfo.Current++;

                yield return progressInfo;
            }
            foreach (var item in DirectoriesList)
            {
                var createdFolder = nodeElement.AbstractCreateFolder(item.AbstractName);
                foreach (var innerItem in item.AbstractCopy(createdFolder))
                {
                    yield return innerItem;
                }
                progressInfo.Current++;

                yield return progressInfo;
            }
        }

        private int h_countFiles(AbstractFolder abstractFolder)
        {
            abstractFolder.AbstractOpen();

            return abstractFolder.FilesList.Count +
              abstractFolder.DirectoriesList.Sum(innerFolder => h_countFiles(innerFolder));
        }
    }
}

