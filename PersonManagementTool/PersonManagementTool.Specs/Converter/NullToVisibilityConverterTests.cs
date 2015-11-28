namespace PersonManagementTool.Specs.Converter
{
    using System.Globalization;
    using System.Windows;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PersonManagementTool.Converter;

    [TestClass]
    public class NullToVisibilityConverterTests
    {
        private NullToVisibilityConverter sut;

        [TestInitialize]
        public void Initialize()
        {
            this.sut = new NullToVisibilityConverter();
        }

        [TestMethod]
        public void NullResultsInCollapsed()
        {
            var result = this.sut.Convert(null, typeof(Visibility), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void NotNullResultsInVisible()
        {
            var result = this.sut.Convert(new object(), typeof(Visibility), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void InvertedNullResultsInVisible()
        {
            this.sut.IsInverted = true;
            var result = this.sut.Convert(null, typeof(Visibility), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void InvertedNotNullResultsInCollapsed()
        {
            this.sut.IsInverted = true;

            var result = this.sut.Convert(new object(), typeof(Visibility), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Collapsed, result);
        }
    }
}
