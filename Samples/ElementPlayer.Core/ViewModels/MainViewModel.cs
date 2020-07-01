using MediaManager;

namespace ElementPlayer.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            CrossMediaManager.Current.StateChanged += Current_StateChanged;
        }

        private void Current_StateChanged(object sender, MediaManager.Playback.StateChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(IsPlaying));
        }

        public IMvxAsyncCommand PlayerCommand => new MvxAsyncCommand(() => NavigationService.Navigate<PlayerViewModel>());

        public bool IsPlaying => CrossMediaManager.Current.IsPlaying();
    }
}
