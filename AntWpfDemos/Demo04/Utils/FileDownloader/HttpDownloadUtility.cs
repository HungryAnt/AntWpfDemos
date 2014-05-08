using System.IO;
using System.Net;

namespace Demo04.Utils
{
    internal static class HttpDownloadUtility
    {
        internal static Stream GetWebFileStream(string fileUrl, long range, out long fileTotalSize)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(fileUrl);
            webRequest.AddRange(range);

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            fileTotalSize = webResponse.ContentLength;  // 若下载的是

            return webResponse.GetResponseStream();
        }
    }
}
