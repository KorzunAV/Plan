using System.IO;

namespace Data.Test.Генерация_БД
{
    public class FileHelper
    {
        public delegate void LineExplorerDelegete(string line);
        
        public static void ReadByLine(FileInfo fileInfo, LineExplorerDelegete delegete)
        {
            var encoding = GeneratorHelper.GetEncodingType(fileInfo.FullName);
            using (var fs = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read))
            using (var sr = new StreamReader(fs, encoding))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    delegete(line);
                }
            }
        }
    }
}
