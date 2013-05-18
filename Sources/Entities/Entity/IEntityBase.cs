namespace Entities.Entity
{
	public interface IEntityBase
	{
		int Id { get; set; }
		int Version { get; set; }
	}
}