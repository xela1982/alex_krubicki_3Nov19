using alex_krubicki_3Nov19.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace alex_krubicki_3Nov19.Repositories.Entities
{
    public class TakeAway2Context: DbContext
    {
        public TakeAway2Context(DbContextOptions<TakeAway2Context> options) : base(options)
        {

        }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<EmployeesCards> EmployeesCards { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
