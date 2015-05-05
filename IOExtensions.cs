namespace Simit.Extensions
{
    #region Using Directives

    using System.IO;
    using System.IO.Compression;

    #endregion Using Directives

    /// <summary>
    ///
    /// </summary>
    public static class IOExtensions
    {
        #region Public Static Methods

        /// <summary>
        /// Copies the stream.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        public static void CopyStream(this Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

        /// <summary>
        /// Decompresses the gzip.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns></returns>
        public static bool DecompressGzip(this FileInfo file, string destinationPath)
        {
            byte[] fileData = File.ReadAllBytes(file.FullName);
            byte[] decompressedData = null;

            using (GZipStream stream = new GZipStream(new MemoryStream(fileData), CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    decompressedData = memory.ToArray();
                }
            }

            File.WriteAllBytes(destinationPath, decompressedData);
            return File.Exists(destinationPath);
        }

        #endregion Public Static Methods
    }
}