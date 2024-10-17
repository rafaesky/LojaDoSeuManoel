namespace LojaDoSeuManoel.Models
{
    public class PackagingResultViewModel
    {
        public string Pedido_Id { get; set; }
        public List<PackingResultViewModel> Caixas { get; set; }
    }

}
