using System.ComponentModel.DataAnnotations;

namespace TaskManage.Dtos
{
    public record CreateOrUpdateBookDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]

        public string Description { get; set; }
    }
}
