using BlazorBootstrap;

namespace EN.Client.Pages;

public partial class CustomerView
{
    List<ToastMessage> messages = new List<ToastMessage>();

    #region Grid Events
    private Task OnDelete()
    {
        ShowMessage(ToastType.Success, "Delete Customer", "Customer deleted Successfully");
        return Task.CompletedTask;
    }

    private Task OnEdit()
    {
  
         ShowMessage(ToastType.Success, "Update Customer", "Customer updated Successfully");
         return Task.CompletedTask;
    }

    private Task OnCreate()
    {
        ShowMessage(ToastType.Success, "Create Customer", "Customer created Successfully");
        return Task.CompletedTask;
    }
    #endregion

    private void ShowMessage(ToastType toastType,
                             string title,
                             string message) => messages.Add(CreateToastMessage(toastType, title, message));

    private ToastMessage CreateToastMessage(ToastType toastType, string title, string message)
    => new ToastMessage
    {
        Type = toastType,
        Title = title,
        HelpText = $"{DateTime.Now}",
        Message = message
    };

    protected override void OnInitialized()
    {

        base.OnInitialized();
    }
}
