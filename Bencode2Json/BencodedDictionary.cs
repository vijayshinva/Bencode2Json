using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bencode2Json
{
    class BencodedDictionary : IBencodedObject
    {
        public Dictionary<BencodedString, IBencodedObject> Data { get; set; }

        public BencodedDictionary(Dictionary<BencodedString, IBencodedObject> data)
        {
            Data = data;
        }
        public override string ToString()
        {
            return ToJson();
        }

        public string ToJson()
        {
            return $"{{{string.Join(",", Data.Select(d => $"{d.Key}:{d.Value}"))}}}";
        }
    }
}
