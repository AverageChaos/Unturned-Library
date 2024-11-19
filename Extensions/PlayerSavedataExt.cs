using SDG.Unturned;
using System.IO;

namespace ChaosLib.Extensions
{
    public static class PlayerSavedataExt
    {
        public static Block ReadBlock(string path)
        {
            if (!File.Exists(path))
            {
                UnturnedLog.info("Failed to find file at: " + path);
                return null;
            }

            byte[] array;
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                array = new byte[fileStream.Length];
                if (fileStream.Read(array, 0, array.Length) != array.Length)
                {
                    UnturnedLog.error("Failed to read the correct file size.");
                    return null;
                }
            }

            if (array == null)
                return null;

            return new Block(0, array);
        }

        public static void WriteBlock(string path, Block block)
        {
            byte[] bytes = block.getBytes(out int size);
            if (!File.Exists(path))
            {
                UnturnedLog.info("Failed to find file at: " + path);
                return;
            }

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                fileStream.Write(bytes, 0, size);
                fileStream.SetLength(size);
                fileStream.Flush();
            }
        }
    }
}