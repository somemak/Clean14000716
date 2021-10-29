using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Clean14000716.Common.Utilities
{
    public static class GZipHelper
    {
        private static void CopyTo(Stream sourceStream, Stream destinationStream)
        {
            byte[] bytes = new byte[4096];
            int cnt;
            while ((cnt = sourceStream.Read(bytes, 0, bytes.Length)) != 0)
            {
                destinationStream.Write(bytes, 0, cnt);
            }
        }

        public static byte[] Zip(String stringValue)
        {
            var bytes = Encoding.UTF8.GetBytes(stringValue);
            using (var inputStream = new MemoryStream(bytes))
            {
                using (var outputStream = new MemoryStream())
                {
                    using (var gzipStream = new GZipStream(outputStream, CompressionMode.Compress))
                    {
                        CopyTo(inputStream, gzipStream);
                    }

                    return outputStream.ToArray();
                }
            }
        }
        /// <summary>
        /// ایجاد یک برنامه منظم جهت به کارگیری در سراسر ارگانهای دولتی
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static String Unzip(byte[] bytes)
        {
            using (var inputStream = new MemoryStream(bytes))
            {
                using (var outputStream = new MemoryStream())
                {
                    using (var gzipStream = new GZipStream(inputStream, CompressionMode.Decompress))
                    {
                        CopyTo(gzipStream, outputStream);
                    }

                    return Encoding.UTF8.GetString(outputStream.ToArray());
                }
            }
        }
    }

}