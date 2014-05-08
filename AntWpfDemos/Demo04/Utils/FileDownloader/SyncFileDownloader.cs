using System;
using System.IO;

namespace Demo04.Utils
{
    public class SyncFileDownloader : FileDownloader
    {
        public SyncFileDownloader(string fileUrl, string localFilePath)
            : base(fileUrl, localFilePath)
        {

        }

        private Action<long, long> _reportProgressAction;

        private void OnReportProgressAction(long downlaodedSize, long totalSize)
        {
            if (_reportProgressAction != null)
            {
                _reportProgressAction(downlaodedSize, totalSize);
            }
        }

        public bool Start(out string errorMessage, Action<long, long> reportProgressAction)
        {
            _reportProgressAction = reportProgressAction;

            try
            {
                long fileTotalSize;
                var stream = HttpDownloadUtility.GetWebFileStream(FileUrl, FileReadedSize, out fileTotalSize);
                FileTotalSize = fileTotalSize;
                InitFileStream();

                bool result = Download(stream);

                errorMessage = string.Empty;
                return result;
            }
            catch (Exception ex)
            {
                errorMessage = ex.ToString();
                return false;
            }
            finally
            {
                CloseLocalFileStream();
            }
        }

        private bool Download(Stream stream)
        {
            if (FileReadedSize != 0)
            {
                SeekFileStream();
            }

            int readBytesCount;
            while ((readBytesCount = stream.Read(ReadBytesBuffer, 0, READ_BUFFER_SIZE)) != 0)
            {
                FileReadedSize += readBytesCount;
                WriteFileStream(ReadBytesBuffer, readBytesCount);

                OnReportProgressAction(FileReadedSize, FileTotalSize);
            }

            if (FileTotalSize == -1)
            {
                return true;
            }
            return FileReadedSize == FileTotalSize;
        }

    }
}
