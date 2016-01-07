using System.Diagnostics;
using System.IO;

namespace FileManager.Class
{
    public class File : AbstractFile
    {
        public File(string abstractPath)
        {
            AbstractPath = abstractPath;
            var disk = new DriveInfo(AbstractPath);
            if (!disk.IsReady)
                return;

            var fileInf = new FileInfo(AbstractPath);
            if (!fileInf.Exists) return;

            var currentFileInfo = new FileInfo(AbstractPath);
            AbstractName = currentFileInfo.Name;
            AbstractSize = currentFileInfo.Length;
            DateOfCreation = System.IO.File.GetCreationTime(AbstractPath).ToShortDateString();
            DateOfChange = System.IO.File.GetLastAccessTimeUtc(abstractPath).ToShortDateString();
            DateOfLastAppeal = System.IO.File.GetLastAccessTime(abstractPath).ToShortDateString();
        }

        public override void AbstractCopy(AbstractFile newFile)
        {
            var buffer = new byte[1024 * 1024]; //мегабайтный буфер
            using (var file = System.IO.File.Open(AbstractPath, FileMode.Open))
            {
                file.Read(buffer, 0, buffer.Length);
                // добавить обработку, если прочиталось меньше мегабайта
                newFile.AbstractWrite(buffer);
            }
        }

        public override void AbstractWrite(byte[] bytesArr)
        {
            using (var fstream = new FileStream(AbstractPath, FileMode.OpenOrCreate))
            {
                fstream.Write(bytesArr, 0, bytesArr.Length);
            }
        }

        public override void AbstractReplace(AbstractFolder inDirectory)
        {
            if (inDirectory is Folder)
                System.IO.File.Move(AbstractPath, Path.Combine(inDirectory.AbstractPath, AbstractName));
            else
            {
                var abstractFile = inDirectory.AbstractCreateFile(AbstractName);
                AbstractCopy(abstractFile);
                AbstractRemove();
            }
        }

        public override void AbstractRemove()
        {
            if (!System.IO.File.Exists(AbstractPath)) return;
            System.IO.File.Delete(AbstractPath);
        }

        public override void AbstractOpen()
        {
            //Проверка на существование файла
            if (!System.IO.File.Exists(AbstractPath)) return;
            //Открываем файл внешней программой
            var p1 = new Process { StartInfo = { FileName = AbstractPath } };
            p1.Start();
        }
    }
}
