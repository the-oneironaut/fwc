﻿using FlatworldConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatworldConnect.DataAccess.Repository.IRepository
{
    public interface IResourceRepository : IRepository<Resource>
    {
        void Update(Resource obj);
    }
}
