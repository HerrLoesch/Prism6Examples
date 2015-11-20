namespace PersonManagementTool.SystemTests
{
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class StartupTests
    {
        private UIMap map;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        [TestMethod]
        public void ApplicationMustRunForAtleast_2_Seconds()
        {
            this.UIMap.StartApplication();

            Playback.Wait(2000);

            this.UIMap.AssertApplicationExists();
            this.UIMap.CloseApplication();
        }
    }
}