sqlcmd -U Test -P 12345 -S (local) -H TestPlan -i CurrencyType.sql
sqlcmd -U Test -P 12345 -S (local) -H TestPlan -i ExchangeArchive.sql
pause