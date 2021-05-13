﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CreditApplicationWorkflow.DataAccess
{
    public class CreditApplicationWorkflowDbContextFactory : IDesignTimeDbContextFactory<CreditApplicationWorkflowDbContext>
    {
        public CreditApplicationWorkflowDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CreditApplicationWorkflowDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=CreditApplicationWorkflow;Integrated Security=True");

            return new CreditApplicationWorkflowDbContext(optionsBuilder.Options);
        }
    }
}
