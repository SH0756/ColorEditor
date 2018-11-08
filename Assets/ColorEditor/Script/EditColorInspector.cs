using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CustomEditor(typeof(EditColorController))]
public class EditColorInspector : Editor
{
    private EditColorController editColorController = null;

    private void OnEnable()
    {
        editColorController = (EditColorController)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        // TODO : 以下に Inspector 上の GUI を書き込む

        GUILayout.Label("ColorEditorInspector");
    }

}
