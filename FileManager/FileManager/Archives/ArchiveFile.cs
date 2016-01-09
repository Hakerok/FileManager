using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using FileManager.Class;

namespace FileManager.Archives
{
    public class ArchiveFile : AbstractFile
    {
        private readonly ZipArchiveEntry _entry;

        public ArchiveFile(string abstractPath, ZipArchiveEntry entry)
        {
            // для работы с entry архив должен быть открыт в ArchiveDirectory в режиме Update
            _entry = entry;
            // path внутри архива
            AbstractPath = abstractPath;

            AbstractName = entry.Name;
            AbstractSize = entry.CompressedLength;
            DateOfCreation = "";
            DateOfChange = "";
            DateOfLastAppeal = "";
        }

        public override void AbstractCopy(AbstractFile file)
        {
            var buffer = new byte[1024 * 1024]; //мегабайтный буфер
            using (var aStream = _entry.Open())
            {
                aStream.Read(buffer, 0, buffer.Length);
                file.AbstractWrite(buffer);
            }
        }

        public override void AbstractWrite(byte[] bytesArr)
        {
            using (var aStream = _entry.Open())
                aStream.Write(bytesArr, 0, bytesArr.Length);
        }

        public override void AbstractReplace(AbstractFolder inDirectory)
        {
            // нет упрощенного перемещения для архивных файлов, оставляем только обобщенный код
            var abstractFile = inDirectory.AbstractCreateFile(AbstractName);
            AbstractCopy(abstractFile);
            AbstractRemove();
        }

        public override void AbstractRemove()
        {
            _entry.Delete();
        }

        public override void AbstractOpen()
        {
            var result = @"D:\Архив";
            _entry.Open();
            _entry.ExtractToFile(Path.Combine(result, _entry.FullName));
            // ReSharper disable once PossiblyMistakenUseOfParamsMethod
            var psi = new ProcessStartInfo { FileName = Path.Combine(AbstractName, result) };
            Process.Start(psi);
            AbstractRemove();
        }
    }
}
