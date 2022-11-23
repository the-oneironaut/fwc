﻿using FlatworldConnect.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatworldConnect.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Customer = new CustomerRepository(_db);
            ProjectManager = new ProjectManagerRepository(_db);
            Project = new ProjectRepository(_db);
            Resource = new ResourceRepository(_db);
        }
        public ICustomerRepository Customer { get; private set; }
        public IProjectManagerRepository ProjectManager { get; private set; }
        public IProjectRepository Project { get; private set; }
        public IResourceRepository Resource { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
