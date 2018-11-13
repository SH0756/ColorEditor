using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ColorEditorWindow : EditorWindow
{
    public Color        defaultBackgroundColor  { get; set; }
    public ColorData[]  colorDataArray          { get; set; }
    public int          colorDataCount          { get; set; }
    public int          colorDataCapacityCount  { get; set; }

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
        // UNDONE : エディタの初期化
        defaultBackgroundColor = GUI.backgroundColor;
        colorDataCount = 0;
        colorDataCapacityCount = 5;
        colorDataArray = new ColorData[colorDataCapacityCount];
    }

    private void OnGUI()
    {
        // UNDONE : エディタのＵＩ
        using (new GUILayout.VerticalScope(EditorStyles.helpBox))
        {
            GUI.backgroundColor = Color.gray;
            using (new GUILayout.HorizontalScope(EditorStyles.toolbar))
            {
                GUILayout.Label("色の管理");
            }
            GUI.backgroundColor = defaultBackgroundColor;

            using (new GUILayout.VerticalScope(EditorStyles.helpBox))
            {
                using (new GUILayout.HorizontalScope())
                {
                    GUILayout.Label("Name");
                    GUILayout.Label("Color");
                }
                for (int i = 0; i < colorDataCount; i++)
                {
                    using (new GUILayout.HorizontalScope(EditorStyles.helpBox))
                    {
                        colorDataArray[i].name = EditorGUILayout.TextField(colorDataArray[i].name);
                        colorDataArray[i].color = EditorGUILayout.ColorField(colorDataArray[i].color);
                        if(GUILayout.Button("Clear"))
                        {
                            // HACK : 初期化または削除、それか両方
                            // HACK : カラーの初期化時にアルファも初期化
                            colorDataArray[i].name = string.Empty;
                            colorDataArray[i].color = Color.black;
                        }
                    }
                }
            }

            if(GUILayout.Button("Add"))
            {
                if(colorDataCount >= colorDataCapacityCount)
                {
                    colorDataCapacityCount += 5;

                    var tempArray = new ColorData[colorDataCount];
                    colorDataArray.CopyTo(tempArray, 0);
                    colorDataArray.Initialize();
                    colorDataArray = new ColorData[colorDataCapacityCount];
                    tempArray.CopyTo(colorDataArray, 0);
                }

                // TODO : 追加したくないときの処理

                colorDataCount++;
            }
        }
    }

    public struct ColorData
    {
        public string name { get; set; }
        public Color color { get; set; }
    }
}
