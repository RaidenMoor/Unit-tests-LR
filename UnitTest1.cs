using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System;
using SearchElementArray;

namespace SearchElementArray.Tests
{
    public class ProgramTests
    {
        [Test]
        public void TestConvertToInt32_ValidInput()
        {
            Program.ConvertToInt32("5", out int result, out bool flag);
            Assert.IsTrue(flag);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void TestConvertToInt32_InvalidInput()
        {
            Assert.Throws<Exception>(() => Program.ConvertToInt32("abc", out int _, out bool _));
        }

        [Test]
        public void TestConvertToDouble_ValidInput()
        {
            Program.ConvertToDouble("3,14", out double result, out bool flag);
            Assert.IsTrue(flag);
            Assert.AreEqual(3.14, result);
        }

        [Test]
        public void TestConvertToDouble_InvalidInput()
        {
            Assert.Throws<Exception>(() => Program.ConvertToDouble("abc", out double _, out bool _));
        }

        [Test]
        public void TestGetArraySize_ValidSize()
        {
            
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("3"));

                int size = Program.GetArraySize();
                Assert.AreEqual(3, size);
            }
        }

        [Test]
        public void TestGetArraySize_InvalidSize()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("0\n-1\n1\n3\n"));

                int size = Program.GetArraySize();
                Assert.AreEqual(3, size); 
            }
        }

        [Test]
        public void TestBinarySearch_ElementFound()
        {
            double[] array = { 1.0, 2.0, 3.0, 4.0, 5.0 };
            double index = Program.BinarySearch(array, 3.0);
            Assert.AreEqual(2.0, index);
        }

        [Test]
        public void TestBinarySearch_ElementNotFound()
        {
            double[] array = { 1.0, 2.0, 3.0, 4.0, 5.0 };
            double index = Program.BinarySearch(array, 6.0);
            Assert.AreEqual(-1, index);
        }
        [Test]
        public void TestArrayElement_RepeatInvalidInput()
        {
            string input = "1\n3\n2\n4\n3\n5\n";
            using (var stringReader = new StringReader(input))
            {
                Console.SetIn(stringReader);
                double[] result = Program.GetOrderedArray(4);

                Assert.AreEqual(new double[] { 1, 3, 4, 5}, result);
            }
        }

        [Test]
        public void TestBinarySearch_BigNumbers()
        {
            int n = 100000;
            double[] array = new double[n];
            for(int i = 0; i < n; i++)
            {
                array[i] = (double)i + 1;
            }
            double element = 86523;
            double index = Program.BinarySearch(array, element);
            Assert.AreEqual(86522, index);
        }

        [Test]
        public void TestInputElement_ElementLessThanPrevious()
        {

            string input = "1\n2\n0\n3\n"; // Ввод элемента 0, который меньше предыдущего 2
            using (var stringReader = new StringReader(input))
            {
                Console.SetIn(stringReader);
                double[] result = Program.GetOrderedArray(3); // Ожидаем, что вызовет ошибку

                Assert.AreEqual(new double[] { 1, 2, 3 }, result, "Expected the array to be {1, 2, 3}.");

            }
        }
        [Test]
        public void GetOrderedArray_ValidInput_ReturnsArray()
        {
            // Arrange: задаем ввод, который корректен
            string input = "1\n2\n3\n"; // Все элементы валидны
            using (var stringReader = new StringReader(input))
            {
                Console.SetIn(stringReader);
                // Act: вызываем метод
                double[] result = Program.GetOrderedArray(3);
                // Assert: проверяем результат
                Assert.AreEqual(new double[] { 1, 2, 3 }, result, "Expected the array to be {1, 2, 3}.");
            }
        }
    }
}