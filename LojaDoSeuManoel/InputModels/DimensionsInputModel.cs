using System.ComponentModel.DataAnnotations;

namespace LojaDoSeuManoel.Models
{
    public class DimensionsInputModel
    {
        [Required(ErrorMessage = "A altura é obrigatória.")]
        public int Height { get; set; }

        [Required(ErrorMessage = "A largura é obrigatória.")]
        public int Width { get; set; }

        [Required(ErrorMessage = "O comprimento é obrigatório.")]
        public int Length { get; set; }
    }
}
