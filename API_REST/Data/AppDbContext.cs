using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_REST.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Tarefa> Tarefas => Set<Tarefa>();
    }
}