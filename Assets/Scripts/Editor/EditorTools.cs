using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorTools
{
    [MenuItem("MyTools/һ�����")]
    private static void CleanData() 
    {
        PlayerPrefs.DeleteAll();
    }
}
