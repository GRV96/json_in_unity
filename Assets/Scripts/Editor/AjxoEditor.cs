using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Ajxo))]
public class AjxoEditor : Editor
{
	public override void OnInspectorGUI()
	{
		Ajxo ajxo = (Ajxo) target;
		DrawDefaultInspector();

		if(GUILayout.Button("Read JSON"))
		{
			ajxo.ReadJson();
		}

		if(GUILayout.Button("Save as JSON"))
		{
			ajxo.WriteAsJson();
		}
	}
}
