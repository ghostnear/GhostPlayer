using System.Collections.Generic;

namespace GhostPlayer.Core
{
    public class SongQueue
    {
        Queue<Song> songQueue;

        public int Count
        {
            get { return songQueue.Count; }
        }

        public Song Front
        {
            get
            {
                // Return front only if empty
                if (Count != 0)
                    return songQueue.Peek();
                return null;
            }
        }

        public SongQueue()
        {
            songQueue = new Queue<Song>();
        }

        /// <summary>
        /// Push a song to the queue.
        /// </summary>
        public void PushSong(Song newSong)
        {
            songQueue.Enqueue(newSong);
        }

        /// <summary>
        /// Pops a song from the queue.
        /// </summary>
        public void PopSong()
        {
            /// Pop only if empty
            if (Count != 0)
                songQueue.Dequeue();
        }
    }
}
