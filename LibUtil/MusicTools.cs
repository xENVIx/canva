using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibUtil
{
    public class MusicTools
    {

        #region PUBLIC

        #region METHODS

        public bool LoadMusicTrackFromFile(String musicFile, out List<float> sampleData, out int sampleRate, out int channels)
        {
            bool ret = false;

            sampleData = new List<float>();
            sampleRate = -1;
            channels = -1;

            try
            {
                //byte[] musicBytes = FileTools.Instance.GetFileBytes(musicFile);

                var samples = new List<float>();
                using (var reader = new AudioFileReader(musicFile))
                {
                    sampleRate = reader.WaveFormat.SampleRate;
                    channels = reader.WaveFormat.Channels;
                    float[] buffer = new float[reader.WaveFormat.SampleRate];
                    int read;
                    while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        for (int i = 0; i < read; i++)
                            samples.Add(buffer[i]);
                    }
                }


                for (int i = 0; i < samples.Count; i++)
                {
                    if (samples[i] > 0)
                    {
                        Console.WriteLine($"Sample {i} > 0");

                    }
                }

                sampleData = samples;

                ret = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }





            return ret;
        }

        #endregion

        #region VARIABLES

        #region STATIC

        public static MusicTools Instance { get { return _instance; } }

        #endregion

        #endregion

        #endregion

        #region PRIVATE

        #region CONSTRUCTORS

        private MusicTools()
        {

        }

        #endregion

        #region VARIABLES

        #region STATIC

        private static MusicTools _instance = new MusicTools();

        #endregion

        #endregion

        #endregion

    }
}
