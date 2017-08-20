using Bencode2Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TorrentFileParser
{
    class TorrentFile
    {
        public static TorrentFileInfo Parse(string fileName)
        {
            var bencode = new BencodedData(new FileStream(fileName, FileMode.Open));
            var json = bencode.ConvertToJson();
            TorrentFileInfo m = JsonConvert.DeserializeObject<TorrentFileInfo>(json);
            return m;
        }
    }
}
