using System;
using System.IO;
using System.Text.RegularExpressions;
using Common.Data.Core;
using Common.Data.Core.Conditions;
using Entities;
using System.Linq;

namespace Data.Test.Генерация_БД
{
    public class MyDateSetter
    {
        private IBaseDao Dao { get; set; }
        private readonly string _pathToSolution;
        private const string PathToFile = @"Documents\Инфа по счету\счет.txt";

        public MyDateSetter(string pathToSolution, IBaseDao dao)
        {
            _pathToSolution = pathToSolution;
            Dao = dao;
        }


        public void Execute()
        {
            if (!Dao.IsExist<CurrencyType>(new SelectCondition()))
            {
                GenerateCurrencyType();
            }
            GenerateTransactions();
        }

        private void GenerateCurrencyType()
        {
            var generator = new CurrencyTypeGenerator(_pathToSolution);
            var names = generator.GetCurrencyTypesLines();

            foreach (string name in names)
            {
                string fullName = name.Substring(0, name.LastIndexOf('('));
                string shortName = name.Substring(name.LastIndexOf('(') + 1, 3);
                fullName = GeneratorHelper.RemoveDigits(fullName);

                var currencyType = new CurrencyType
                    {
                        Name = fullName,
                        ShortName = shortName
                    };


                var condition = new SelectCondition();
                var rule = new Rule(ClassNameHelper.GetFieldName<CurrencyType>(p => p.ShortName), Rule.Operations.Like,
                                    shortName);
                condition.Where.Rules.Add(rule);
                if (!Dao.IsExist<CurrencyType>(condition))
                {
                    Dao.SaveOrUpdate(currencyType);
                }
            }
        }


        public void GenerateTransactions()
        {
            if (File.Exists(_pathToSolution + PathToFile))
            {
                var fileInfo = new FileInfo(_pathToSolution + PathToFile);
                FileHelper.ReadByLine(fileInfo, LineExplorer);
            }
        }

        private void LineExplorer(string line)
        {
            if (Regex.Match(line, "[0-9]").Success)
            {
                var valies = line.Split('\t');
                var transaction = new Transaction();
                transaction.RegistrationDate = valies[0].ToNullableDateTime();
                transaction.TransactionDate = valies[1].ToNullableDateTime();
                transaction.TransactionNumber = valies[2];
                transaction.TransactionCode = valies[3];
                transaction.CurrencyType = GetCurrencyType(valies[4]);
                transaction.Value = Convert.ToDecimal(valies[5]);
                Dao.SaveOrUpdate(transaction);
            }
        }

        private CurrencyType GetCurrencyType(string shortName)
        {
            shortName = shortName.Trim();
            var condition = new SelectCondition();
            var rule = new Rule(ClassNameHelper.GetFieldName<CurrencyType>(p => p.ShortName), Rule.Operations.Like, shortName);
            condition.Where.Rules.Add(rule);
            var result = Dao.SelectRange<CurrencyType>(condition);
            if (result.ItemsCount > 0)
            {
                return result.Result.First();
            }
            return null;
        }
    }
}
