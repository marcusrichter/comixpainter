using comixpaint.Services.App;

namespace comixpaint.ViewModels
{
    public class SystemViewModel : ViewModelBase
    {
        private readonly SystemService _systemService;

        public SystemViewModel(SystemService systemService)
        {
            _systemService = systemService;
        }

        public void Init()
        {
            _systemService.Init();
        }
    }
}
