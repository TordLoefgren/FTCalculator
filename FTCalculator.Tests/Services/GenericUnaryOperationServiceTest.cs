using FTCalculator.Enums;
using FTCalculator.Services;

namespace FTCalculator.Tests.Services
{
    public class GenericUnaryOperationServiceTest
    {
        private readonly IGenericUnaryOperationService _genericUnaryOperationService;

        public GenericUnaryOperationServiceTest()
        {
            _genericUnaryOperationService = new GenericUnaryOperationService();
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 6)]
        [InlineData(4, 24)]
        [InlineData(5, 120)]
        [InlineData(6, 720)]
        [InlineData(7, 5040)]
        [InlineData(8, 40320)]
        public void Factorial_Should_ReturnCorrectProduct(int integerValue, int expected)
        {
            Assert.Equal(expected, _genericUnaryOperationService.Factorial(integerValue));
        }

        [Fact]
        public void Factorial_Should_ThrowArgumentException_When_CalledWithNegativeInteger()
        {
            Assert.Throws<ArgumentException>(() => _genericUnaryOperationService.Factorial(-1));
        }
    }
}
