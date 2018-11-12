using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ColorEditorWindow : EditorWindow
{
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
    }

    private void OnGUI()
    {
        // TODO : エディタのＵＩ
    }
}
