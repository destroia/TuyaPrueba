using Api;
using Api.Controllers;
using DataBase;
using DomainService;
using DominioService.Customer;
using DominioService.Order;
using EntityRequest;
using EntityResponse;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using RepositoryImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static DomainService.Resource;

namespace TestingIntegration
{

    public class CustomerTest
    {
        readonly CustomersController CustomersController;
        readonly IDCustomer SCustomer;
        readonly OrdersController OrdersController;
        readonly IDOrder SOrder;
        readonly IRepository Repository;
        readonly IResource Resource;
        private readonly IStringLocalizer<Resource> stringLocalizer;
        public CustomerTest()
        {
            var service = HelperContext.CreateContext();
            var options = Options.Create(new LocalizationOptions { ResourcesPath = "Resources" });
            var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);
            var localizer = new StringLocalizer<Resource>(factory);
            service.GetService<AppDbContext>();
            Resource = new Resource(localizer);
            Repository = new Repository(service.GetService<AppDbContext>());
            SCustomer = new DCustomer(Resource, Repository);
            CustomersController = new CustomersController(SCustomer);
            SOrder = new DOrder(Resource, Repository);
            OrdersController = new OrdersController(SOrder);
        }
       
         

        [Fact]
        public async Task GET()
        {
            
            var res = await CustomersController.Get();
            Assert.True(res.Value.Count != 0);
        }
        [Fact]
        public async Task Create()
        {

            var customertest1 = new CustomerRequest() {
                Nombre = Guid.NewGuid().ToString(),
                Direccion = Guid.NewGuid().ToString(),  
                Documento = Guid.NewGuid().ToString(),  
                Telefno = Guid.NewGuid().ToString()    
            };

            var res =  await CustomersController.Create(customertest1) as ActionResult<bool>;
            var resultOk = res.Result as OkObjectResult;
            Assert.True((bool)resultOk.Value);


        }
        [Fact]
        public async Task Update()
        {
            await Create();
            var res = await CustomersController.Get();
            var objc = res.Value[0] as CustomerResponse;
            var customertest2 = new CustomerRequest()
            {
                Id = objc.Id,
                Nombre = Guid.NewGuid().ToString(),
                Direccion = Guid.NewGuid().ToString(),
                Documento = Guid.NewGuid().ToString(),
                Telefno = Guid.NewGuid().ToString()
            };

            var resul = await CustomersController.Update(customertest2) as ActionResult<CustomerResponse>;
            var resultOk = resul.Result as OkObjectResult;
            Assert.NotNull(resultOk.Value);

        }
        [Fact]
        public async Task Delete()
        {
            var res = await CustomersController.Get();
            var objc = res.Value[0] as CustomerResponse;
            var ressd = await OrdersController.DeleteByIdCustomer(objc.Id);



            var resul = await CustomersController.Delete(objc.Id) as ActionResult<bool>;
            var resultOk = resul.Result as OkObjectResult;
            Assert.True((bool)resultOk.Value);

        }

    }
}
