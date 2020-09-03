using System;
using System.Text;
using Grocery.ProductServices;
using LightInject;

namespace Grocery
{
    public class ServiceDependency
    {
        public ServiceDependency(IServiceContainer container)
        {
            _container = container;
        }
        /// <summary>
        /// Defines the Instance.
        /// </summary>
        private static ServiceDependency _instance;

        /// <summary>
        /// Defines the _container.
        /// </summary>
        private readonly IServiceContainer _container;

        /// <summary>
        /// Gets the Container.
        /// </summary>
        public IServiceContainer Container => _container;

        /// <summary>
        /// Defines the objLock.
        /// </summary>
        private static readonly object ObjLock = new object();

        public static ServiceDependency GetInstance(IServiceContainer container = null)
        {
            if (_instance == null)
            {
                lock (ObjLock)
                {
                    _instance ??= new ServiceDependency(container);
                }
            }

            return _instance;
        }

        /// <summary>
        /// The RegisterServices.
        /// </summary>
        public void RegisterServices()
        {
            _container.Register<ITerminal, TerminalCounter>();
            _container.Register<IProductPriceService, AProductPriceService>("A");
            _container.Register<IProductPriceService, BProductPriceService>("B");
            _container.Register<IProductPriceService, CProductPriceService>("C");
            _container.Register<IProductPriceService, DProductPriceService>("D");
        }
    }
}
