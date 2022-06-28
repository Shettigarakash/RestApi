
using System.ComponentModel.DataAnnotations;

namespace TaskManage.Model
{
    public class Tasks
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        
        public string Description { get; set; }
    }
}
