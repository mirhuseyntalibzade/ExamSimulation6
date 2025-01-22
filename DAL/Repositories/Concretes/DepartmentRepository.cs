using CORE.Models;
using DAL.Contexts;
using DAL.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Concretes
{
    public class DepartmentRepository : Repository<Department>, IDeparmentRepository
    {
        readonly AppDBContext _context;
        public DepartmentRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<SelectListItem>> SelectAllDepartments()
        {
            return await _context.Departments.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Title
            }).ToListAsync();
        }
    }
}
