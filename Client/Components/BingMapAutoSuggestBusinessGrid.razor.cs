using BlazorBootstrap;
using EN.Client.Models;
using Microsoft.JSInterop;

namespace EN.Client.Components;

public partial class BingMapAutoSuggestBusinessGrid
{
    private string _query = string.Empty;
    private string _status = string.Empty;
    private string _latitude = default!;
    private string _longitude = default!;

    private Grid<BingMapAutoSuggestValue> _bingMapAutoSuggestGrid = default!;
    private List<BingMapAutoSuggestValue> _bingMapAutoSuggestValues = new List<BingMapAutoSuggestValue>();

    private async Task<GridDataProviderResult<BingMapAutoSuggestValue>> BingMapBusinessDataProvider(GridDataProviderRequest<BingMapAutoSuggestValue> request)
    {
        return await Task.FromResult(request.ApplyTo(_bingMapAutoSuggestValues));
    }
    private async Task SearchToBingMapAutoSuggest()
    {
        if (string.IsNullOrEmpty(_query))
        {
            _status = "Fill something for searching!";
            return;
        }

        var coords = await JS.InvokeAsync<string>("findCords");

        if (!string.IsNullOrEmpty(coords) && coords.Contains("*"))
        {
            var coordArray = coords.Split('*');

            _latitude = coordArray[0];
            _longitude = coordArray[1];
        }
        else
        {
            _status = "Unavailable location. Please Allow access to the location!";
            return;
        }

        _bingMapAutoSuggestValues = await BingMapAutoSuggestService.GetBusinessAddressesAsync(_query, _latitude, _longitude);
        await _bingMapAutoSuggestGrid.RefreshDataAsync();

    }

    private void ClearQuery()
    {
        _query = string.Empty;
        _bingMapAutoSuggestValues = new List<BingMapAutoSuggestValue>();
        _bingMapAutoSuggestGrid.ResetPageNumber();
    }

    protected override void OnInitialized()
    { }
}
