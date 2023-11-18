using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class AssignmentTypeRepository : IRepository<AssignmentType>
    {
        private readonly IContext context;
        public AssignmentTypeRepository(IContext context)
        {
            this.context = context;
        }
        public Task<AssignmentType> AddAsync(AssignmentType entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AssignmentType>> GetAllAsync()
        {
            return await context.AssignmentsTypes.ToListAsync();
        }

        public Task<AssignmentType> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AssignmentType> UpdateAsync(AssignmentType entity)
        {
            throw new NotImplementedException();
        }
    }
}
