using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.Collections;

[CreateAssetMenu(fileName = "New Dialog", menuName ="New Dialog/Dialog")]
public class DialogSettings : ScriptableObject
{
    [Header("Settigns")]
    public GameObject actor;

    [Header("Dialog")]
    public Sprite speakerSprite;
    public string setence;

    public List<Setences> dialogues = new List<Setences>();

}

[System.Serializable]
public class Setences
{
    public string actorName;
    public Sprite profile;
    public Languages setence;
}

[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
    public string spanish;
}

#if UNITY_EDITOR

[CustomEditor(typeof(DialogSettings))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogSettings ds = (DialogSettings)target;

        Languages l = new Languages();
        l.portuguese = ds.setence;

        Setences s = new Setences();
        s.profile = ds.speakerSprite;
        s.setence = l;

        if (GUILayout.Button("Create Dialog"))
        {
            if(ds.setence != "")
            {
                ds.dialogues.Add(s);

                ds.speakerSprite = null;
                ds.setence = "";
            }
        }
    }
}


#endif
