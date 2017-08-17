using System;
using System.Collections.Generic;
using System.Text;

namespace Bencode2Json
{
    class BencodedList : IBencodedObject
    {
        public List<IBencodedObject> Data { get; set; }

        public BencodedList(List<IBencodedObject> data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return ToJson();
        }

        public string ToJson()
        {
            return $"[{string.Join(",", Data)}]";
        }
    }
}
