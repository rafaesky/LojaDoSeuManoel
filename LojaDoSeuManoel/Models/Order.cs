namespace LojaDoSeuManoel.Models
{
    public class Order
    {
        public List<OrderList> Pedidos { get; set; }
    }
    public class OrderList
    {
        public int Pedido_Id { get; set; }
        public List<Product> Produtos { get; set; }
    }
}
