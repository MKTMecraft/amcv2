//-----------------------------------------------------------------------
// <copyright file="DataModule.cs" company="Rushkar">
//     Copyright Rushkar Solutions. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TodoDashboard.Data
{
    using Autofac;
    using TodoDashboard.Data.Contract;

    /// <summary>
    /// Contract Class for DataModule.
    /// </summary>
    public class DataModule : Module
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
            //builder.RegisterType<V1.Tdd_AdminDao>().As<AbstractTdd_AdminDao>().InstancePerDependency();
            //builder.RegisterType<V1.Tdd_ClientDao>().As<AbstractTdd_ClientDao>().InstancePerDependency();

            base.Load(builder);
        }
    }
}
