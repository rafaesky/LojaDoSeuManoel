
namespace LojaDoSeuManoel.Models
{
    public class Dimensions
    {
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }
        public Dimensions(int altura, int largura, int comprimento)
        {
            Altura = altura;
            Largura = largura;
            Comprimento = comprimento;
        }
    }
}
