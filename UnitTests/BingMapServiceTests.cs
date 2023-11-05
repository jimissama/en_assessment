using Server.Services.BingMap;
using Server.Models;
using Moq;
using Moq.Protected;
using System.Net;

namespace UnitTests.BingMapServiceTests;

public class BingMapServiceTests
{
    private readonly Mock<HttpMessageHandler> _handler;
    private BingMapAutoSuggestService _sut = default!;

    public BingMapServiceTests()
    {
        _handler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
    }

    [Fact]
    public void GetValues_NotFoundException()
    {
        SetHttpHandler_GetStringAsync_Empty();

        var httpClient = new HttpClient(_handler.Object)
        {
            BaseAddress = new Uri("http://test.com/"),
        };

        _sut = new BingMapAutoSuggestService(httpClient, new BingMapAuth());

        Assert.ThrowsAsync<HttpRequestException>(()=> _sut.GetValuesAsync(new EN.Shared.BingMapAutoSuggestRequest()));
    }


    /// <summary>
    /// More scenarios
    /// </summary>
    /// 
    private void SetHttpHandler_GetStringAsync_Empty()
    {
        _handler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(""),
            })
            .Verifiable();
    }
}