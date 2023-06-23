using FTCalculator.Services;

namespace FTCalculator.Tests.Services
{
    public class OperationServiceTest
    {
        private IOperationService _operationService;

        public OperationServiceTest() 
        {
            _operationService = new OperationService();
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 1, 1)]
        [InlineData(-1, 0, -1)]
        [InlineData(0, -1, -1)]
        [InlineData(1, -1, 0)]
        [InlineData(-1, 1, 0)]
        public void Add_WhenCalled_ReturnsSumOfTwoDoubles(double valueOne, double valueTwo, double result)
        {
            Assert.Equal(result, _operationService.Add(valueOne, valueTwo));
        }

        [Fact]
        public void Divide_WhenCalledWithZeroAsDeniminator_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => _operationService.Divide(10, 0));
        }
    }
}
