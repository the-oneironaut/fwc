using FlatworldConnect.DataAccess.Repository.IRepository;
using FlatworldConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatworldConnect.DataAccess.Repository
{
    public class ResourceRepository : Repository<Resource>, IResourceRepository
    {
        private readonly ApplicationDbContext _db;

        public ResourceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

      

        public void Update(Resource obj)
        {
            var objFromDb = _db.resources.FirstOrDefault(u=>u.resourceId == obj.resourceId);
            if (objFromDb != null)
            {
                objFromDb.projectId = obj.projectId;
                objFromDb.customerId = obj.customerId;
                objFromDb.jobTitle = obj.jobTitle;
                objFromDb.skillSet = obj.skillSet;
                objFromDb.experience = obj.experience;
                objFromDb.noOfMonths = obj.noOfMonths;
                objFromDb.startDate = obj.startDate;
                objFromDb.endDate = obj.endDate;
                objFromDb.noOfResources = obj.noOfResources;
            }
        }
    }
}
