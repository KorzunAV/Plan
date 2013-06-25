using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Data.Test.Генерация_БД
{
    public class ExchangeArchiveGenerator
    {
        private const string PathToDocuments = @"Documents\";
        private const string PathToExchangeArchiveSql = @"{0}Scripts\Наполнение БД\ExchangeArchive\ExchangeArchive_{1}.sql";
        private const string LineKey = "Дата";

        public string PathToSolution;
        public Guid IdMainCurrencyTypes;
        private readonly List<string> _currencyTypesNames;

        private struct RatioSet
        {
            public DateTime DateTime;
            public double Ratio;
        }

        public ExchangeArchiveGenerator(List<string> currencyTypesNames, string maincurrencyTypesName, string pathToSolution)
        {
            _currencyTypesNames = currencyTypesNames;
            IdMainCurrencyTypes = GeneratorHelper.ToGuid(currencyTypesNames.IndexOf(maincurrencyTypesName));
            PathToSolution = pathToSolution;
        }

        public void Execute()
        {
            if (_currencyTypesNames.Count > 1)
            {
                for (short i = 1; i < _currencyTypesNames.Count; i++)
                {
                    string abr = _currencyTypesNames[i];
                    abr = abr.Remove(abr.Length - 1).Remove(0, abr.IndexOf("(") + 1);
                    string filePath = string.Format(PathToExchangeArchiveSql, PathToSolution, abr);
                    using (var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        using (var sw = new StreamWriter(fs, Encoding.Unicode))
                        {
                            sw.WriteLine("INSERT INTO [TestPlan].[dbo].[ExchangeArchive]([Id],[Version],[Date],[Ratio],[FirstCurrency_id],[SecondCurrency_id])");
                            var ratios = GetRatios(_currencyTypesNames[i]);

                            for (int j = 0; j < ratios.Count; j++)
                            {
                                var str = string.Format("SELECT '{0}',{1},'{2}', {3},'{4}','{5}'",
                                    GeneratorHelper.ToGuid(i, j),
                                    1,
                                    ratios[j].DateTime.ToString(CultureInfo.InvariantCulture),
                                    ratios[j].Ratio.ToString(CultureInfo.InvariantCulture),
                                    IdMainCurrencyTypes,
                                    GeneratorHelper.ToGuid(i));
                                if (j < ratios.Count - 1)
                                {
                                    sw.WriteLine(str + " UNION ALL");
                                }
                                else
                                {
                                    sw.WriteLine(str);
                                }
                            }
                            sw.WriteLine("GO");
                        }
                    }
                }
            }
        }

        private List<RatioSet> GetRatios(string colName)
        {
            var ratios = new List<RatioSet>();
            var di = new DirectoryInfo(PathToSolution + PathToDocuments);
            var files = di.GetFiles("*.txt");
            foreach (var file in files)
            {
                int id = -1;
                var encoding = GeneratorHelper.GetEncodingType(file.FullName);
                using (var fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                using (var sr = new StreamReader(fs, encoding))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        if (line != null)
                        {
                            if (line.Contains(LineKey))
                            {
                                var textLines = line.Split('\t');

                                for (int i = 0; i < textLines.Length; i++)
                                {
                                    if (textLines[i] == colName)
                                    {
                                        id = i;
                                        break;
                                    }
                                }
                            }
                            else if (id != -1)
                            {
                                var textLines = line.Split('\t');

                                try
                                {
                                    if (textLines[0].Length == 10 && !string.IsNullOrEmpty(textLines[id]))
                                    {
                                        ratios.Add(new RatioSet
                                        {
                                            DateTime = Convert.ToDateTime(textLines[0]),
                                            Ratio = Convert.ToDouble(textLines[id])
                                        });
                                    }

                                }
                                catch (Exception exception)
                                {
                                    throw;
                                }
                            }
                        }
                    }
                }
            }
            return ratios;
        }
    }
}
