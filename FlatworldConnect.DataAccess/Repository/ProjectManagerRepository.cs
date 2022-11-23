using FlatworldConnect.DataAccess.Repository.IRepository;
using FlatworldConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatworldConnect.DataAccess.Repository
{
    public class ProjectManagerRepository : Repository<ProjectManager>, IProjectManagerRepository
    {
        private readonly ApplicationDbContext _db;

        public ProjectManagerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

      

        public void Update(ProjectManager obj)
        {
            _db.projectManagers.Update(obj);
        }
    }
}
