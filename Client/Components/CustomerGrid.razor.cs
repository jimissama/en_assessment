using BlazorBootstrap;
using EN.Shared;
using Microsoft.AspNetCore.Components;

namespace EN.Client.Components;

public partial class CustomerGrid
{
    [Parameter]
    public EventCallback OnCustomerEdit { get; set; }

    [Parameter]
    public EventCallback OnCustomerCreate { get; set; }
    
    [Parameter]
    public EventCallback OnCustomerDelete { get; set; }

    private Modal _modal = default!;
    private Grid<Customer> _customerGrid = default!;

    private async Task<GridDataProviderResult<Customer>> CustomersDataProvider(GridDataProviderRequest<Customer> request)
    {
        var customersData = await CustomerService.GetCustomers(request.PageNumber, request.PageSize);
        return await Task.FromResult(new GridDataProviderResult<Customer> { Data = customersData.Data, TotalCount = customersData.TotalCount });
    }

    #region Grid Events 
    private async Task OnGridCustomerCreate()
    {
        await ShowCustomerCreateModal();
    }

    private async Task OnGridCustomerEdit(Customer customer)
    {
        await ShowCustomerEditModal(customer);
    }

    private async Task OnGridCustomerDelete(Guid customerId)
    {
        await CustomerService.DeleteCustomer(customerId);
        await _customerGrid.ResetPageNumber();
        await OnCustomerDelete.InvokeAsync();
    }

    #endregion

    #region Modal Events
    private async Task OnModalClose()
    {
        await _modal.HideAsync();
    }

    private async Task OnModalUpdate(Customer customer)
    {
        await _modal.HideAsync();
        await CustomerService.UpdateCustomer(customer);
        await _customerGrid.RefreshDataAsync();
        await OnCustomerEdit.InvokeAsync();
    }

    private async Task OnModalInsert(Customer customer)
    {
        await _modal.HideAsync();
        await CustomerService.InsertCustomer(customer);
        await _customerGrid.RefreshDataAsync();
        await OnCustomerCreate.InvokeAsync();
    }

    #endregion

    #region Modal Actions
    private async Task ShowCustomerEditModal(Customer customer)
    {
        var parameters = new Dictionary<string, object>();
        parameters.Add("ModalCustomer", customer);
        parameters.Add("OnModalSave", EventCallback.Factory.Create<Customer>(this, OnModalUpdate));
        parameters.Add("OnModalClose", EventCallback.Factory.Create(this, OnModalClose));
        await _modal.ShowAsync<CustomerModal>("Edit Customer", "", parameters);
    }

    private async Task ShowCustomerCreateModal()
    {
        var parameters = new Dictionary<string, object>();
        parameters.Add("ModalCustomer", new Customer());
        parameters.Add("OnModalSave", EventCallback.Factory.Create<Customer>(this, OnModalInsert));
        parameters.Add("OnModalClose", EventCallback.Factory.Create(this, OnModalClose));
        await _modal.ShowAsync<CustomerModal>("New Customer", "", parameters);
    }

    #endregion

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }
}
