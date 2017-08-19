using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bencode2Json
{
    class BencodedString : IBencodedObject
    {
        public byte[] Data { get; set; }

        public BencodedString(byte[] data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return ToJson();
        }
        public string ToJson()
        {
            var dataString = Encoding.UTF8.GetString(Data);
            var dataBytes = Encoding.UTF8.GetBytes(dataString);
            if (dataBytes.SequenceEqual(Data))
            {
                return $"\"{Encoding.UTF8.GetString(Data)}\"";
            }
            else
            {
                return $"\"{Convert.ToBase64String(Data)}\"";
            }
        }
    }
}
