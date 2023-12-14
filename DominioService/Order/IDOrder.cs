using EntityRequest;
using EntityResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioService.Order
{
    public interface IDOrder
    {
        Task<bool> Create(OrderRequest order);
        Task<bool> Delete(int id);
        Task<List<OrderResponse>> GetAll();
        Task<OrderResponse> Update(OrderRequest order);
        Task<bool> DeleteByIdCustomer(int id);
    }
}
