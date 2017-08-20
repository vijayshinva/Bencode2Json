using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TorrentFileParser
{
    class TorrentFileInfo
    {
        [JsonProperty(PropertyName = "announce")]
        public string Announce { get; set; }
        [JsonProperty(PropertyName = "announce-list")]
        public List<List<string>> AnnounceList { get; set; }
        [JsonProperty(PropertyName = "comment")]
        public string Comment { get; set; }
        [JsonProperty(PropertyName = "creation date")]
        public string CreationDate { get; set; }
        [JsonProperty(PropertyName = "info")]
        public Info Info { get; set; }
    }
}
