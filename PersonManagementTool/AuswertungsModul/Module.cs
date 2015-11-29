namespace AuswertungsModul
{
    using AuswertungsModul.Views;

    using Microsoft.Practices.Unity;

    using Prism.Modularity;
    using Prism.Regions;

    public class Module : IModule
    {
        private IRegionManager regionManager;

        private IUnityContainer container;

        public Module(IRegionManager regionManager, IUnityContainer unityContainer)
        {
            this.container = unityContainer;
            this.regionManager = regionManager;
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        public void Initialize()
        {
            this.container.RegisterType<object, BarChartView>("barChart");

            this.regionManager.RegisterViewWithRegion("ContentRegion", typeof(BarChartView));
        }
    }
}
