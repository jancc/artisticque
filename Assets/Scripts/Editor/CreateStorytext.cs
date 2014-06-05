using UnityEditor; //WICHTIG!
using UnityEngine;
using System.Collections;

public class CreateStorytext
{
        [MenuItem("Story/Create Storytext")]
        static void CreateAsset()
        {
                ScriptableObject asset = ScriptableObject.CreateInstance(typeof	(Storytext));
                AssetDatabase.CreateAsset(asset, "Assets/Story/NewStorytext.asset");
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = asset;

        }
}

