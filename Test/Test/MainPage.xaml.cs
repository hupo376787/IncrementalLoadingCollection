using Microsoft.Toolkit.Uwp;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Test
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {

        //IncrementalLoadingCollection<PeopleSource, TuchongImageMine> collection;

        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(188, 188));

            var ss = new IncrementalLoadingCollection<TuchongSource, TuchongImageMine>();
            //DataContext = ss;
            gridView.ItemsSource = ss;


            //GetRecommend();
            //gridView.ItemsSource = (Application.Current as App).toShowItems;
        }

        #region Manual load more data
        private async Task GetRecommend()
        {
            var MineItems = await TuchongHelper.GetTuchongImage("https://api.tuchong.com/feed-app");

            await AddtoGridView(MineItems);
        }

        private async void RefreshClick(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).toShowItems.Clear();
            (Application.Current as App).bRefresh = true;
            await GetRecommend();
        }

        private async void LoadMoreClick(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).currentPage ++;
            string url = "https://api.tuchong.com/feed-app?post_id=" + (Application.Current as App).lastPostId +"&page=" + (Application.Current as App).currentPage.ToString() + "&type=loadmore";
            var MineItems = await TuchongHelper.GetTuchongImage(url);

            await AddtoGridView(MineItems);
        }

        private async Task AddtoGridView(ObservableCollection<TuchongImageMine> MineItems)
        {
            foreach (var item in MineItems)
            {
                if ((Application.Current as App).toShowItems.Contains(item))
                    continue;
                (Application.Current as App).toShowItems.Add(item);
                gridView.ItemsSource = (Application.Current as App).toShowItems;
                await Task.Delay(50);
            }
            (Application.Current as App).lastPostId = MineItems[MineItems.Count - 1].post_id;
        }

    }
#endregion
}
