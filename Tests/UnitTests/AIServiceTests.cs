using Xunit;
using Moq;
using SupplySyncBackend.Services;
using SupplySyncBackend.Models;

public class AIServiceTests
{
    private readonly Mock<IDataProcessor> _dataProcessorMock;
    private readonly AIService _aiService;

    public AIServiceTests()
    {
        _dataProcessorMock = new Mock<IDataProcessor>();
        _aiService = new AIService(_dataProcessorMock.Object);
    }

    [Fact]
    public void PredictStock_Success()
    {
        var input = new StockPredictionInput();
        _dataProcessorMock.Setup(dp => dp.Process(input)).Returns(new StockPredictionOutput { RecommendedStock = 50 });

        var result = _aiService.PredictStock(input);

        Assert.Equal(50, result.RecommendedStock);
    }
}
