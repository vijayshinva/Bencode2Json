using System;
using System.Collections.Generic;
using System.Text;

namespace Bencode2Json
{
    class BencodedInteger : IBencodedObject
    {
        public long Data { get; set; }

        public BencodedInteger(string data)
        {
            Data = long.Parse(data);
        }

        public override string ToString()
        {
            return ToJson();
        }

        public string ToJson()
        {
            return Data.ToString();
        }
    }
}
