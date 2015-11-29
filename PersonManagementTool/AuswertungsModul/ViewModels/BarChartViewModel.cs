namespace AuswertungsModul.ViewModels
{
    using System.Collections.ObjectModel;

    public class BarChartViewModel
    {
        public ObservableCollection<DataPoint> Data { get; set; }

        public BarChartViewModel()
        {
            Data = new ObservableCollection<DataPoint>();

            Data.Add(new DataPoint(1,2));
            Data.Add(new DataPoint(2,4));
            Data.Add(new DataPoint(3,8));
            Data.Add(new DataPoint(4,16));
        }

    }
}
