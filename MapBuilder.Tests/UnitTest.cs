using System.Collections.Generic;
using System.Linq;
using MapBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapBuilder.Tests
{
    [TestClass]
    public class MapBuilderTests
    {
        private MapBuilder _mapBuilder;

        [TestInitialize]
        public void TestInit()
        {
            _mapBuilder = new MapBuilder();
        }

        [TestMethod]
        public void BuildRouteMap_Case1()
        {
            var expectedMap = new[] { "E2", "S", "E2", "E1" };
            var signatureMap = new HashSet<SignStep>
            {
                new() { Floor = 5, Section = 1 },
                new() { Floor = 4, Section = 2 },
                new() { Floor = 1, Section = 2 },
                new() { Floor = 4, Section = 1 }
            };

            var actualMap = _mapBuilder.BuildRouteMap(signatureMap).ToList();

            Assert.AreEqual(expectedMap[0], actualMap[0]);
            Assert.AreEqual(expectedMap[1], actualMap[1]);
            Assert.AreEqual(expectedMap[2], actualMap[2]);
            Assert.AreEqual(expectedMap[3], actualMap[3]);
        }

        [TestMethod]
        public void BuildRouteMap_Case2()
        {
            var expectedMap = new[] { "E1", "S", "S", "E2" };
            var signatureMap = new HashSet<SignStep>
            {
                new() { Floor = 4, Section = 1 },
                new() { Floor = 3, Section = 1 },
                new() { Floor = 5, Section = 2 },
                new() { Floor = 1, Section = 1 }
            };

            var actualMap = _mapBuilder.BuildRouteMap(signatureMap).ToList();

            Assert.AreEqual(expectedMap[0], actualMap[0]);
            Assert.AreEqual(expectedMap[1], actualMap[1]);
            Assert.AreEqual(expectedMap[2], actualMap[2]);
            Assert.AreEqual(expectedMap[3], actualMap[3]);
        }


        [TestMethod]
        public void BuildRouteMap_Case3()
        {
            var expectedMap = new[] { "E2", "S", "S", "S" };
            var signatureMap = new HashSet<SignStep>
            {
                new() { Floor = 5, Section = 1 },
                new() { Floor = 4, Section = 2 },
                new() { Floor = 3, Section = 2 },
                new() { Floor = 1, Section = 1 }
            };

            var actualMap = _mapBuilder.BuildRouteMap(signatureMap).ToList();

            Assert.AreEqual(expectedMap[0], actualMap[0]);
            Assert.AreEqual(expectedMap[1], actualMap[1]);
            Assert.AreEqual(expectedMap[2], actualMap[2]);
            Assert.AreEqual(expectedMap[3], actualMap[3]);
        }

        [TestMethod]
        public void BuildRouteMap_Case4()
        {
            var expectedMap = new[] { "S", "S", "E1", "E2" };
            var signatureMap = new HashSet<SignStep>
            {
                new() { Floor = 2, Section = 2 },
                new() { Floor = 4, Section = 1 },
                new() { Floor = 2, Section = 1 },
                new() { Floor = 5, Section = 2 }
            };

            var actualMap = _mapBuilder.BuildRouteMap(signatureMap).ToList();

            Assert.AreEqual(expectedMap[0], actualMap[0]);
            Assert.AreEqual(expectedMap[1], actualMap[1]);
            Assert.AreEqual(expectedMap[2], actualMap[2]);
            Assert.AreEqual(expectedMap[3], actualMap[3]);
        }
    }
}