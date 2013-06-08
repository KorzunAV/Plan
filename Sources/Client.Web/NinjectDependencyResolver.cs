using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Client.Web.IoC;
using Data.IoC;
using Ninject;

namespace Client.Web
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel(
                new DataModule(),
                new ControllersModule());
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}