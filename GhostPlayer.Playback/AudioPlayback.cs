using System;
using GhostPlayer.Core;
using LibVLCSharp.Shared;

namespace GhostPlayer.Playback
{
    internal class AudioPlayback
    {
        // VLC libraries instance
        private LibVLC _lib;
        private MediaPlayer _player;
        private bool _playing;

        /// <summary>
        /// Is true if the player is currently playing audio.
        /// </summary>
        public bool IsPlaying
        {
            get { return _playing; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public AudioPlayback()
        {
            // Initialise the VLC subsystem
            _lib = new LibVLC();
            _player = new MediaPlayer(_lib);
            _playing = false;
        }

        /// <summary>
        /// Starts the playback of the song specified.
        /// </summary>
        public void Play(Song s)
        {
            _player.Media = new Media(_lib, new Uri(s.Path));
            _player.Play();
            _playing = true;
        }

        /// <summary>
        /// Pauses the currently running playback.
        /// </summary>
        public void Pause()
        {
            if (_player.CanPause)
            {
                _player.Pause();
                _playing = false;
            }
            else
                Stop();
        }

        /// <summary>
        /// Stops the playback completely.
        /// </summary>
        public void Stop()
        {
            _player.Stop();
            _playing = false;
        }
    }
}
