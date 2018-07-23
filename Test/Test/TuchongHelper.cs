using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TuchongHelper
    {
        public async static Task<ObservableCollection<TuchongImageMine>> GetTuchongImage(string url)
        {
            var res = await HttpHelper.GetJsonAsync<TuchongImageStandard>(url);

            ObservableCollection<TuchongImageMine> MineItems = new ObservableCollection<TuchongImageMine>();
            foreach (var item in res.feedList)
            {
                TuchongImageMine mine = new TuchongImageMine();
                try
                {
                    mine.post_id = item.post_id;
                    mine.url = item.url;
                    mine.author_id = item.author_id;
                    mine.published_at = item.published_at;
                    mine.passed_time = item.passed_time;
                    mine.favorites = item.favorites;
                    mine.comments = item.comments;
                    mine.views = item.views;
                    mine.title = item.title;
                    mine.image_count = item.image_count;

                    if (item.image_count <= 0)
                        continue;
                    List<TuchongImageMine.Images> mineImages = new List<TuchongImageMine.Images>();
                    foreach (var item0 in item.images)
                    {
                        TuchongImageMine.Images ii = new TuchongImageMine.Images();
                        ii.img_realurl = "https://photo.tuchong.com/" + item0.user_id.ToString() + "/f/" + item0.img_id + ".jpg";
                        ii.img_id = item0.img_id;
                        ii.user_id = item0.user_id;
                        ii.title = item0.title;
                        ii.excerpt = item0.excerpt;
                        ii.width = item0.width;
                        ii.height = item0.height;
                        ii.description = item0.description;

                        mineImages.Add(ii);
                    }
                    mine.coverimg_realurl = mineImages[0].img_realurl;
                    mine.coverimg = await HttpHelper.GetWebImageAsync(mineImages[0].img_realurl);

                    mine.post_id = item.post_id;
                    mine.tags = item.tags;
                    mine.event_tags = item.event_tags;
                    mine.url = item.url;
                    mine.data_type = item.data_type;
                    mine.created_at = item.created_at;
                    mine.sites = item.sites;
                    TuchongImageMine.Site ss = new TuchongImageMine.Site
                    {
                        site_id = item.site.site_id,
                        type = item.site.type,
                        name = item.site.name,
                        domain = item.site.domain,
                        description = item.site.description,
                        followers = item.site.followers,
                        url = item.site.url,
                        icon = item.site.icon,
                        verified = item.site.verified,
                        verified_type = item.site.verified_type,
                        verified_reason = item.site.verified_reason,
                        verifications = item.site.verifications,
                        is_following = item.site.is_following,
                    };
                    mine.site = ss;
                    mine.recom_type = item.recom_type;
                    mine.rqt_id = item.rqt_id;
                    mine.is_favorite = item.is_favorite;

                    MineItems.Add(mine);
                }
                catch(Exception ex)
                {

                }
            }

            return MineItems;
        }

    }
}
