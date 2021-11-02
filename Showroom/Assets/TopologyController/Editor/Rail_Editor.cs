using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MyGameObjectScript))]
[CanEditMultipleObjects]
public class EditorGUILayoutPropertyField : Editor
{
    SerializedProperty m_IntProp;
    SerializedProperty m_VectorProp;
    SerializedProperty m_GameObjectProp;

    void OnEnable()
    {
        // Fetch the objects from the GameObject script to display in the inspector
        m_IntProp = serializedObject.FindProperty("m_MyInt");
        m_VectorProp = serializedObject.FindProperty("m_MyVector");
        m_GameObjectProp = serializedObject.FindProperty("m_MyGameObject");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        //The variables and GameObject from the MyGameObject script are displayed in the Inspector with appropriate labels
        EditorGUILayout.PropertyField(m_IntProp, new GUIContent("Int Field"), GUILayout.Height(60));
        EditorGUILayout.PropertyField(m_VectorProp, new GUIContent("Vector Object"));

        GUILayout.Label("Geometry:", EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(m_GameObjectProp, new GUIContent("Game Object"));

        // Apply changes to the serializedProperty - always do this at the end of OnInspectorGUI.
        serializedObject.ApplyModifiedProperties();
    }
}

[CustomEditor(typeof(Rail))]
[CanEditMultipleObjects]
public class Rail_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        Rail rail = (Rail)target;

        GUILayout.Label("Geometry:", EditorStyles.boldLabel);

        //EditorGUILayout.Vector3Field("StartPoint", rail.StartPoint);
        rail.StartPoint = EditorGUILayout.Vector3Field("Start Point (pivot)", rail.StartPoint);

        EditorGUI.BeginDisabledGroup(rail.EndFromRail && rail.NextRail != null);
        rail.Direction = EditorGUILayout.Vector3Field("Direction", rail.Direction);
        rail.EndPoint = EditorGUILayout.Vector3Field("End Point", rail.EndPoint);
        EditorGUI.EndDisabledGroup();

        GUILayout.Label("Connections:", EditorStyles.boldLabel);

        rail.NextRail = (Rail)EditorGUILayout.ObjectField("Next Rail", rail.NextRail, typeof(Rail), true);

        EditorGUI.BeginDisabledGroup(rail.NextRail == null);
        rail.EndFromRail = EditorGUILayout.Toggle("End from the Next Rail?", rail.EndFromRail);
        EditorGUI.EndDisabledGroup();

        GUILayout.Label("Production:", EditorStyles.boldLabel);
        rail.Cart = (Cart)EditorGUILayout.ObjectField("Cart on Rail", rail.Cart, typeof(Cart), true);

        GUILayout.Label("Options:", EditorStyles.boldLabel);
        Cube.Size = EditorGUILayout.Slider("Dot size", Cube.Size, 0.05f, 1f);

        base.OnInspectorGUI();

    }

}
