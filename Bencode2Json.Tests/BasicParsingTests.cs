//MIT License

//Copyright(c) 2017 Vijayshinva Karnure

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace Bencode2Json.Tests
{
    [TestClass]
    public class BasicParsingTests
    {
        [TestMethod]
        public void Parse_String()
        {
            var testDataStream = new MemoryStream(Encoding.UTF8.GetBytes("5:Vijay"));

            var bencodedData = new BencodedData(testDataStream);

            var result = bencodedData.ConvertToJson();

            Assert.AreEqual("\"Vijay\"", result);
        }

        [TestMethod]
        public void Parse_Integer()
        {
            var testDataStream = new MemoryStream(Encoding.UTF8.GetBytes("i560075e"));

            var bencodedData = new BencodedData(testDataStream);

            var result = bencodedData.ConvertToJson();

            Assert.AreEqual("560075", result);
        }

        [TestMethod]
        public void Parse_List()
        {
            var testDataStream = new MemoryStream(Encoding.UTF8.GetBytes("l5:hello5:worlde"));

            var bencodedData = new BencodedData(testDataStream);

            var result = bencodedData.ConvertToJson();

            Assert.AreEqual("[\"hello\",\"world\"]", result);
        }

        [TestMethod]
        public void Parse_Empty_List()
        {
            var testDataStream = new MemoryStream(Encoding.UTF8.GetBytes("le"));

            var bencodedData = new BencodedData(testDataStream);

            var result = bencodedData.ConvertToJson();

            Assert.AreEqual("[]", result);
        }

        [TestMethod]
        public void Parse_Dictionary()
        {
            var testDataStream = new MemoryStream(Encoding.UTF8.GetBytes("d5:debug4:truee"));

            var bencodedData = new BencodedData(testDataStream);

            var result = bencodedData.ConvertToJson();

            Assert.AreEqual("{\"debug\":\"true\"}", result);
        }
    }
}
