
namespace Common.Web
{
	public interface IApplicationStorage
	{
		object this[string name] { get; set; }
		object this[int index] { get; }
	}
}
