using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace CSharp.Tools.Ninject
{
    public class NinjectDependecy : IDependencyResolver
    {
        public NinjectDependecy(IKernel kernel) { _kernel = kernel; }


        private readonly IKernel _kernel;
        
        public IDependencyScope BeginScope() { return this; }

        public object GetService(Type serviceType) { return _kernel.TryGet(serviceType); }

        public IEnumerable<object> GetServices(Type serviceType) { return _kernel.GetAll(serviceType); }

        public void Dispose() { }
    }
}