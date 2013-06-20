using System.Web;

namespace Common.Web
{
	public class ApplicationStorage : IApplicationStorage
	{
		public object this[string name]
		{
			get
			{
				return HttpContext.Current.Application[name];
			}
			set
			{
				HttpContext.Current.Application[name] = value;
			}
		}

		public object this[int index]
		{
			get
			{
				return HttpContext.Current.Application[index];
			}
		}
	}
}