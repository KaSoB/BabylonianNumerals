using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabylonianNumerals.UnitTests {
    [TestClass]
    public class ConverterUnitTest {
    
        [TestMethod]
        public void Can_Convert_Base10_To_Base60_Test_Zero() {
            //Arrange
            long testedValue = 0;
            Stack<long> expectedValues = new Stack<long>();
            expectedValues.Push(0);

            //Act
            Stack<long> actualValues = Converter.Convert10To60(testedValue);
            //Assert    
            CollectionAssert.AreEqual(expectedValues, actualValues);
        }
        [TestMethod]
        public void Can_Convert_Base10_To_Base60_Test_One() {
            //Arrange
            long testedValue = 1;
            Stack<long> expectedValues = new Stack<long>();
            expectedValues.Push(1);

            //Act
            Stack<long> actualValues = Converter.Convert10To60(testedValue);
            //Assert    
            CollectionAssert.AreEqual(expectedValues, actualValues);
        }
        [TestMethod]
        public void Can_Convert_Base10_To_Base60_Test1() {
            //Arrange
            long testedValue = 104060;
            Stack<long> expectedValues = new Stack<long>();
            expectedValues.Push(20);
            expectedValues.Push(54);
            expectedValues.Push(28);

            //Act
            Stack<long> actualValues = Converter.Convert10To60(testedValue);
            //Assert    
            CollectionAssert.AreEqual(expectedValues, actualValues);
        }
        [TestMethod]
        public void Can_Convert_Base10_To_Base60_Test2() {
            //Arrange
            long testedValue = 123456789;
            Stack<long> expectedValues = new Stack<long>();
            expectedValues.Push(9);
            expectedValues.Push(33);
            expectedValues.Push(33);
            expectedValues.Push(31);
            expectedValues.Push(9);

            //Act
            Stack<long> actualValues = Converter.Convert10To60(testedValue);
            //Assert    
            CollectionAssert.AreEqual(expectedValues, actualValues);
        }

        [TestMethod]
        public void Can_Convert_Base60_To_Base10_Test_Zero() {
            //Arrange
            Stack<long> testedValues = new Stack<long>();
            testedValues.Push(0);

            long expectedValue = 0;
            //Act
            double actualValues = Converter.Convert60To10(testedValues);
            //Assert    
            Assert.AreEqual(expectedValue, actualValues);
        }
        [TestMethod]
        public void Can_Convert_Base60_To_Base10_Test_One() {
            //Arrange
            Stack<long> testedValues = new Stack<long>();
            testedValues.Push(1);

            long expectedValue = 1;
            //Act
            double actualValues = Converter.Convert60To10(testedValues);
            //Assert    
            Assert.AreEqual(expectedValue, actualValues);
        }
        [TestMethod]
        public void Can_Convert_Base60_To_Base10_Test1() {
            //Arrange
            Stack<long> testedValues = new Stack<long>();
            testedValues.Push(28);
            testedValues.Push(54);
            testedValues.Push(20);
         
            long expectedValue = 104060;
            //Act
            double actualValues = Converter.Convert60To10(testedValues);
            //Assert    
            Assert.AreEqual(expectedValue, actualValues);
        }
        [TestMethod]
        public void Can_Convert_Base60_To_Base10_Test2() {
            //Arrange
            Stack<long> testedValues = new Stack<long>();
            testedValues.Push(9);
            testedValues.Push(31);
            testedValues.Push(33);
            testedValues.Push(33);
            testedValues.Push(9);

            long expectedValue = 123456789;
            //Act
            double actualValues = Converter.Convert60To10(testedValues);
            //Assert    
            Assert.AreEqual(expectedValue, actualValues);
        }

        [TestMethod]
        public void Can_Convert() {
            //Arrange
            long testedValue = 1234567890;
            //Act
            var tmpResult = Converter.Convert10To60(testedValue);
            // Reverse values
            tmpResult = new Stack<long>(tmpResult); 
            long result = (long)Converter.Convert60To10(tmpResult);
            //Assert    
            Assert.AreEqual(testedValue, result);
        }

        [TestMethod]
        public void Can_Convert2() {
            //Arrange
            long testedValue = 2345818517;
            //Act
            var tmpResult = Converter.Convert10To60(testedValue);
            // Reverse values
            tmpResult = new Stack<long>(tmpResult);
            long result = (long) Converter.Convert60To10(tmpResult);
            //Assert    
            Assert.AreEqual(testedValue, result);
        }
    }
}
