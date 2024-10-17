using System.ComponentModel.DataAnnotations;

namespace LojaDoSeuManoel.Models
{
    public class ProductInputModel
    {
        [Required(ErrorMessage = "O campo ProductId é obrigatório.")]
        [StringLength(50)]
        public string Produto_id { get; set; }

        [Required(ErrorMessage = "As dimensões são obrigatórias.")]
        public Dimensions Dimensoes { get; set; }
    }
}
