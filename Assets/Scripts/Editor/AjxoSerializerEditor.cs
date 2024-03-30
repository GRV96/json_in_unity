using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AjxoSerializer))]
public class AjxoSerializerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		AjxoSerializer ajxoSerializer = (AjxoSerializer) target;

		EditorStyles.label.wordWrap = true;
		EditorGUILayout.LabelField(
			"This script serializes the position of an Ajxo and its cubes in JSON. Before use, make sure that the Ajxo contains the cubes' reference at the right indices.");
		DrawDefaultInspector();

		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Save as JSON"))
		{
			ajxoSerializer.SerializeAjxo();
		}

		if(GUILayout.Button("Read JSON"))
		{
			ajxoSerializer.ReadAjxo();
		}
		GUILayout.EndHorizontal();
	}
}
