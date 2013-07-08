using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Data.Test.Генерация_БД
{
    public class CurrencyTypeGenerator
    {
        private const string PathToDocuments = @"Documents\Курсы валют\";
        private const string PathToCurrencyTypeSql = @"Scripts\Наполнение БД\CurrencyType.sql";
        private const string LineKey = "Дата";
        public const string Byr = "Белорусский рубль (BYR)";

        private readonly string _pathToSolution;
        
        public CurrencyTypeGenerator(string pathToSolution)
        {
            _pathToSolution = pathToSolution;
        }

        public void Execute(List<string> names)
        {
            if (names.Count > 1)
            {
                using (var fs = new FileStream(_pathToSolution + PathToCurrencyTypeSql, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (var sw = new StreamWriter(fs, Encoding.Unicode))
                    {
                        sw.WriteLine("INSERT INTO [TestPlan].[dbo].[CurrencyType]([Id],[Version],[Name],[ShortName])");

                        for (int i = 0; i < names.Count; i++)
                        {
                            var param = names[i].Split('(');
                            param[0] = GeneratorHelper.RemoveDigits(param[0]);
                            param[1] = param[1].Remove(param[1].Length - 1, 1);
                            var str = string.Format("SELECT '{0}',{1}, '{2}', '{3}'", GeneratorHelper.ToGuid(i), 1, param[0], param[1]);

                            if (i == names.Count - 1)
                            {
                                sw.WriteLine(str);
                            }
                            else
                            {
                                sw.WriteLine(str + " UNION ALL");
                            }
                        }
                        sw.WriteLine("GO");
                    }
                }
            }
        }
        
        public List<string> GetCurrencyTypesLines()
        {
            var names = new List<string>
                {
                    Byr
                };

            var di = new DirectoryInfo(_pathToSolution + PathToDocuments);
            var files = di.GetFiles("*.txt");
            foreach (var file in files)
            {
                var encoding = GeneratorHelper.GetEncodingType(file.FullName);
                using (var fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    using (var sr = new StreamReader(fs, encoding))
                    {
                        while (!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();
                            if (line != null && line.Contains(LineKey))
                            {
                                var textLines = line.Split('\t');
                                foreach (var text in textLines.Skip(1))
                                {
                                    if (!names.Contains(text))
                                    {
                                        names.Add(text);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return names;
        }

    }
}
