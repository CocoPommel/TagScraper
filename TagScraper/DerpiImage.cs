using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagScraper
{
    class DerpiImage
    {
        public string id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public List<object> duplicate_reports { get; set; }
        public string first_seen_at { get; set; }
        public string uploader_id { get; set; }
        public int score { get; set; }
        public int comment_count { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string file_name { get; set; }
        public string description { get; set; }
        public string uploader { get; set; }
        public string image { get; set; }
        public int upvotes { get; set; }
        public int downvotes { get; set; }
        public int faves { get; set; }
        public string tags { get; set; }
        public List<string> tag_ids { get; set; }
        public double aspect_ratio { get; set; }
        public string original_format { get; set; }
        public string mime_type { get; set; }
        public string sha512_hash { get; set; }
        public string orig_sha512_hash { get; set; }
        public string source_url { get; set; }
        public Representations representations { get; set; }
        public bool is_rendered { get; set; }
        public bool is_optimized { get; set; }
        public List<object> interactions { get; set; }
    }
}
