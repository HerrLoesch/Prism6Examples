namespace PersonManagementTool
{
    using System.Windows;

    using Microsoft.Practices.Unity;

    using Prism.Unity;

    using PersonManagementTool.Contracts;
    using PersonManagementTool.Data;
    using PersonManagementTool.Infrastructure;
    using PersonManagementTool.Views;

    using Prism.Regions;

    public class Bootstrapper : UnityBootstrapper
    {
        /// <summary>
        /// Creates the shell or main window of the application.
        /// </summary>
        /// <returns>
        /// The shell of the application.
        /// </returns>
        /// <remarks>
        /// If the returned instance is a <see cref="T:System.Windows.DependencyObject"/>, the
        ///             <see cref="T:Prism.Bootstrapper"/> will attach the default <see cref="T:Prism.Regions.IRegionManager"/> of
        ///             the application in its <see cref="F:Prism.Regions.RegionManager.RegionManagerProperty"/> attached property
        ///             in order to be able to add regions by using the <see cref="F:Prism.Regions.RegionManager.RegionNameProperty"/>
        ///             attached property from XAML.
        /// </remarks>
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<Views.MainView>();
        }

        /// <summary>
        /// Configures the <see cref="T:Microsoft.Practices.Unity.IUnityContainer"/>. May be overwritten in a derived class to add specific
        ///             type mappings required by the application.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            this.Container.RegisterType<IPersonRepository, Repository>();
            this.Container.RegisterType<IApplicationCommands, ApplicationCommands>(new ContainerControlledLifetimeManager());
        }

        /// <summary>
        /// Initializes the shell.
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();

            var window = (MainView)this.Shell;
            Application.Current.MainWindow = window;

            var regionManager = this.Container.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.SelectionRegionName, typeof(PersonSelectionView));
            regionManager.RegisterViewWithRegion(RegionNames.ContentRegionName, typeof(PersonDetailsView));

            window.Show();
        }
    }
}
