using OrisonDailyReport.Shared.Entities.General;

namespace OrisonDailyReport.Client.Services
{
    public class ToastService
    {
        public event Action<ToastOption>? ShowToastTrigger;
        public void ShowToast(ToastOption options)
        {
            this.ShowToastTrigger?.Invoke(options);
        }
    }
}
