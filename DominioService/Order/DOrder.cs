using EntityRequest;
using EntityResponse;
using RepositoryImplementation;
using static DomainService.Resource;

namespace DominioService.Order
{
    public class DOrder : IDOrder
    {
        readonly IResource Resource;
        readonly IRepository Repository;
        static string Sp = string.Empty;
        public DOrder(IResource resource, IRepository repository)
        {
            Repository = repository;
            Resource = resource;
            Sp = resource.GetValue("SP_Crud_Order");
        }
        public async Task<bool> Create(OrderRequest order)
        {
            object spParams = new
            {
                @Accion = 1,
                @Id = order.Id,
                @IdCustomer = order.IdCustomer,
                @Descripcion = order.Descripcion
            };

            return await Repository.SqlQuerySpBoolAsync(Sp, spParams);
        }

        public async Task<bool> Delete(int id)
        {
            object spParams = new { @Accion = 3, @Id = id };

            return await Repository.SqlQuerySpBoolAsync(Sp, spParams);
        }
        public async Task<bool> DeleteByIdCustomer(int id)
        {
            object spParams = new { @Accion = 5, @Id = 0, @IdCustomer = id };

            return await Repository.SqlQuerySpBoolAsync(Sp, spParams);
        }

        public async Task<List<OrderResponse>> GetAll()
        {
            object spParams = new { @Accion = 4 };

            return await Repository.SqlQuerySpListAsync<OrderResponse>(Sp, spParams);
        }

        public async Task<OrderResponse> Update(OrderRequest order)
        {
            object spParams = new
            {
                @Accion = 2,
                @Id = order.Id,
                @IdCustomer = order.IdCustomer,
                @Descripcion = order.Descripcion
            };

            return await Repository.SqlQuerySpFirstAsync<OrderResponse>(Sp, spParams);
        }
    }
}
