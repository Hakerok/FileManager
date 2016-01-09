using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using FileManager.Class;

namespace FileManager.Archives
{
    public class ArchiveFolder : AbstractFolder
    {
        public string InnerPath { get; set; }

        public ArchiveFolder(string abstractPath, string innerPath)
        {
            AbstractPath = abstractPath;
            InnerPath = innerPath;
            FilesList = new List<AbstractFile>();
            DirectoriesList = new List<AbstractFolder>();

            if (innerPath == @"")
            {
                AbstractName = AbstractPath.Substring(0, AbstractPath.Length - AbstractPath.IndexOf(@"/", System.StringComparison.Ordinal) - 1);
            }
            else
            {
                AbstractName = innerPath.Substring(innerPath.LastIndexOf(@"/", innerPath.Length - 2, System.StringComparison.Ordinal) + 1,
                    innerPath.Length - innerPath.LastIndexOf(@"/", innerPath.Length - 2, System.StringComparison.Ordinal) - 2);
            }
        }

        public override void AbstractOpen()
        {
            DirectoriesList.Clear();
            FilesList.Clear();

            using (var arc = ZipFile.Open(AbstractPath,ZipArchiveMode.Update))
            {
                var existingFolders = new List<string>();

                foreach (var item in arc.Entries)
                {
                    if (item.FullName.LastIndexOf(@"/", System.StringComparison.Ordinal) == item.FullName.Length - 1)
                    {
                        if (InnerPath == "")
                        {
                            if (!existingFolders.Contains(item.FullName.Substring(0, item.FullName.IndexOf(@"/", System.StringComparison.Ordinal) + 1)) &&
                                item.FullName.Substring(0, item.FullName.IndexOf(@"/", System.StringComparison.Ordinal) + 1) != "")
                            {
                                var newFolder = new ArchiveFolder(AbstractPath, item.FullName.Substring(0, item.FullName.IndexOf(@"/", System.StringComparison.Ordinal) + 1));
                                DirectoriesList.Add(newFolder);
                                existingFolders.Add(item.FullName.Substring(0, item.FullName.IndexOf(@"/", System.StringComparison.Ordinal) + 1));
                            }
                        }
                        else
                        {
                            if (item.FullName.IndexOf(InnerPath, System.StringComparison.Ordinal) >= 0)
                            {
                                var inPath = item.FullName.Replace(InnerPath, "");
                                if (!existingFolders.Contains(inPath.Substring(0, inPath.IndexOf(@"/", System.StringComparison.Ordinal) + 1)) &&
                                    inPath.Substring(0, inPath.IndexOf(@"/", System.StringComparison.Ordinal) + 1) != "")
                                {
                                    var newFolder = new ArchiveFolder(AbstractPath, item.FullName);
                                    DirectoriesList.Add(newFolder);
                                    existingFolders.Add(inPath.Substring(0, inPath.IndexOf(@"/", System.StringComparison.Ordinal) + 1));
                                }
                            }
                        }
                    }
                    else
                    {
                        if (InnerPath == "")
                        {
                            if (item.FullName.IndexOf(@"/", System.StringComparison.Ordinal) < 0)
                            {
                                var newFile = new ArchiveFile(item.FullName, item);
                                FilesList.Add(newFile);
                            }
                        }
                        else
                        {
                            if (item.FullName.IndexOf(InnerPath, System.StringComparison.Ordinal) >= 0)
                            {
                                var inPath = item.FullName.Replace(InnerPath, "");
                                if (inPath.IndexOf(@"/", System.StringComparison.Ordinal) < 0)
                                {
                                    var newFile = new ArchiveFile(item.FullName, item);
                                    FilesList.Add(newFile);
                                }
                            }
                        }
                    }
                }

            }
        }

        public override void AbstractRemove()
        {
            using (var arc = ZipFile.Open(AbstractPath, ZipArchiveMode.Update))
            {
                if (InnerPath.Equals(""))
                {
                    while (arc.Entries.Count > 0)
                    {
                        arc.Entries.First().Delete();
                    }
                }
                else
                {
                    while (arc.Entries.Count > 0)
                    {
                        if (arc.Entries.Any(o => o.FullName.IndexOf(InnerPath, System.StringComparison.Ordinal) >= 0))
                        {
                            arc.Entries.First(o => o.FullName.IndexOf(InnerPath, System.StringComparison.Ordinal) >= 0).Delete();
                        }
                    }
                }
            }
        }

        public override void AbstractReplace(AbstractFolder inDirectory)
        {
            var abstractFolder = inDirectory.AbstractCreateFolder(AbstractName);
            AbstractCopy(abstractFolder);
            AbstractRemove();
        }

        public override AbstractFile AbstractCreateFile(string fileName)
        {
            using (var arc = ZipFile.Open(AbstractPath, ZipArchiveMode.Update))
            {
                var newEntry = arc.CreateEntry(InnerPath + fileName);
                var newFile = new ArchiveFile(newEntry.FullName, newEntry);
                return newFile;
            }
        }

        public override AbstractFolder AbstractCreateFolder(string folderName)
        {
            var newFolder = new ArchiveFolder(AbstractPath, InnerPath + folderName);
            return newFolder;
        }
    }
}
