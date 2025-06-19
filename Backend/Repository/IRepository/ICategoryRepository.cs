using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {

        void Update(Category obj);
    }
}