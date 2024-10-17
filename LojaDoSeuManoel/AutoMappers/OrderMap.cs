using LojaDoSeuManoel.Models;

namespace LojaDoSeuManoel.AutoMappers
{
    public class OrderMap : AutoMapper.Profile
    {
        public OrderMap()
        {
            //Input
            CreateMap<OrderInputModel, Order>();
            CreateMap<OrderListInputModel, OrderList>();
            CreateMap<ProductInputModel, Product>();
            CreateMap<DimensionsInputModel, Dimensions>();



            //ViewModel
            CreateMap<Order, OrderViewModel>();
        }
    }
}
