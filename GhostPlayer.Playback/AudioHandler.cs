using System;
using GhostPlayer.Core;

namespace GhostPlayer.Playback
{
    public class AudioHandler
    {
        // Driver for the VLC audio playback
        AudioPlayback _driver;
        public SongQueue PlayQueue
        {
            get;
            private set;
        }

        public bool isPaused
        {   get { return !_driver.IsPlaying; }  }

        public bool isStopped
        {   get { return !_driver.IsPlaying; } }

        public AudioHandler()
        {
            _driver = new AudioPlayback();
            PlayQueue = new SongQueue();
        }

        public void Play()
        {
            if (PlayQueue.Count != 0)
                _driver.Play(PlayQueue.Front);
        }

        public void Pause() => _driver.Pause();

        public void AddToQueue(Song s) => PlayQueue.PushSong(s);
    }
}
