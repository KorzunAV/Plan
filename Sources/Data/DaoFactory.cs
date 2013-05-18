using System;
using System.Collections.Generic;
using System.Configuration;
using Entities.Entity;

namespace Data
{
	public static class DaoFactory
	{
		#region private const fields
		private const string DaoProviderConfig = "DaoProvider";
		private const string ConnectionTehnologyMessage = "ConnectionTehnology string did not found in config file.";
		private const string RefPath = "../../References";

		private static readonly string Namespace;
		private static readonly string AssemblyPath;

		private static Dictionary<string, object> _baseDaos = new Dictionary<string, object>();
		#endregion


		/// <summary>
		/// Provide factory for management of a data access layer. 
		/// </summary>
		static DaoFactory()
		{
			var config = ConfigurationManager.ConnectionStrings[DaoProviderConfig];
			if (config != null)
			{
				AssemblyPath = config.ConnectionString;
				Namespace = config.ProviderName;
			}
			else
			{
				throw new ArgumentNullException(DaoProviderConfig, ConnectionTehnologyMessage);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T GetDao<T>() where T : IBaseDao
		{
			string name = typeof(T).Name;
			if (!_baseDaos.ContainsKey(name))
			{
				var instance = (T)Activator.CreateInstance(typeof(T));
				_baseDaos.Add(name, instance);
			}
			return (T)_baseDaos[name];
		}
	}
}