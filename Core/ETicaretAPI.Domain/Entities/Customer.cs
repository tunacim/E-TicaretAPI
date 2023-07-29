using System;
using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Domain.Entities
{
	public class Customer:BaseEntity
	{
		public ICollection<Order> Orders { get; set; }

		public string Name { get; set; }

	}
}

