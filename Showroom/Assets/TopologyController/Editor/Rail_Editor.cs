using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Rail))]
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
