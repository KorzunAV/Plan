using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace Data.Test.Генерация_БД
{
    [TestFixture]
    public class GenerateScripts
    {
        private string _pathToSolution;
        public string PathToSolution
        {
            get
            {
                if (string.IsNullOrEmpty(_pathToSolution))
                {
                    var directoryName = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                    if (directoryName != null)
                    {
                        _pathToSolution = directoryName.Remove(0, 6);
                        _pathToSolution = _pathToSolution.Remove(_pathToSolution.IndexOf("Sources", StringComparison.CurrentCultureIgnoreCase));
                    }
                }
                return _pathToSolution;
            }
        }

        [Test]
        public void Main()
        {
            var currencyTypeGenerator = new CurrencyTypeGenerator(PathToSolution);
            List<string> names = currencyTypeGenerator.GetCurrencyTypesLines();
            currencyTypeGenerator.Execute(names);

            var exchangeArchiveGenerator = new ExchangeArchiveGenerator(names, CurrencyTypeGenerator.Byr, PathToSolution);
            exchangeArchiveGenerator.Execute();

            Assert.Pass();
        }
    }
}
