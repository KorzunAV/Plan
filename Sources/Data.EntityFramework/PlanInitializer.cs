using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Entities.Entity;

namespace Data.EntityFramework
{
	public class PlanInitializer : DropCreateDatabaseIfModelChanges<PlanContext>
	{
		private void AddCurrencyType(PlanContext context)
		{
			var currencyTypes = new List<CurrencyType>
            {
                new CurrencyType { Name = "Бакс"},
                new CurrencyType { Name = "Евро"},
                new CurrencyType { Name = "Бревно"},
			};
			currencyTypes.ForEach(s => context.CurrencyType.Add(s));
			context.SaveChanges();
		}

		private void AddTransferType(PlanContext context)
		{
			var transferTypes = new List<TransferType>
            {
                new TransferType { Name = "Расход"},
                new TransferType { Name = "Доход"},
                new TransferType { Name = "Перевод"},
			};
			transferTypes.ForEach(s => context.TransferType.Add(s));
			context.SaveChanges();
		}

		private void AddUserRole(PlanContext context)
		{
			var userRoles = new List<UserRole>
            {
                new UserRole { Name = "Пользователь"},
                new UserRole { Name = "Админ"},
                new UserRole { Name = "Клиент"},
			};
			userRoles.ForEach(s => context.UserRole.Add(s));
			context.SaveChanges();
		}

		private void AddSystemUser(PlanContext context)
		{
			var userRoleId = context.UserRole.First().Id;
			var systemUsers = new List<SystemUser>
            {
                new SystemUser{Name = "Имя",UserRoleID = userRoleId},
			};
			systemUsers.ForEach(s => context.SystemUser.Add(s));
			context.SaveChanges();
		}

		private void AddTransferSubType(PlanContext context)
		{
			var guid = context.TransferType.First().Id;
			var transferSubTypes = new List<TransferSubType>
            {
                new TransferSubType { Name = "Транспорт", TransferTypeID = guid},
                new TransferSubType { Name = "Еду", TransferTypeID  = guid},
                new TransferSubType { Name = "Учеба", TransferTypeID = guid},
			};
			transferSubTypes.ForEach(s => context.TransferSubType.Add(s));
			context.SaveChanges();
		}

		private void AddTag(PlanContext context)
		{
			var guid = context.SystemUser.First().Id;
			var tags = new List<Tag>
            {
                new Tag { Name = "на транспорт" , SystemUserID = guid},
			};
			tags.ForEach(s => context.Tag.Add(s));
			context.SaveChanges();
		}

		private void AddCashAccount(PlanContext context)
		{
			var systemUserGuid = context.SystemUser.First().Id;
			var currencyTypeGuid = context.CurrencyType.First().Id;
			var cashAccounts = new List<CashAccount>
            {
                new CashAccount {Name = "Первый Счет", SystemUserID = systemUserGuid, CurrencyTypeID = currencyTypeGuid },
			};
			cashAccounts.ForEach(s => context.CashAccount.Add(s));
			context.SaveChanges();
		}

		private void AddExchangeArchive(PlanContext context)
		{
			var firstCurrencyId = context.CurrencyType.First().Id;
			var secondCurrencyId = context.CurrencyType.Last().Id;
			var exchangeArchives = new List<ExchangeArchive>
            {
                new ExchangeArchive
                {
					Date = DateTime.Now,
					FirstCurrencyID = firstCurrencyId,
					SecondCurrencyID = secondCurrencyId,
					Ratio = 2
                },
			};
			exchangeArchives.ForEach(s => context.ExchangeArchive.Add(s));
			context.SaveChanges();
		}

		private void AddСashTransfer(PlanContext context)
		{
			var currencyTypeId = context.CurrencyType.First().Id;
			var senderCashAccountId = context.CashAccount.First().Id;
			var receiverCashAccountId = context.CashAccount.First().Id;
			var transferTypeId = context.TransferType.First().Id;
			var transferSubTypeId = context.TransferSubType.First().Id;

			var сashTransfers = new List<СashTransfer>
            {
                new СashTransfer
                {
					TransferCount = 0,
					CurrencyTypeID = currencyTypeId,
					SenderCashAccountID = senderCashAccountId,
					ReceiverCashAccountID = receiverCashAccountId,
					TransferTypeID = transferTypeId,
					Comment = "комент",
					TransferSubTypeID = transferSubTypeId
                },
			};
			сashTransfers.ForEach(s => context.СashTransfer.Add(s));
			context.SaveChanges();
		}


		protected override void Seed(PlanContext context)
		{
			AddCurrencyType(context);
			AddUserRole(context);
			AddSystemUser(context);
			AddTransferType(context);
			AddTransferSubType(context);
			AddTag(context);
			AddCashAccount(context);
			AddExchangeArchive(context);
			AddСashTransfer(context);

			var adapter = (IObjectContextAdapter)context;
			string script = adapter.ObjectContext.CreateDatabaseScript();
			context.Database.ExecuteSqlCommand(script);
		}
	}
}
