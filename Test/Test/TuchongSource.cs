using Microsoft.Toolkit.Uwp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Toolkit.Collections;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace Test
{
    public class TuchongSource : IIncrementalSource<TuchongImageMine>
    {
        private ObservableCollection<TuchongImageMine> _mine;
        public TuchongSource()
        {
            (Application.Current as App).bRefresh = true;
            _mine = new ObservableCollection<TuchongImageMine>();
            GetFirstData();
        }


        public async Task<IEnumerable<TuchongImageMine>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
        {
            IEnumerable<TuchongImageMine> result = null;

            (Application.Current as App).currentPage++;
            ObservableCollection<TuchongImageMine> MineItems = new ObservableCollection<TuchongImageMine>();

            string url = "";
            if ((Application.Current as App).bRefresh)
                url = "https://api.tuchong.com/feed-app";
            else
                url = "https://api.tuchong.com/feed-app?post_id=" + (Application.Current as App).lastPostId + "&page=" + (Application.Current as App).currentPage.ToString() + "&type=loadmore";

            MineItems = await TuchongHelper.GetTuchongImage(url);
            foreach (var item in MineItems)
            {
                if ((Application.Current as App).toShowItems.Contains(item))
                    continue;
                (Application.Current as App).toShowItems.Add(item);
                _mine.Add(item);
                await Task.Delay(50);
            }
            (Application.Current as App).lastPostId = MineItems[MineItems.Count - 1].post_id;
            (Application.Current as App).bRefresh = false;

            result = (Application.Current as App).toShowItems.AsEnumerable<TuchongImageMine>();
            return result;
        }

        private async Task GetFirstData()
        {
            string url = "https://api.tuchong.com/feed-app";
            _mine = await TuchongHelper.GetTuchongImage(url);
            (Application.Current as App).lastPostId = _mine[_mine.Count - 1].post_id;
        }
    }
}
