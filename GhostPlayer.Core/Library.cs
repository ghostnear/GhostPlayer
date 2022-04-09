using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace GhostPlayer.Core
{
    [Serializable]
    public class SongLibrary
    {
        // The entire song list
        public List<Song> SongList
        {
            get;
            private set;
        }

        // Library constructor
        public SongLibrary()
        {
            SongList = new List<Song>();
        }

        // Add a specific song to the list
        public void AddSong(Song newSong)
        {
            // Check for duplicate existence
            foreach(Song x in SongList)
                if (x.Path == newSong.Path)
                    return;
            SongList.Add(newSong);
        }

        /// <summary>
        /// Saves the library to a file at the specified path.
        /// </summary>
        public void SaveTo(string path)
        {
            BinaryFormatter serializer = new BinaryFormatter();

            // Serialize the instance and write it to a file
            using var ms = new MemoryStream();
            serializer.Serialize(ms, this);
            File.WriteAllBytes(path, ms.GetBuffer());
        }

        /// <summary>
        /// Load the library from a file at the specified path.
        /// </summary>
        public void LoadFrom(string path)
        {
            // Check for file existence first
            if(File.Exists(path))
            {
                BinaryFormatter serializer = new BinaryFormatter();

                // Read all file bytes from the path
                using var ms = new MemoryStream();
                byte[] src = File.ReadAllBytes(path);
                ms.Write(src, 0, src.Length);
                ms.Seek(0, SeekOrigin.Begin);

                // New library object
                var obj = (SongLibrary)serializer.Deserialize(ms);
                SongList = obj.SongList;
            }
        }
    }
}
