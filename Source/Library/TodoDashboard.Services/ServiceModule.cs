//-----------------------------------------------------------------------
// <copyright file="ServiceModule.cs" company="Premiere Digital Services">
//     Copyright Premiere Digital Services. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TodoDashboard.Services
{
    using Autofac;    
    using Data;
    using TodoDashboard.Services.Contract;

    /// <summary>
    /// The Service module for dependency injection.
    /// </summary>
    public class ServiceModule : Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {           
            builder.RegisterModule<DataModule>();

            //builder.RegisterType<V1.Tdd_AdminServices>().As<AbstractTdd_AdminServices>().InstancePerDependency();
            //builder.RegisterType<V1.Tdd_ClientServices>().As<AbstractTdd_ClientServices>().InstancePerDependency();

            base.Load(builder);
        }
    }
}
