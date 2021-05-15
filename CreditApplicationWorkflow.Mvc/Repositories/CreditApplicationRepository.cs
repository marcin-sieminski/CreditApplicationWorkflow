﻿using System.Collections.Generic;
using System.Linq;
using CreditApplicationWorkflow.DataAccess;
using CreditApplicationWorkflow.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreditApplicationWorkflow.Mvc.Repositories
{
    public class CreditApplicationRepository : ICreditApplicationRepository
    {
        private readonly CreditApplicationWorkflowDbContext _creditApplicationWorkflowDbContext;

        public CreditApplicationRepository(CreditApplicationWorkflowDbContext creditApplicationWorkflowDbContext)
        {
            _creditApplicationWorkflowDbContext = creditApplicationWorkflowDbContext;
        }

        public IEnumerable<CreditApplication> GetAllCreditApplications { get => _creditApplicationWorkflowDbContext.CreditApplications
            .Include(x => x.Customer)
            .Include(x => x.ApplicationStatus)
            .Include(x => x.Employee)
            .Include(x => x.ProductType); }

        public CreditApplication GetCreditApplicationById(int id)
        {
            return _creditApplicationWorkflowDbContext.CreditApplications.FirstOrDefault(c => c.Id == id);
        }
    }
}
