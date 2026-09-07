using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SaveMoney.Application.DTOs
{
    public class RoleDTO
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
