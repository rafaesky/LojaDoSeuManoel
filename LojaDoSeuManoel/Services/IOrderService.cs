using LojaDoSeuManoel.Models;

namespace LojaDoSeuManoel.Services
{
    public interface IOrderService
    {
        Task<OrderViewModel> PackOrder(Order order);

    }
}
