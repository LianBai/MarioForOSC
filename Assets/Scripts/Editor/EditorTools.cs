using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorTools
{
    [MenuItem("MyTools/Ò»¼þÇå¿â")]
    private static void CleanData() 
    {
        PlayerPrefs.DeleteAll();
    }
}
