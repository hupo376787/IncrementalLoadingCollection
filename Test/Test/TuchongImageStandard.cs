using System;
using System.Collections.Generic;

namespace Test
{
    public class TuchongImageStandard
    {
        public string is_history { get; set; }

        public int counts { get; set; }

        public List<FeedList> feedList { get; set; }

        public string message { get; set; }

        public string more { get; set; }

        public string result { get; set; }

        public class FeedList
        {

            public int post_id { get; set; }

            public string type { get; set; }

            public string url { get; set; }

            public string site_id { get; set; }

            public string author_id { get; set; }

            public string published_at { get; set; }

            public string passed_time { get; set; }

            public string excerpt { get; set; }

            public int favorites { get; set; }

            public int comments { get; set; }

            public string rewardable { get; set; }

            public string parent_comments { get; set; }

            public string rewards { get; set; }

            public int views { get; set; }

            public string collected { get; set; }

            public string delete { get; set; }

            public string update { get; set; }

            public string content { get; set; }

            public string title { get; set; }

            public int image_count { get; set; }

            public List<Images> images { get; set; }

            //public string title_image { get; set; }

            public List<string> tags { get; set; }

            public List<string> event_tags { get; set; }

            public List<string> favorite_list_prefix { get; set; }

            public List<string> reward_list_prefix { get; set; }

            public List<string> comment_list_prefix { get; set; }

            public string data_type { get; set; }

            public string created_at { get; set; }

            public List<string> sites { get; set; }

            public Site site { get; set; }

            public string recom_type { get; set; }

            public string rqt_id { get; set; }

            public string is_favorite { get; set; }
        }

        public class Images
        {

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
