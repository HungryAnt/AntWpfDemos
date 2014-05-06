using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo04.Models;
using Gods.Foundation;

namespace Demo04.ViewModels
{
    public class FileInfoViewModel : NotificationObject
    {
        public FileInfoEntity FileInfoEntity { get; private set; }

        public FileInfoViewModel(FileInfoEntity fileInfoEntity)
        {
            FileInfoEntity = fileInfoEntity;
        }

        public string Name
        {
            get { return FileInfoEntity.Name; }
            set
            {
                FileInfoEntity.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Url
        {
            get { return FileInfoEntity.Url; }
            set
            {
                FileInfoEntity.Url = value;
                RaisePropertyChanged("Url");
            }
        }

        public string LocalPath
        {
            get { return FileInfoEntity.LocalPath; }
            set
            {
                FileInfoEntity.LocalPath = value;
                RaisePropertyChanged("LocalPath");
            }
        }

        private long _fileTotalSize;

        public long FileTotalSize
        {
            get { return _fileTotalSize; }
            set
            {
                _fileTotalSize = value;
                RaisePropertyChanged("FileTotalSize");
            }
        }

        private long _fileCurrentSize;

        public long FileCurrentSize
        {
            get { return _fileCurrentSize; }
            set
            {
                _fileCurrentSize = value;
                RaisePropertyChanged("FileCurrentSize");
            }
        }

        public static FileInfoViewModel FromNewFileInfo(string fileName, string fileUrl, string localPath)
        {
            return new FileInfoViewModel(new FileInfoEntity()
                {
                    Name = fileName,
                    Url = fileUrl,
                    LocalPath = localPath
                });
        }

        public static FileInfoViewModel FromFileInfo(FileInfoEntity fileInfoEntity)
        {
            return new FileInfoViewModel(fileInfoEntity);
        }
    }
}
