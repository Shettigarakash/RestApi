using System.ComponentModel.DataAnnotations;

namespace TaskManage.Dtos
{
    public record TaskDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]

        public string Description { get; set; }
    }
}
