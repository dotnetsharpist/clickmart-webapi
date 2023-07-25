using ClickMart.DataAccess.Common.Interfaces;
using ClickMart.DataAccess.ViewModels.Deliveries;
using ClickMart.Domain.Entities.Deliveries;

namespace ClickMart.DataAccess.Interfaces.Deliveries;

public interface IDeliveryRepository : IRepository<Deliver,Deliver> ,
    IGetAll<DeliverViewModel>
{
    public Task<DeliverViewModel> GetDeliverAsync(long id);
}
