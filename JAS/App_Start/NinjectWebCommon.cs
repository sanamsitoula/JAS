[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(JAS.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(JAS.App_Start.NinjectWebCommon), "Stop")]




namespace JAS.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using System.Web.Http;
    using WebApiContrib.IoC.Ninject;
    using Services;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(Ninject.Web.Common.WebHost.OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(Ninject.Web.Common.WebHost.NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }


        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                //web api ak
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }


        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //role
            kernel.Bind<IGroupServices>().To<GroupServices>();
            kernel.Bind<GroupServices>().To<GroupServices>();

            kernel.Bind<IItemServices>().To<ItemServices>();
            kernel.Bind<ItemServices>().To<ItemServices>();

            kernel.Bind<IPurchaseServices>().To<PurchaseServices>();
            kernel.Bind<PurchaseServices>().To<PurchaseServices>();

            kernel.Bind<IGeneralLedgerServices>().To<GeneralLedgerServices>();
            kernel.Bind<GeneralLedgerServices>().To<GeneralLedgerServices>();

            kernel.Bind<ISalesServices>().To<SalesServices>();
            kernel.Bind<SalesServices>().To<SalesServices>();

            kernel.Bind<IReportServices>().To<ReportServices>();
            kernel.Bind<ReportServices>().To<ReportServices>();


            kernel.Bind<IUserServices>().To<UserServices>();
            kernel.Bind<UserServices>().To<UserServices>();
            
            kernel.Bind<IJournalEntryServices>().To<JournalEntryServices>();
            kernel.Bind<JournalEntryServices>().To<JournalEntryServices>();


        }


    }
    }