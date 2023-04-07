using UnityEngine;

namespace Assets.Scripts.Data.DataExtensionFolder
{
    public static class DataExtension
    {
        public static T ToDeserialized<T>(this string json) => JsonUtility.FromJson<T>(json);
        
        public static string ToJsong(this object obj) => JsonUtility.ToJson(obj);

    }
}
