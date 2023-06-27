using FTCalculator.Enums;
using FTCalculator.Services;

namespace FTCalculator.Tests.Services
{
    public class OperatorConversionServiceTest
    {
        private readonly IOperatorConversionService _operationConversionService;

        public OperatorConversionServiceTest()
        {
            _operationConversionService = new OperatorConversionService();
        }

        [Theory]
        [InlineData(Operator.Add, "Add")]
        [InlineData(Operator.Subtract, "Subtract")]
        [InlineData(Operator.Multiply, "Multiply")]
        [InlineData(Operator.Divide, "Divide")]
        public void OperatorToString_Should_ReturnCorrectString(Operator op, string expected)
        {
            Assert.Equal(expected, _operationConversionService.OperatorToString(op));
        }

        [Theory]
        [InlineData("Add", Operator.Add)]
        [InlineData("Subtract", Operator.Subtract)]
        [InlineData("Multiply", Operator.Multiply)]
        [InlineData("Divide", Operator.Divide)]
        public void StringToOperator_Should_ReturnCorrectOperator(string  strOp, Operator expected)
        {
            Assert.Equal(expected, _operationConversionService.StringToOperator(strOp));
        }

        [Fact]
        public void StringToOperator_Should_ThrowArgumentException_When_CalledWithIncorrectOperatorString()
        {
            Assert.Throws<ArgumentException>(() => _operationConversionService.StringToOperator("NO_SUCH_OPERATOR_EXISTS"));
        }

        [Theory]
        [InlineData(Operator.Add, " + ")]
        [InlineData(Operator.Subtract, " - ")]
        [InlineData(Operator.Multiply, " * ")]
        [InlineData(Operator.Divide, " / ")]
        public void OperatorToSymbolString_Should_ReturnCorrectOperatorStringSymbol(Operator op, string expected)
        {
            Assert.Equal(expected, _operationConversionService.OperatorToSymbolString(op));
        }

        [Fact]
        public void StringToOperator_Should_ThrowArgumentException_When_CalledWithNull()
        {
            Assert.Throws<ArgumentException>(() => _operationConversionService.OperatorToSymbolString(null));
        }
    }
}
