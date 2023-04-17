using System;
namespace minimalApi.Model.DTO
{
	public class PizzaDTO
	{
        public int Id { get; set; }
		public string? Name { get; set; }
		public DateTime? CreatedAt { get; set; }
	}
}

