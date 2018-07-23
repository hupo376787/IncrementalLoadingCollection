using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Test
{
    public class TuchongImageMine
    {
        public int post_id { get; set; }

        public string url { get; set; }

        public string author_id { get; set; }

        public string published_at { get; set; }

        public string passed_time { get; set; }

        public int favorites { get; set; }

        public int comments { get; set; }

        public int views { get; set; }

        public string title { get; set; }

        public int image_count { get; set; }

        public List<Images> images { get; set; }

        public string coverimg_realurl { get; set; }

        public BitmapImage coverimg { get; set; }

        public List<string> tags { get; set; }

        public List<string> event_tags { get; set; }

        public string data_type { get; set; }

        public string created_at { get; set; }

        public List<string> sites { get; set; }

        public Site site { get; set; }

        public string recom_type { get; set; }

        public string rqt_id { get; set; }

        public string is_favorite { get; set; }

        public class Images
        {
            public string img_realurl { get; set; }

            public int img_id { get; set; }

            public int user_id { get; set; }

            public string title { get; set; }

            public string excerpt { get; set; }

            public int width { get; set; }

            public int height { get; set; }

            public string description { get; set; }
        }

        public class Site
        {

            public string site_id { get; set; }

            public string type { get; set; }

            public string name { get; set; }

            public string domain { get; set; }

            public string description { get; set; }

            public int followers { get; set; }

            public string url { get; set; }

            public string icon { get; set; }

            public string verified { get; set; }

            public int? verified_type { get; set; }

            public string verified_reason { get; set; }

            public int? verifications { get; set; }

            //public List<string> verification_list { get; set; }

            public string is_following { get; set; }
        }

    }
}
