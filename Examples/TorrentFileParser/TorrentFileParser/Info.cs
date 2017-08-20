using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TorrentFileParser
{
    class Info
    {
        [JsonProperty(PropertyName = "length")]
        public int Length { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "piece length")]
        public int PieceLength { get; set; }
        [JsonProperty(PropertyName = "pieces")]
        public byte[] Pieces { get; set; }
    }
}
