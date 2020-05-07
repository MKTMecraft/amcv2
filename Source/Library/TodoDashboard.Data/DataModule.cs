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
            builder.RegisterType<V1.MasterBarTypesDao>().As<AbstractMasterBarTypesDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterDistributorsDao>().As<AbstractMasterDistributorsDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterLocationsDao>().As<AbstractMasterLocationsDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterServicesTypesDao>().As<AbstractMasterServicesTypesDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterStatesDao>().As<AbstractMasterStatesDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterTiersDao>().As<AbstractMasterTiersDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterUserDao>().As<AbstractMasterUserDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterWinesDao>().As<AbstractMasterWinesDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterWineVaritalsDao>().As<AbstractMasterWineVaritalsDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterUserDao>().As<AbstractMasterUserDao>().InstancePerDependency();
            base.Load(builder);
        }
    }
}
