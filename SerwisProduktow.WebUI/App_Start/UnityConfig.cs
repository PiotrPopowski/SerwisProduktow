using SerwisProduktow.Domain.Concrete;
using SerwisProduktow.Domain.Repositories;
using SerwisProduktow.Infrastructure.Repositories;
using SerwisProduktow.WebUI.Controllers;
using System;

using Unity;
using Unity.Injection;

namespace SerwisProduktow.WebUI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        
        public static void RegisterTypes(IUnityContainer container)
        {
            //container.RegisterType<UserController>(new InjectionConstructor());
            container.RegisterSingleton<IDBEntities, DBEntities>();
            container.RegisterType<IDBUserRepository, DBUserRepository>();
            container.RegisterType<IDBServiceRepository, DBServiceRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IServiceRepository, ServiceRepository>();
        }
    }
}