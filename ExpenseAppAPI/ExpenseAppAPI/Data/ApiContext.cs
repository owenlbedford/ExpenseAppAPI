using Microsoft.EntityFrameworkCore;
using ExpenseAppAPI.Models;

namespace ExpenseAppAPI.Data
{
    public class ApiContext : DbContext
    {

        public DbSet<ExpenseClaim> Claims { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
    }
}
