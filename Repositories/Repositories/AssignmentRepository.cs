using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repositories.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    internal class AssignmentRepository : IRepository<Assignment>
    {
        private readonly IContext context;
        public AssignmentRepository(IContext context)
        {
            this.context = context;
        }

        public async Task<Assignment> AddAsync(Assignment entity)
        {
            try
            {
                var newAssignment = await this.context.Assignments.AddAsync(entity);
                await context.SaveChangesAsync();
                return newAssignment.Entity;
            }
            catch (Exception ex)
            {
                return new Assignment();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var a = await GetByIdAsync(id);
            context.Assignments.Remove(a);
            await context.SaveChangesAsync();
        }

        public async Task<List<Assignment>> GetAllAsync()
        {
            return await context.Assignments.ToListAsync();
        }

        public async Task<Assignment> GetByIdAsync(int id)
        {
            //TODO: catch when there is no book whith this id
            return context.Assignments.FirstOrDefault(a => a.Id == id);
        }

        public async Task<Assignment> UpdateAsync(Assignment entity)
        {
            try
            {
                var assignmentToUpdate = context.Assignments.FirstOrDefault(a => a.Id == entity.Id);
                if (assignmentToUpdate != null)
                {
                    assignmentToUpdate.Name = entity.Name;
                    assignmentToUpdate.Description= entity.Description;
                    assignmentToUpdate.StartDate=entity.StartDate;
                    assignmentToUpdate.EndDate=entity.EndDate;
                    assignmentToUpdate.IsRecurring=entity.IsRecurring;
                    assignmentToUpdate.IsFinished = entity.IsFinished;
                    assignmentToUpdate.AssignmentType = entity.AssignmentType;

                }
                await context.SaveChangesAsync();
                return assignmentToUpdate;
            }
            catch(Exception ex)
            {    
                return new Assignment();
            }
        }
    }
}
