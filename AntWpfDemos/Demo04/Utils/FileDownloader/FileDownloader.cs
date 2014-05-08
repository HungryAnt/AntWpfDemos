using System.IO;

namespace Demo04.Utils
{
    public abstract class FileDownloader
    {
        public string FileUrl { get; private set; }
        public string LocalFilePath { get; private set; }

        protected const int READ_BUFFER_SIZE = 4096;
        private readonly byte[] _readBytesBuffer = new byte[READ_BUFFER_SIZE];

        protected byte[] ReadBytesBuffer
        {
            get { return _readBytesBuffer; }
        }

        protected long FileTotalSize { get; set; }
        protected long FileReadedSize { get; set; }

        private FileStream _outFileStream;

        protected FileDownloader(string fileUrl, string localFilePath)
        {
            FileUrl = fileUrl;
            LocalFilePath = localFilePath;
        }

        protected void InitFileStream()
        {
            if (FileReadedSize > 0)
            {
                _outFileStream = new FileStream(LocalFilePath, FileMode.OpenOrCreate);
            }
            else
            {
                _outFileStream = new FileStream(LocalFilePath, FileMode.Create);
            }
        }

        protected void SeekFileStream()
        {
            _outFileStream.Seek(FileReadedSize, SeekOrigin.Begin);
        }

        protected void WriteFileStream(byte[] array, int count)
        {
            _outFileStream.Write(ReadBytesBuffer, 0, count);
        }

        protected void CloseLocalFileStream()
        {
            if (_outFileStream != null)
            {
                _outFileStream.Close();
                _outFileStream = null;
            }
        }
    }
}
