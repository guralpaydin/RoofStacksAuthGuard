﻿using Employee.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
