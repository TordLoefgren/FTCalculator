using FTCalculator.Enums;
using FTCalculator.Services;

namespace FTCalculator.Tests.Services
{
    public class GenericBinaryOperationServiceTest
    {
        private readonly IGenericBinaryOperationService _genericBinaryOperationService;

        public GenericBinaryOperationServiceTest() 
        {
            _genericBinaryOperationService = new GenericBinaryOperationService();
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2, 0, 2)]
        [InlineData(0, 2, 2)]
        [InlineData(-2, 0, -2)]
        [InlineData(0, -2, -2)]
        [InlineData(2, -2, 0)]
        [InlineData(-2, 2, 0)]
        [InlineData(-2, -2, -4)]
        public void Add_Should_ReturnCorrectSum(double valueOne, double valueTwo, double expected)
        {
            Assert.Equal(expected, _genericBinaryOperationService.Add(valueOne, valueTwo));
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2, 0, 2)]
        [InlineData(0, 2, -2)]
        [InlineData(-2, 0, -2)]
        [InlineData(0, -2, 2)]
        [InlineData(2, -2, 4)]
        [InlineData(-2, 2, -4)]
        [InlineData(-2, -2, 0)]
        public void Subtract_Should_ReturnCorrectDifference(double valueOne, double valueTwo, double expected)
        {
            Assert.Equal(expected, _genericBinaryOperationService.Subtract(valueOne, valueTwo));
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2, 0, 0)]
        [InlineData(0, 2, 0)]
        [InlineData(-2, 0, 0)]
        [InlineData(0, -2, 0)]
        [InlineData(2, -2, -4)]
        [InlineData(-2, 2, -4)]
        [InlineData(2, 2, 4)]
        public void Multiply_Should_ReturnCorrectProduct(double valueOne, double valueTwo, double expected)
        {
            Assert.Equal(expected, _genericBinaryOperationService.Multiply(valueOne, valueTwo));
        }

        [Theory]
        [InlineData(0, 2, 0)]
        [InlineData(0, -2, 0)]
        [InlineData(2, -2, -1)]
        [InlineData(-2, 2, -1)]
        [InlineData(2, 2, 1)]
        public void Divide_Should_ReturnCorrectQuotient(double valueOne, double valueTwo, double expected)
        {
            Assert.Equal(expected, _genericBinaryOperationService.Divide(valueOne, valueTwo));
        }

        [Fact]
        public void Divide_Should_ThrowDivideByZeroException_When_CalledWithZeroAsDenominator()
        {
            Assert.Throws<DivideByZeroException>(() => _genericBinaryOperationService.Divide(10, 0));
        }

        [Theory]
        [InlineData(Operator.Add, 0, 0, 0)]
        [InlineData(Operator.Add, 2, 0, 2)]
        [InlineData(Operator.Add, 0, 2, 2)]
        [InlineData(Operator.Add, -2, 0, -2)]
        [InlineData(Operator.Add, 0, -2, -2)]
        [InlineData(Operator.Add, 2, -2, 0)]
        [InlineData(Operator.Add, -2, 2, 0)]
        [InlineData(Operator.Add, -2, -2, -4)]
        public void ComputeByOperator_Should_ReturnCorrectSum_When_CalledWithAddOperator(Operator op, double valueOne, double valueTwo, double expected)
        {
            Assert.Equal(expected, _genericBinaryOperationService.ComputeByOperator(op, valueOne, valueTwo));
        }

        [Theory]
        [InlineData(Operator.Subtract, 0, 0, 0)]
        [InlineData(Operator.Subtract, 2, 0, 2)]
        [InlineData(Operator.Subtract, 0, 2, -2)]
        [InlineData(Operator.Subtract, -2, 0, -2)]
        [InlineData(Operator.Subtract, 0, -2, 2)]
        [InlineData(Operator.Subtract, 2, -2, 4)]
        [InlineData(Operator.Subtract, -2, 2, -4)]
        [InlineData(Operator.Subtract, -2, -2, 0)]
        public void ComputeByOperator_Should_ReturnCorrectDifference_When_CalledWithSubtractOperator(Operator op, double valueOne, double valueTwo, double expected)
        {
            Assert.Equal(expected, _genericBinaryOperationService.ComputeByOperator(op, valueOne, valueTwo));
        }

        [Theory]
        [InlineData(Operator.Multiply, 0, 0, 0)]
        [InlineData(Operator.Multiply, 2, 0, 0)]
        [InlineData(Operator.Multiply, 0, 2, 0)]
        [InlineData(Operator.Multiply, -2, 0, 0)]
        [InlineData(Operator.Multiply, 0, -2, 0)]
        [InlineData(Operator.Multiply, 2, -2, -4)]
        [InlineData(Operator.Multiply, -2, 2, -4)]
        [InlineData(Operator.Multiply, 2, 2, 4)]
        public void ComputeByOperator_Should_ReturnCorrectProduct_When_CalledWithMultiplyOperator(Operator op, double valueOne, double valueTwo, double expected)
        {
            Assert.Equal(expected, _genericBinaryOperationService.ComputeByOperator(op, valueOne, valueTwo));
        }

        [Theory]
        [InlineData(Operator.Divide, 0, 2, 0)]
        [InlineData(Operator.Divide, 0, -2, 0)]
        [InlineData(Operator.Divide, 2, -2, -1)]
        [InlineData(Operator.Divide, -2, 2, -1)]
        [InlineData(Operator.Divide, 2, 2, 1)]
        public void ComputeByOperator_Should_ReturnCorrectQuotient_When_CalledWithDivideOperator(Operator op, double valueOne, double valueTwo, double expected)
        {
            Assert.Equal(expected, _genericBinaryOperationService.ComputeByOperator(op, valueOne, valueTwo));
        }
    }
}
