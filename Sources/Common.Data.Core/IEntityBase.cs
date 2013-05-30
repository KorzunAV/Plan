namespace Common.Data.Core
{
	public interface IEntityBase
	{
		int Id { get; set; }
		int Version { get; set; }
	}
}