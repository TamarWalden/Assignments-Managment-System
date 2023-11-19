using AutoMapper;
using Common;
using Common.DTOs;
using Microsoft.Identity.Client;
using Repositories.Entities;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AssignmentService: IAssignmentService
    {
        private readonly IRepository<Assignment> assignmentRepository;
        private readonly IRepository<AssignmentType> assignmentTypeRepository;
        private readonly IMapper mapper;

        public AssignmentService(IRepository<Assignment> assignmentRepository, IRepository<AssignmentType> assignmentTypeRepository, IMapper mapper)
        {
            this.assignmentRepository = assignmentRepository;
            this.assignmentTypeRepository = assignmentTypeRepository;
            this.mapper = mapper;
        }

        public async Task<AssignmentDto> AddNewAssignmentAsync(AssignmentDto assignment)
        {

            var newAssignment = await assignmentRepository.AddAsync(mapper.Map<Assignment>(assignment));
            return mapper.Map<AssignmentDto>(newAssignment);
        }

        public async Task MarkAssignmentAsFinished(AssignmentDto assignment)
        {
            assignment.EndDate = DateTime.Now;
            assignment.IsFinished = true;
            var updatedAssignment=await assignmentRepository.UpdateAsync(mapper.Map<Assignment>(assignment));
        }

        public async Task DeleteAsync(int id)
        {
            await assignmentRepository.DeleteAsync(id);
        }

        public async Task<List<AssignmentDto>> GetAssignmentsByDescendingDateOrderAsync()
        {
            var assignments = await assignmentRepository.GetAllAsync();
            var assignmentsSorted = assignments.OrderBy(a => a.StartDate).ToList();
            var assignmentsDto = mapper.Map<List<AssignmentDto>>(assignmentsSorted);
            return assignmentsDto;
        }
        public async Task<List<AssignmentDto>> GetAssignmentsByPageing(GetDataParameters assignmentsParameters)
        {
            var assignments= await assignmentRepository.GetAllByPagingAsync(assignmentsParameters);
            return mapper.Map<List<AssignmentDto>>(assignments);
        }

        public async Task<AssignmentDto> GetByIdAsync(int id)
        {
            var assignment = await assignmentRepository.GetByIdAsync(id);
            return mapper.Map<AssignmentDto>(assignment);
        }

        public async Task<List<AssignmentTypeDto>> GetAssignmentsTypesAsync()
        {
            var assignmentsTypes = await assignmentTypeRepository.GetAllAsync();
            var assignmentsTypesDto = mapper.Map<List<AssignmentTypeDto>>(assignmentsTypes);
            return assignmentsTypesDto;
        }
    }
}
