using FlatworldConnect.DataAccess.Repository.IRepository;
using FlatworldConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatworldConnect.DataAccess.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly ApplicationDbContext _db;

        public ProjectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

      

        public void Update(Project obj)
        {
            var objFromDb = _db.projects.FirstOrDefault(u=>u.projectId == obj.projectId);
            if (objFromDb != null)
            {
                objFromDb.projectName = obj.projectName;
                objFromDb.projectDesc = obj.projectDesc;
                objFromDb.projectStartDate = obj.projectStartDate;
                objFromDb.projectEndDate = obj.projectEndDate;
                objFromDb.customerId = obj.customerId;
                objFromDb.PMId = obj.PMId;
            }
        }
    }
}
