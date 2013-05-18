﻿using System;
using System.Data;
using System.Data.SqlClient;
using Entities.Entity;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Data.NHibernate
{
	public class NHibernateBase
	{
		#region [Fields]

		// Key name for DB connection string. The string must be in config file.
		private const string Name = "DbConnectionString";
		private static string _connectionString;
		private static ISessionFactory _sessionFactory;
		private IDbConnection _connection;

		#endregion [Fields]

		#region [Property]

		public static string ConnectionString
		{
			get
			{
				if (string.IsNullOrEmpty(_connectionString))
				{
					var settings = System.Configuration.ConfigurationManager.ConnectionStrings[Name];

					if (settings != null)
					{
						_connectionString = settings.ConnectionString;
					}
				}

				return _connectionString;
			}
			set { _connectionString = value; }
		}

		private static ISessionFactory SessionFactory
		{
			get
			{
				if (_sessionFactory == null)
				{
					var conf = Fluently.Configure();
					conf.Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString).ShowSql());
					conf.Mappings(m => m.AutoMappings.Add(CreateAutomappings));
					conf.ExposeConfiguration(BuildSchema);
					_sessionFactory = conf.BuildSessionFactory();
				}
				return _sessionFactory;
			}
		}

		protected virtual ISession Session { get; private set; }

		#endregion [Property]

		public void AutoGenerateDB()
		{
			var conf = Fluently.Configure();
			conf.Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString).ShowSql());
			conf.Mappings(m => m.AutoMappings.Add(CreateAutomappings));
			conf.ExposeConfiguration(BuildSchema);
			conf.BuildSessionFactory();
		}

		protected bool Connect()
		{
			if (Session == null || _connection == null)
			{
				if (Session != null)
				{
					Disconnect();
				}

				if (_connection == null)
				{
					_connection = new SqlConnection(ConnectionString);
					_connection.Open();
				}
				Session = SessionFactory.OpenSession(_connection);
			}
			return (_connection.State == ConnectionState.Open);
		}

		protected bool Disconnect()
		{
			try
			{
				if ((_connection != null) && (_connection.State == ConnectionState.Open))
				{
					_connection.Close();
					_connection = null;
				}

				Session.Disconnect();
				Session.Close();
			}
			catch
			{
				return false;
			}
			return true;
		}


		protected TReult TryExecute<TReult>(Func<TReult> expression)
		{
			try
			{
				Connect();
				TReult rez = expression();
				return rez;
			}
			finally
			{
				Disconnect();
			}
		}

		private static void BuildSchema(Configuration config)
		{
			new SchemaExport(config).Create(false, true);
		}

		static AutoPersistenceModel CreateAutomappings()
		{
			// This is the actual automapping - use AutoMap to start automapping,
			// then pick one of the static methods to specify what to map (in this case
			// all the classes in the assembly that contains Employee), and then either
			// use the Setup and Where methods to restrict that behaviour, or (preferably)
			// supply a configuration instance of your definition to control the automapper.
			return AutoMap.AssemblyOf<EntityBase>(new AutomappingConfiguration())
				.Conventions.Add<CascadeConvention>();
		}
	}
}