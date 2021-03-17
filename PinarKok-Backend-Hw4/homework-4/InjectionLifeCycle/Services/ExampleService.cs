using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InjectionLifeCycle.Services
{
    public class ExampleService : ISingletonService, IScopedService, ITransientService
    {
        Guid _id;

        public ExampleService()
        {
            _id = Guid.NewGuid();
        }

        public Guid GetId()
        {
            return _id;
        }
    }
}
