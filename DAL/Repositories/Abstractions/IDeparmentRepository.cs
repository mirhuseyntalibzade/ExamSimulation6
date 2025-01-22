using CORE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Abstractions
{
    public interface IDeparmentRepository : IRepository<Department>
    {
        Task<ICollection<SelectListItem>> SelectAllDepartments();
    }
}
