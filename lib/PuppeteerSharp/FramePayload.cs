using Newtonsoft.Json;

namespace CefSharp.Dom
{
    internal class FramePayload
    {
        public string Id { get; set; }

        public string ParentId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string UrlFragment { get; set; }
    }
}
