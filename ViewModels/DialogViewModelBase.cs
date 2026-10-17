using System;

namespace comixpaint.ViewModels
{
    public abstract class DialogViewModelBase : ViewModelBase
    {
        public event Action<bool> RequestClose;

        protected void Close(bool result = true)
        {
            RequestClose?.Invoke(result);
        }
    }
}
