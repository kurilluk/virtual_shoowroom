using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Rail))]
[CanEditMultipleObjects]
public class Rail_Editor : Editor
{
    //SerializedProperty StartPoint;
    //SerializedProperty Direction;
    //SerializedProperty EndPoint;
    SerializedProperty _nextRail;

    void OnEnable()
    {
        // Fetch the objects from the GameObject script to display in the inspector
        //StartPoint = serializedObject.FindProperty("StartPoint");
        //Direction = serializedObject.FindProperty("Direction");
        //EndPoint = serializedObject.FindProperty("EndPoint");
        _nextRail = serializedObject.FindProperty("_nextRail");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        Rail rail = (Rail)target;

        //GUILayout.Label("Topology", EditorStyles.boldLabel, GUILayout.Height(20));

        EditorGUILayout.PropertyField(_nextRail);
        //rail.NextRail = (Rail)EditorGUILayout.ObjectField("Next Rail", rail.NextRail, typeof(Rail), true);



        //GUILayout.Label("Geometry", EditorStyles.boldLabel);

        //EditorGUILayout.PropertyField(StartPoint);

        //EditorGUILayout.Vector3Field("StartPoint", rail.StartPoint);
        rail.StartPoint = EditorGUILayout.Vector3Field("Start Point (pivot)", rail.StartPoint);

        EditorGUI.BeginDisabledGroup(rail.EndFromRail && rail.NextRail != null);
        //EditorGUILayout.PropertyField(Direction);
        //EditorGUILayout.PropertyField(EndPoint);
        rail.Direction = EditorGUILayout.Vector3Field("Direction", rail.Direction);
        rail.EndPoint = EditorGUILayout.Vector3Field("End Point", rail.EndPoint);
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup(rail.NextRail == null);
        rail.EndFromRail = EditorGUILayout.Toggle("Data from Next Rail?", rail.EndFromRail);
        EditorGUI.EndDisabledGroup();

        GUILayout.Label("Production", EditorStyles.boldLabel, GUILayout.Height(40));
        rail.Cart = (Cart)EditorGUILayout.ObjectField("Cart on Rail", rail.Cart, typeof(Cart), true);

        GUILayout.Label("Options", EditorStyles.boldLabel);
        Cube.Size = EditorGUILayout.Slider("Dot size", Cube.Size, 0.05f, 1f);

        serializedObject.ApplyModifiedProperties();

        //base.OnInspectorGUI();

    }

}

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