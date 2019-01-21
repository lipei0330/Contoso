﻿using Contoso.Services;
using Contoso.Data;
using Contoso.Data.Repositories;
using Ninject.Web.Common.WebHost;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Contoso.API.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Contoso.API.App_Start.NinjectWebCommon), "Stop")]

namespace Contoso.API.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
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
            kernel.Bind<IStudentRepository>().To<StudentRepository>();
            kernel.Bind<IPeopleRepository>().To<PeopleRepository>();
            kernel.Bind<IDepartmentRepository>().To<DepartmentRepository>();
            kernel.Bind<ICourseRepository>().To<CourseRepository>();
            kernel.Bind<IInstructorRepository>().To<InstructorRepository>();
            kernel.Bind<IOfficeAssignmentRepository>().To<OfficeAssignmentRepository>();
            kernel.Bind<IEnrollmentRepository>().To<EnrollmentRepository>();

            //Services
            kernel.Bind<ICourseService>().To<CourseService2>();
            kernel.Bind<IStudentService>().To<StudentService>();
            kernel.Bind<IPeopleService>().To<PeopleVersion2Service>();
            kernel.Bind<IDepartmentService>().To<DepratmentVersion2Service>();
            kernel.Bind<IInstructorService>().To<InstructorService>();
            kernel.Bind<IOfficeAssignmentService>().To<OfficeAssignmentService>();
            kernel.Bind<IEnrollmentService>().To<EnrollmentService>();


        }
    }
}