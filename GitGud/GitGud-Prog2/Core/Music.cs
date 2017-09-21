using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GitGud_Prog2
{
    class Music : IDisposable
    {
        static string globalVolumeEventId = "__MusicVolume";

        static float globalVolume = 1f;

        static List<Music> musics = new List<Music>();

        /// <summary>
        /// The global volume to play all music at.
        /// </summary>
        public static float GlobalVolume
        {
            get
            {
                return globalVolume;
            }
            set
            {
                globalVolume = value;
                EventRouter.Publish(globalVolumeEventId);
                foreach (var m in musics)
                {
                    m.Volume = m.Volume; //update music volume
                }
            }
        }

        SFML.Audio.Music music;
        float volume = 1f;

        /// <summary>
        /// The local volume to play this music at.
        /// </summary>
        public float Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
                music.Volume = Util.Clamp(GlobalVolume * volume, 0f, 1f) * 100f;
            }
        }

        /// <summary>
        /// Adjust the pitch of the music.  Default value is 1.
        /// </summary>
        public float Pitch
        {
            set { music.Pitch = value; }
            get { return music.Pitch; }
        }

        /// <summary>
        /// Set the playback offset of the music.
        /// </summary>
        public int Offset
        {
            set { music.PlayingOffset = new TimeSpan(0, 0, 0, 0, value); }
            get { return music.PlayingOffset.Milliseconds; }
        }

        /// <summary>
        /// Determines if the music should loop or not.
        /// </summary>
        public bool Loop
        {
            set { music.Loop = value; }
            get { return music.Loop; }
        }

        /// <summary>
        /// The duration in milliseconds of the music.
        /// </summary>
        public int Duration
        {
            get { return music.Duration.Milliseconds; }
        }


        /// <summary>
        /// Load a music file from a file path.
        /// </summary>
        /// <param name="source"></param>
        public Music(string source, bool loop = true)
        {
            music = new SFML.Audio.Music(source);
            music.Loop = loop;
            Initialize();
        }

        /// <summary>
        /// Load a music stream from an IO stream.
        /// </summary>
        /// <param name="stream"></param>
        public Music(Stream stream)
        {
            music = new SFML.Audio.Music(stream);
            music.Loop = true;
            Initialize();
        }

        /// <summary>
        /// Play the music.
        /// </summary>
        public void Play()
        {
            music.Volume = Util.Clamp(GlobalVolume * Volume, 0f, 1f) * 100f;
            music.Play();
        }

        /// <summary>
        /// Stop the music!
        /// </summary>
        public void Stop()
        {
            music.Stop();
        }

        /// <summary>
        /// Pause the music.
        /// </summary>
        public void Pause()
        {
            music.Pause();
        }

        void Initialize()
        {
            music.RelativeToListener = false;
            music.Attenuation = 100;
            EventRouter.Subscribe(globalVolumeEventId, HandleGlobalVolumeChange);
        }

        void HandleGlobalVolumeChange(EventRouter.Event e)
        {
            // Update volume (Volume setter does this, so set Volume to Volume)
            Volume = Volume;
        }


        public void Dispose()
        {
            EventRouter.Unsubscribe(globalVolumeEventId, HandleGlobalVolumeChange);
            music.Dispose();
        }
    }
}
