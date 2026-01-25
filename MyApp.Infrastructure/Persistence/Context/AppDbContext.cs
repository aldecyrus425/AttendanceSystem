using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }

        public DbSet<GradeLevel> GradeLevels { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Parents> Parents { get; set; }
        public DbSet<StudentParent> StudentParents { get; set; }
        public DbSet<AttendanceRecords> AttendanceRecords { get; set; }
    }
}
