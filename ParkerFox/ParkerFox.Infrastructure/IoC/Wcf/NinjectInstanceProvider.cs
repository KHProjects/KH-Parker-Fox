using Ninject;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace ParkerFox.Infrastructure.IoC.Wcf
{
    public class NinjectInstanceProvider : IInstanceProvider
    {
        private Type _serviceType;
        private IKernel _kernel;

        public NinjectInstanceProvider(Type serviceType, IKernel kernel)
        {
            _serviceType = serviceType;
            _kernel = kernel;
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return this.GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return _kernel.Get(_serviceType);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}
