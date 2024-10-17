namespace LojaDoSeuManoel.Models
{
    public class Box
    {
        public string Caixa_Id { get; set; }
        public Dimensions Dimensoes { get; set; }

        public Box(string caixa_Id, Dimensions dimensoes)
        {
            Caixa_Id = caixa_Id;
            Dimensoes = dimensoes;
        }
    }
}
