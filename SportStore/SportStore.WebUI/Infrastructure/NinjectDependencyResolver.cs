using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Moq;
using Ninject;
using SportStore.Domain.Entities;
using SportStore.Domain.Abstract;

namespace SportStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
                mock.Setup(m => m.Products).Returns(new List<Product>
        {
            new Product { Name = "SimCity", Price = 1499 },
            new Product { Name = "TITANFALL", Price=2299 },
            new Product { Name = "Battlefield 4", Price=899.4M }
        });
                kernel.Bind<IProductRepository>().ToConstant(mock.Object);
            }

        }
    }
