using LojaDoSeuManoel.Models;
using LojaDoSeuManoel.Services;

namespace LojaDoSeuManoel.Tests
{
    public class OrderServiceTests
    {
        private readonly OrderService _orderService;

        public OrderServiceTests()
        {
            _orderService = new OrderService();
        }

        [Fact]
        public async Task PackOrder_ShouldReturnOrderViewModel_WithCorrectNumberOfPedidos()
        {
            // Arrange
            var order = new Order
            {
                Pedidos = new List<OrderList>
                {
                    new OrderList
                    {
                        Pedido_Id = 1,
                        Produtos = new List<Product>
                        {
                            new Product { Produto_Id = "P1", Dimensoes = new Dimensions(10, 10, 10) },
                            new Product { Produto_Id = "P2", Dimensoes = new Dimensions(20, 20, 20) }
                        }
                    }
                }
            };

            // Act
            var result = await _orderService.PackOrder(order);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.Pedidos);
            Assert.Equal("1", result.Pedidos[0].Pedido_Id);
        }

        [Fact]
        public async Task PackOrders_ShouldPackProductsInBoxes_Correctly()
        {
            // Arrange
            var orderList = new OrderList
            {
                Pedido_Id = 1,
                Produtos = new List<Product>
                {
                    new Product { Produto_Id = "P1", Dimensoes = new Dimensions(10, 10, 10) },
                    new Product { Produto_Id = "P2", Dimensoes = new Dimensions(20, 20, 20) },
                    new Product { Produto_Id = "P3", Dimensoes = new Dimensions(40, 50, 60) }
                }
            };

            // Act
            var result = await _orderService.PackOrders(orderList);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("1", result.Pedido_Id);
            Assert.Equal(2, result.Caixas.Count);
            Assert.Contains(result.Caixas, c => c.Caixa_Id == "Box1" && c.Produtos.Contains("P1"));
            Assert.Contains(result.Caixas, c => c.Caixa_Id == "Box3" && c.Produtos.Contains("P3"));
        }

        [Fact]
        public void CanFitInBox_ShouldReturnTrue_WhenProductFitsInBox()
        {
            // Arrange
            var product = new Product { Dimensoes = new Dimensions(10, 10, 10) };
            var box = new Box("Box1", new Dimensions(20, 20, 20));

            // Act
            var result = _orderService.CanFitInBox(product, box);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanFitInBox_ShouldReturnFalse_WhenProductDoesNotFitInBox()
        {
            // Arrange
            var product = new Product { Dimensoes = new Dimensions(30, 30, 30) };
            var box = new Box("Box1", new Dimensions(20, 20, 20));

            // Act
            var result = _orderService.CanFitInBox(product, box);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetProductVolume_ShouldReturnCorrectVolume()
        {
            // Arrange
            var product = new Product { Dimensoes = new Dimensions(10, 20, 30) };

            // Act
            var result = _orderService.GetProductVolume(product);

            // Assert
            Assert.Equal(6000, result); // 10 * 20 * 30 = 6000
        }
    }
}
