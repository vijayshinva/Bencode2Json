using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bencode2Json
{
    public class BencodedData
    {
        private BinaryReader reader;
        private Stream stream;

        public BencodedData(Stream stream)
        {
            this.stream = stream;
            reader = new BinaryReader(stream, Encoding.UTF8);
        }

        public string ConvertToJson()
        {
            var o = ParseBencodedObject();
            reader.BaseStream.Position = 0;
            return o.ToJson();
        }

        IBencodedObject ParseBencodedObject()
        {
            switch (reader.PeekChar())
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return ParseBencodedString();
                case 'i':
                    return ParseBencodedInteger();
                case 'l':
                    return ParseBencodedList();
                case 'd':
                    return ParseBencodedDictionary();
                default:
                    return null;
            }
        }

        int ParseBencodedStringLength()
        {
            StringBuilder lengthBuilder = new StringBuilder();
            do
            {
                lengthBuilder.Append(reader.ReadChar());
            } while (reader.PeekChar() > 0 && reader.PeekChar() != ':');
            reader.ReadChar();
            return int.Parse(lengthBuilder.ToString());
        }

        BencodedString ParseBencodedString()
        {
            var length = ParseBencodedStringLength();
            byte[] buffer = new byte[length];
            for (int i = 0; i < length; i++)
            {
                buffer[i] = reader.ReadByte();
            }
            return new BencodedString(buffer);
            //return new BencodedString(reader.ReadChars(length)); TODO : ReadChars doesnt work for some reason.
        }

        BencodedDictionary ParseBencodedDictionary()
        {
            if (reader.ReadChar() != 'd')
            {
                throw new Exception();
            }
            Dictionary<BencodedString, IBencodedObject> dictBuilder = new Dictionary<BencodedString, IBencodedObject>();
            do
            {
                var key = ParseBencodedString();
                var value = ParseBencodedObject();
                dictBuilder.Add(key, value);
            } while (reader.PeekChar() > 0 && reader.PeekChar() != 'e');
            reader.ReadChar();
            return new BencodedDictionary(dictBuilder);
        }

        BencodedInteger ParseBencodedInteger()
        {
            if (reader.ReadChar() != 'i')
            {
                throw new Exception();
            }
            StringBuilder integerBuilder = new StringBuilder();
            do
            {
                integerBuilder.Append(reader.ReadChar());
            } while (reader.PeekChar() > 0 && reader.PeekChar() != 'e');
            reader.ReadChar();
            return new BencodedInteger(integerBuilder.ToString());
        }
        BencodedList ParseBencodedList()
        {
            if (reader.ReadChar() != 'l')
            {
                throw new Exception();
            }
            List<IBencodedObject> listBuilder = new List<IBencodedObject>();
            do
            {
                listBuilder.Add(ParseBencodedObject());
            } while (reader.PeekChar() > 0 && reader.PeekChar() != 'e');
            reader.ReadChar();
            return new BencodedList(listBuilder);
        }
    }
}
