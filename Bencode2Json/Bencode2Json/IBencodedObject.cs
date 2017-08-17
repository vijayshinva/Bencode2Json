using System;
using System.Collections.Generic;
using System.Text;

namespace Bencode2Json
{
    interface IBencodedObject
    {
        string ToJson();
    }
}
