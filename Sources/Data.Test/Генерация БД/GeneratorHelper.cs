using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Data.Test.Генерация_БД
{
    public static class GeneratorHelper
    {
        public static Encoding GetEncodingType(string path)
        {
            string Gram =
                "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮQWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm0123456789";

            BinaryReader instr = new BinaryReader(File.OpenRead(path));
            int readCount = (int)instr.BaseStream.Length;
            readCount = readCount > 255 ? 255 : readCount;
            byte[] data = instr.ReadBytes(readCount);
            instr.Close();

            EncodingInfo[] allEnc = Encoding.GetEncodings();

            double bestPrc = 0.1;
            int bestPrcId = -1;

            for (int i = 0; i < allEnc.Length; i++)
            {
                double uCharNum = 0;

                Encoding e = allEnc[i].GetEncoding();
                string bf = e.GetString(data);

                for (int j = 0; j < bf.Length; j++)
                {
                    if (Gram.Contains(bf[j]))
                        uCharNum++;
                }

                if (uCharNum / bf.Length > bestPrc)
                {
                    bestPrc = uCharNum / bf.Length;
                    bestPrcId = i;
                }
            }

            if (bestPrcId != -1)
            {
                return allEnc[bestPrcId].GetEncoding();
            }
            return null;
        }

        public static Guid ToGuid(int value)
        {
            value++;
            var bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }


        public static Guid ToGuid(short value1, int value2)
        {
            value1++;
            value2++;
            return new Guid(value2, value1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }

        public static string RemoveDigits(string str)
        {
            var res = str.Remove(0, str.IndexOf(' '));
            res = res.Trim();
            res = res.Substring(0, 1).ToUpper() + (res.Length > 1 ? res.Substring(1) : "");
            return res;
        }
    }
}
