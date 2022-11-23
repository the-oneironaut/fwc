using FlatworldConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatworldConnect.DataAccess.Repository.IRepository
{
    public interface IProjectManagerRepository : IRepository<ProjectManager>
    {
        void Update(ProjectManager obj);
    }
}
