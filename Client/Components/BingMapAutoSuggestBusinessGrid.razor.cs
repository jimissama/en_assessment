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

    private Grid<BusinessAddress> _businessGrid = default!;
    private List<BusinessAddress> _businessAddresses = new List<BusinessAddress>();

    private async Task<GridDataProviderResult<BusinessAddress>> BingMapBusinessDataProvider(GridDataProviderRequest<BusinessAddress> request)
    {
        return await Task.FromResult(request.ApplyTo(_businessAddresses));
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

        _businessAddresses = await BingMapAutoSuggestService.GetBusinessAddressesAsync(_query, _latitude, _longitude);
        await _businessGrid.RefreshDataAsync();

    }

    private void ClearQuery()
    {
        _query = string.Empty;
        _businessAddresses = new List<BusinessAddress>();
        _businessGrid.ResetPageNumber();
    }

    protected override void OnInitialized()
    { }
}
