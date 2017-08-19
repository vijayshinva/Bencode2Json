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
