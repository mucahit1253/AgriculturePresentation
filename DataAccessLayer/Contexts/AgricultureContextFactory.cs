using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Contexts
{
    public class AgricultureContextFactory : IDesignTimeDbContextFactory<AgricultureContext>
    {
        public AgricultureContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AgricultureContext>();
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=DbAgriculture;Trusted_Connection=True;TrustServerCertificate=True;");
            return new AgricultureContext(optionsBuilder.Options);
        }
    }
}
