using System;

namespace Assets.Scripts.Data.NewTypes.DataTypes
{
    [Serializable]
    public class AudioData
    {
        public float Sound;
        public float Music;

        public AudioData()
        {
            Sound = 1;
            Music = 1;
        }
    }
}
