using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Gods.Foundation;

namespace Demo04.ViewModels
{
    class FileDownloaderPageViewModel : NotificationObject
    {
        public DelegateCommand DownloadCommand { get; set; }

        public FileDownloaderPageViewModel()
        {
            InitCommands();

            FileInfoViewModels = new ObservableCollection<FileInfoViewModel>(
//                new List<FileInfoViewModel>()
//                    {
//                        new FileInfoViewModel()
//                            {
//                                Name = "xxxx"
//                            }
//                    }
                );
        }

        private void InitCommands()
        {
            DownloadCommand = CreateDownloadCommand();
        }

        private DelegateCommand CreateDownloadCommand()
        {
            return new DelegateCommand(
                o =>
                    {
                        FileInfoViewModel fileInfoViewModel = FileInfoViewModel.FromNewFileInfo(
                            Path.GetFileName(FileUrl),
                            FileUrl,
                            "xxx"
                            );
                        FileInfoViewModels.Add(fileInfoViewModel);
                    },
                o =>
                    {
                        return !string.IsNullOrEmpty(FileUrl);
                    }
                );
        }

        private string _fileUrl;

        public string FileUrl
        {
            get { return _fileUrl; }
            set
            {
                _fileUrl = value;
                RaisePropertyChanged("FileUrl");
                DownloadCommand.RaiseCanExecuteChanged();
            }
        }
        

        private ObservableCollection<FileInfoViewModel> _fileInfoViewModels;

        public ObservableCollection<FileInfoViewModel> FileInfoViewModels
        {
            get { return _fileInfoViewModels; }
            set
            {
                _fileInfoViewModels = value;
                RaisePropertyChanged("FileInfoViewModels");
            }
        }
        
    }
}
