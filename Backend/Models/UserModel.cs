using System;
using System.Collections.Generic;
namespace Backend.Models
{
	public class UserModel
	{
		public int Id { get; set; }

		public required string Name { get; set; }

        public required string Email { get; set; }

        public virtual ICollection<TaskModel> Tasks { get; set; } = new List<TaskModel>();
    }
}

