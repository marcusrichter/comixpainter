using comixpaint.Services.App;

namespace comixpaint.ViewModels
{
    public class InitViewModel : ViewModelBase
    {
        private readonly InitService _initService;

        public InitViewModel(InitService initService)
        {
            _initService = initService;
        }

        public void Init()
        {
            _initService.Init();
        }
    }
}
