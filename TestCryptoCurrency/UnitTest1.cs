using System;
using Xunit;
using CryptoCurrency;

namespace TestCryptoCurrency
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("etherum", 2000, 2, "bitcoin", 4000, 1)]
        [InlineData("etherum", 2000, -2, "bitcoin", 4000, -1)]
        [InlineData("etherum", 2000, 0, "bitcoin", 4000, 0)]
        [InlineData("etherum", 2000, 2, "bitcoin", -4000, 2)]
        [InlineData("etherum", 2000, 2, "bitcoin", 0, 0)]
        public void TestConvert(string fromCurrencyName, double fromCurrencyUnitPrice, double fromCurrencyAmountOfUnits, string toCurrencyName, double toCurrencyUnitPrice, double expected)
        {
            // arrange
            var converter = new Converter();
            converter.SetPricePerUnit(toCurrencyName, 2000);
          
            converter.SetPricePerUnit(fromCurrencyName, fromCurrencyUnitPrice);
            converter.SetPricePerUnit(toCurrencyName, toCurrencyUnitPrice);

            // act
            double actual = converter.Convert(fromCurrencyName, toCurrencyName, fromCurrencyAmountOfUnits);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestConvertException()
        {
            // arrange
            var converter = new Converter();

            // act

            // assert
            Assert.Throws<ArgumentException>(() => converter.Convert("etherum", "bitcoin", 2));
        }
    }
}
