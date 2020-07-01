using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ElementPlayer.Core.Assets;
using MediaManager;

namespace ElementPlayer.Core.ViewModels
{
    public class BrowseViewModel : BaseViewModel
    {
        private readonly IMediaManager _mediaManager;

        public BrowseViewModel(IMediaManager mediaManager)
        {
            this._mediaManager = mediaManager;
        }

        public override string Title => "Browse";

        public ObservableCollection<string> Items { get; set; } = new ObservableCollection<string>(MediaPlaybackAssets.Mp3UrlList);

        public IMvxAsyncCommand<string> ItemSelected => new MvxAsyncCommand<string>(SelectItem);

        private async Task SelectItem(string url)
        {
            await _mediaManager.Play(url);
        }
    }
}
