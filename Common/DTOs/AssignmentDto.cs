using System.ComponentModel.DataAnnotations;

namespace Common.DTOs
{
    public class AssignmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsRecurring { get; set; }
        public bool IsFinished { get; set; }
        public int AssignmentTypeId {  get; set; }  
        public virtual AssignmentTypeDto AssignmentType { get; set; }
    }
}