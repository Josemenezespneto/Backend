using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
	}
}

