using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAssignmentService
    {
        Task<AssignmentDto> AddNewAssignmentAsync(AssignmentDto assignment);
        Task MarkAssignmentAsFinished(AssignmentDto assignment);
        Task DeleteAsync(int id);
        Task<AssignmentDto> GetByIdAsync(int id);
        Task<List<AssignmentDto>> GetAssignmentsByDescendingDateOrderAsync();
        Task<List<AssignmentTypeDto>> GetAssignmentsTypesAsync();
    }
}
