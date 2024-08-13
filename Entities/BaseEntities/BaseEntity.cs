namespace Entities.BaseEntities
{
	public class BaseEntity : IEntity
	{
		public int Id { get; set; }
		public DateTime CreatedTime { get; set; } = DateTime.Now;
	}
}
