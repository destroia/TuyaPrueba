using Api.Controllers;
using DataBase;
using DomainService;
using DominioService.Customer;
using DominioService.Order;
using EntityRequest;
using EntityResponse;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using RepositoryImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomainService.Resource;

namespace TestingIntegration
{
    public class OrderTest
    {

        readonly CustomersController CustomersController;
        readonly IDCustomer SCustomer;
        readonly OrdersController OrdersController;
        readonly IDOrder SOrder;
        readonly IRepository Repository;
        readonly IResource Resource;
        private readonly IStringLocalizer<Resource> stringLocalizer;
        public OrderTest()
        {
            var service = HelperContext.CreateContext();
            var options = Options.Create(new LocalizationOptions { ResourcesPath = "Resources" });
            var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);
            var localizer = new StringLocalizer<Resource>(factory);
            Resource = new Resource(localizer);
            Repository = new Repository(service.GetService<AppDbContext>());
            SOrder = new DOrder(Resource, Repository);
            OrdersController = new OrdersController(SOrder);
            SCustomer = new DCustomer(Resource, Repository);
            CustomersController = new CustomersController(SCustomer);
        }
        [Fact]
        public async Task GET()
        {

            var res = await OrdersController.Get();
            Assert.True(res.Value.Count != 0);
        }
        [Fact]
        public async Task Create()
        {
            var res = await CustomersController.Get();
            var objc = res.Value[0] as CustomerResponse;
            var Ordertest1 = new OrderRequest()
            {
                IdCustomer = objc.Id,
                Descripcion = Guid.NewGuid().ToString(),
            };

            var result = await OrdersController.Create(Ordertest1) as ActionResult<bool>;
            var resultOk = result.Result as OkObjectResult;
            Assert.True((bool)resultOk.Value);


        }
        [Fact]
        public async Task Update()
        {
            await Create();
            var res = await OrdersController.Get();
            var objc = res.Value[0] as OrderResponse;
            var Ordertest2 = new OrderRequest()
            {
                Id = objc.Id,
                IdCustomer = objc.IdCustomer,
                Descripcion = Guid.NewGuid().ToString(),
            };

            var resul = await OrdersController.Update(Ordertest2) as ActionResult<OrderResponse>;
            var resultOk = resul.Result as OkObjectResult;
            Assert.NotNull(resultOk.Value);

        }
        [Fact]
        public async Task Delete()
        {
            var res = await OrdersController.Get();
            var objc = res.Value[0] as OrderResponse;


            var resul = await OrdersController.Delete(objc.Id) as ActionResult<bool>;
            var resultOk = resul.Result as OkObjectResult;
            Assert.True((bool)resultOk.Value);

        }
    }
}
