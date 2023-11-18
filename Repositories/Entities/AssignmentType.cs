using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    public class AssignmentType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }    
    }
}
