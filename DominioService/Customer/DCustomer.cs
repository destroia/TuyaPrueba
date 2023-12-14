
using EntityRequest;
using EntityResponse;
using RepositoryImplementation;
using static DomainService.Resource;

namespace DominioService.Customer
{
    public class DCustomer : IDCustomer
    {
        readonly IResource Resource;
        readonly IRepository Repository;
        static string Sp = string.Empty;
        public DCustomer(IResource resource, IRepository repository)
        {
            Repository = repository;
            Resource = resource;
            Sp = resource.GetValue("SP_Crud_Customer");
        }

        public async Task<bool> Create(CustomerRequest customer)
        {
            object spParams = new {
                @Accion = 1, 
                @Id = customer.Id, 
                @Nombre = customer.Nombre,
                @Documento = customer.Documento,
                @Telefno = customer.Telefno,
                @Direccion = customer.Direccion,
            };

            return await Repository.SqlQuerySpBoolAsync(Sp, spParams);
        }

        public async Task<bool> Delete(int id)
        {
            object spParams = new { @Accion = 3, @Id = id };

            return await Repository.SqlQuerySpBoolAsync(Sp, spParams);
        }

        public async Task<List<CustomerResponse>> GetAll()
        {
            object spParams = new { @Accion = 4 };

            return await Repository.SqlQuerySpListAsync<CustomerResponse>(Sp, spParams);
        }

        public async Task<CustomerResponse> Update(CustomerRequest customer)
        {
            object spParams = new
            {
                @Accion = 2,
                @Id = customer.Id,
                @Nombre = customer.Nombre,
                @Documento = customer.Documento,
                @Telefno = customer.Telefno,
                @Direccion = customer.Direccion,
            };

            return await Repository.SqlQuerySpFirstAsync<CustomerResponse>(Sp, spParams);
        }
    }
}
