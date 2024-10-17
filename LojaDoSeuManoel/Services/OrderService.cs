using LojaDoSeuManoel.Models;

namespace LojaDoSeuManoel.Services
{
    public class OrderService : IOrderService
    {
        //Lidando com o pedido completo
        public async Task<OrderViewModel> PackOrder(Order order)
        {
            var orderViewModel = new OrderViewModel();
            orderViewModel.Pedidos = new List<PackagingResultViewModel>();

            foreach (var orderList in order.Pedidos)
            {
                var result = await PackOrders(orderList);
                orderViewModel.Pedidos.Add(result); 
            }

            return orderViewModel;
        }

        //Tratando cada pedido separadamente
        public async Task<PackagingResultViewModel> PackOrders(OrderList order)
        {
            var response = new PackagingResultViewModel
            {
                Pedido_Id = order.Pedido_Id.ToString(),
                Caixas = new List<PackingResultViewModel>()
            };

            var remainingProducts = new List<Product>(order.Produtos);

            //Lista das caixas disponíveis
            var availableBoxes = new List<Box>
                {
                    new Box("Box1", new Dimensions(30, 40, 80)),
                    new Box("Box2", new Dimensions(80, 50, 40)),
                    new Box("Box3", new Dimensions(50, 80, 60))
                };

            while (remainingProducts.Count > 0)
            {
                var boxUsed = false;

                foreach (var box in availableBoxes)
                {
                    var packingResult = new PackingResultViewModel
                    {
                        Caixa_Id = box.Caixa_Id,
                        Produtos = new List<string>()
                    };

                    double boxVolume = box.Dimensoes.Altura * box.Dimensoes.Largura * box.Dimensoes.Comprimento;
                    double usedVolume = 0;

                    foreach (var product in remainingProducts.ToList())
                    {
                        if (CanFitInBox(product, box) && (usedVolume + GetProductVolume(product) <= boxVolume))
                        {
                            packingResult.Produtos.Add(product.Produto_Id);
                            usedVolume += GetProductVolume(product);
                            remainingProducts.Remove(product);
                        }
                    }

                    if (packingResult.Produtos.Count > 0)
                    {
                        response.Caixas.Add(packingResult);
                        boxUsed = true;
                        break; 
                    }
                }

                if (!boxUsed)
                {
                    break; 
                }
            }

            if (remainingProducts.Count > 0)
            {
                var packingResult = new PackingResultViewModel
                {
                    Caixa_Id = null,
                    Produtos = remainingProducts.Select(p => p.Produto_Id).ToList(),
                    Observacao = "Produto não cabe em nenhuma caixa disponível."
                };
                response.Caixas.Add(packingResult);
            }

            return response;
        }

        public bool CanFitInBox(Product product, Box box)
        {
            return (product.Dimensoes.Altura <= box.Dimensoes.Altura &&
                    product.Dimensoes.Largura <= box.Dimensoes.Largura &&
                    product.Dimensoes.Comprimento <= box.Dimensoes.Comprimento);
        }


        public double GetProductVolume(Product product)
        {
            return product.Dimensoes.Altura * product.Dimensoes.Largura * product.Dimensoes.Comprimento;
        }

    }
}
