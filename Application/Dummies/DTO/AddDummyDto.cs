using System.ComponentModel.DataAnnotations;

namespace Application.Dummies.DTO
{
    public class AddDummyDto
    {
        [Required]
        public string RefrenceKey { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
