using EntityRequest;
using EntityResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioService.Customer
{
    public interface IDCustomer
    {
        Task<bool> Create(CustomerRequest customer);
        Task<bool> Delete(int id);
        Task<List<CustomerResponse>> GetAll();
        Task<CustomerResponse> Update(CustomerRequest customer);
    }
}
