using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ColorEditorWindow : EditorWindow
{
    public Color defaultBackgroundColor { get; set; }

    /// <summary>
    /// エディタの作成
    /// </summary>
    [MenuItem("Editor/ColorEditor")]
    public static void Create()
    {
        ColorEditorWindow window = GetWindow<ColorEditorWindow>();
        window.minSize = new Vector2(320, 320);
    }
    
    private void OnEnable()
    {
        // TODO : エディタの初期化
        defaultBackgroundColor = GUI.backgroundColor;
    }

    private void OnGUI()
    {
        // TODO : エディタのＵＩ
        using (new GUILayout.VerticalScope(EditorStyles.helpBox))
        {
            GUI.backgroundColor = Color.gray;
            using (new GUILayout.HorizontalScope(EditorStyles.toolbar))
            {
                GUILayout.Label("色の作成");
            }
            GUI.backgroundColor = defaultBackgroundColor;

        }
    }
}
