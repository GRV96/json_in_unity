using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Ajxo))]
public class AjxoEditor : Editor
{
	public override void OnInspectorGUI()
	{
		EditorStyles.label.wordWrap = true;
		EditorGUILayout.LabelField(
			"In order to serialize the position of this Ajxo and its cubes in JSON, add script AjxoSerializer to this game object.");
		DrawDefaultInspector();
	}
}
