using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AjxoSerializer))]
public class AjxoSerializerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		AjxoSerializer ajxoSerializer = (AjxoSerializer) target;
		DrawDefaultInspector();

		if(GUILayout.Button("Read JSON"))
		{
			ajxoSerializer.ReadAjxo();
		}

		if(GUILayout.Button("Save as JSON"))
		{
			ajxoSerializer.SerializeAjxo();
		}
	}
}
