using SerwisProduktow.Domain.Concrete;
using SerwisProduktow.Domain.Repositories;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace SerwisProduktow.Infrastructure
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
        }
    }
}