using System;

namespace Common.Data.Core
{
	public interface IEntityBase
	{
        Guid Id { get; set; }
		int Version { get; set; }
	}
}