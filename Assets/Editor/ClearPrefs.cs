using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClearPrefs
{
    [MenuItem("Tools/ClearPrefs")]
    public static void CleanPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
