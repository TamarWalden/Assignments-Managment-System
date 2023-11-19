using Common;
using Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Services.Interfaces;
using Services.Services;

namespace Assignments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        readonly IAssignmentService assignmentService;
        public AssignmentController(IAssignmentService service)
        {
            assignmentService = service;
        }


        // POST api/<ValuesController>
        [HttpPost]
        public async Task AddNewAssignment(AssignmentDto newAssignment)
        {
            try
            {
                await assignmentService.AddNewAssignmentAsync(newAssignment);
            }
            catch (Exception ex) { }
        }

        [HttpPut]
        public async Task MarkAssignmentAsFinished(AssignmentDto assignment)
        {
            await assignmentService.MarkAssignmentAsFinished(assignment);
        }
        [HttpDelete("DeleteAssignment/{id}")]
        public async Task DeleteAssignment(int id)
        {
            await assignmentService.DeleteAsync(id);
        }
        [HttpGet]
        [Route("GetAssignments")]
        public async Task<List<AssignmentDto>> GetAssignmentsByDescendingDateOrderAsync()
        {
            return await assignmentService.GetAssignmentsByDescendingDateOrderAsync();
        }

        [HttpGet]
        public Task<List<AssignmentDto>> GetOwners([FromQuery] GetDataParameters assignmentsParameters)
        {
            return assignmentService.GetAssignmentsByPageing(assignmentsParameters);
        }

        [HttpGet]
        [Route("GetAssignment/{id}")]
        public async Task<AssignmentDto> GetById(int id)
        {
            return await assignmentService.GetByIdAsync(id);
        }

        [HttpGet]
        [Route("GetAssignmentsTypes")]
        public async Task<List<AssignmentTypeDto>> GetAssignmentsTypesAsync()
        {
            return await assignmentService.GetAssignmentsTypesAsync();
        }

    }
}
