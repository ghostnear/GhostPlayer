using ReactiveUI;
using GhostPlayer.Core;
using GhostPlayer.Playback;

namespace GhostPlayer.GUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        // Proprieties
        private AudioHandler audioHandler;
        private SongLibrary songLibrary;
        private bool _playing;
        private string _title;

        public MainWindowViewModel()
        {
            // Create main instances
            audioHandler = new AudioHandler();
            songLibrary = new SongLibrary();
            _playing = false;
            _title = "";

            // TODO: make this modifiable and not an absolute path on your PC
            songLibrary.LoadFrom("C:/Users/GhostNear/Desktop/songs.lib");

            // TESTING ONLY
            Song z = new Song();
            z.Title = "Yo";
            z.Path = "C:/Users/GhostNear/Desktop/V.mp3";
            audioHandler.AddToQueue(z);

            // TODO: please don't add all the songs to the audio queue for no reason, thanks
            foreach(Song x in songLibrary.SongList)
            {
                audioHandler.AddToQueue(x);
            }
        }


        // Bindings to help UI be responsive
        public void TogglePlayState()
        {
            if (audioHandler.isPaused)
                audioHandler.Play();
            else
                audioHandler.Pause();
            Title = audioHandler.PlayQueue.Front.Title;
            IsPlaying = !IsPlaying;
        }

        // Bindings to be displayed in the UI
        public string Title
        {
            get => _title;
            set => this.RaiseAndSetIfChanged(ref _title, value);
        }

        public bool IsPlaying
        {
            get => _playing;
            set => this.RaiseAndSetIfChanged(ref _playing, value);
        }
    }
}
