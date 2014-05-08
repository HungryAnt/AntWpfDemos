using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using Demo04.Utils;
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
                            FileLocalPath
                            );
                        FileInfoViewModels.Add(fileInfoViewModel);

                        DownloadFile(fileInfoViewModel);
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

        private string _fileLocalPath;

        public string FileLocalPath
        {
            get { return _fileLocalPath; }
            set
            {
                _fileLocalPath = value;
                RaisePropertyChanged("FileLocalPath");
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

        private void DownloadFile(FileInfoViewModel fileInfoViewModel)
        {
            string fileUrl = fileInfoViewModel.Url;
            string localFilePath = fileInfoViewModel.LocalPath;

            BackgroundWorker downloadWorker = new BackgroundWorker()
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                };

            downloadWorker.DoWork += (sender, args) =>
                {
                    var worker = args.Argument as BackgroundWorker;

                    SyncFileDownloader fileDownloader = new SyncFileDownloader(fileUrl, localFilePath);
                    string errorMessage;
                    args.Result = fileDownloader.Start(
                        out errorMessage,
                        (downlaodedSize, totalSize) =>
                            {
                                if (totalSize != 0 && totalSize >= downlaodedSize)
                                {
                                    worker.ReportProgress(
                                        (int) (downlaodedSize*100/totalSize));
                                }
                            });
                };

            downloadWorker.ProgressChanged += (sender, args) =>
                {
                    fileInfoViewModel.ProgressPercentage = args.ProgressPercentage;
                };

            downloadWorker.RunWorkerCompleted += (sender, args) =>
                {
                    bool isDownloadSuccessful = (bool)args.Result;
                    fileInfoViewModel.DownloadState = isDownloadSuccessful
                                                          ? DownloadState.Successful
                                                          : DownloadState.Failed;
                };

            downloadWorker.RunWorkerAsync(downloadWorker);
        }
    }
}
