
using MauiBrownianMotion.Models;
using MauiBrownianMotion.ViewModels;

namespace MauiBrownianMotion.Tests;

public class BrownianMotionTests
{
    [Fact]
    public void GenerateBrownianMotion_ReturnsCorrectNumberOfDays()
    {
        // Arrange
        double sigma = 0.1;
        double mean = 0.01;
        double initialPrice = 100;
        int numDays = 10;

        // Act
        var prices = BrownianModel.GenerateBrownianMotion(sigma, mean, initialPrice, numDays);

        // Assert
        Assert.Equal(numDays, prices.Length);
    }

    [Fact]
    public void GenerateBrownianMotion_PricesArePositive()
    {
        // Arrange
        double sigma = 0.1;
        double mean = 0.01;
        double initialPrice = 100;
        int numDays = 10;

        // Act
        var prices = BrownianModel.GenerateBrownianMotion(sigma, mean, initialPrice, numDays);

        // Assert
        Assert.All(prices, price => Assert.True(price > 0));
    }

    [Fact]
    public void GenerateCommand_PopulatesPrices()
    {
        // Arrange
        var viewModel = new BrownianViewModel
        {
            InitialPrice = 100,
            Sigma = 10,
            Mean = 1,
            NumDays = 5
        };

        // Act
        viewModel.GenerateCommand.Execute(null);

        // Assert
        Assert.NotNull(viewModel.Prices);
        Assert.Equal(5, viewModel.Prices.Count);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void GenerateBrownianMotion_WithInvalidNumDays_ThrowsArgumentException(int numDays)
    {
        // Arrange
        double sigma = 0.1;
        double mean = 0.01;
        double initialPrice = 100;

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => BrownianModel.GenerateBrownianMotion(sigma, mean, initialPrice, numDays));
        Assert.Equal("O número de dias deve ser um valor positivo. (Parameter 'numDays')", ex.Message);
    }

    [Fact]
    public void GenerateBrownianMotion_WithNegativeInitialPrice_ThrowsArgumentException()
    {
        // Arrange
        double sigma = 0.1;
        double mean = 0.01;
        double initialPrice = -100;
        int numDays = 10;

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => BrownianModel.GenerateBrownianMotion(sigma, mean, initialPrice, numDays));
        Assert.Equal("O preço inicial não pode ser negativo. (Parameter 'initialPrice')", ex.Message);
    }

    [Fact]
    public void GenerateBrownianMotion_WithNegativeSigma_ThrowsArgumentException()
    {
        // Arrange
        double sigma = -0.1;
        double mean = 0.01;
        double initialPrice = 100;
        int numDays = 10;

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => BrownianModel.GenerateBrownianMotion(sigma, mean, initialPrice, numDays));
        Assert.Equal("O valor de Sigma não pode ser negativo. (Parameter 'sigma')", ex.Message);
    }
}
