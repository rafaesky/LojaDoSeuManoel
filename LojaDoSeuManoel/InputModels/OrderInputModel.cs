using System.ComponentModel.DataAnnotations;

namespace LojaDoSeuManoel.Models
{
    public class OrderInputModel
    {
        public List<OrderListInputModel> Pedidos { get; set; }
    }
    public class OrderListInputModel
    {
        [Required(ErrorMessage = "O campo Id é obrigatório.")]
        public int Pedido_Id { get; set; }

        [Required(ErrorMessage = "A lista de produtos é obrigatória.")]
        [MinLength(1, ErrorMessage = "A lista de produtos deve conter pelo menos um produto.")]
        public List<ProductInputModel> Produtos { get; set; }
    }
}
