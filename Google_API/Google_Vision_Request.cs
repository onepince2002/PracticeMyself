using System;
using System.Collections.Generic;
using System.Text;

namespace Google_API
{
    public class Google_Vision_Request
    {
        public Request requests { get; set; }
    }

    public class Request
    {
        public Image image { get; set; }
        public Feature features { get; set; }
    }

    public class Image
    {
        public Source source { get; set; }
    }

    public class Source
    {
        public string imageUri { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public int maxResults { get; set; }
    }

}
