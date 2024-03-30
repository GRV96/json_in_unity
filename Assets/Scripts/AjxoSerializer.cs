using System.IO;
using UnityEngine;

[RequireComponent(typeof(Ajxo))]
public class AjxoSerializer : MonoBehaviour
{
	[System.Serializable]
	private struct AjxoData
	{
		public string name;
		public Point position;
		public Point[] blockPositions;
	}

	[System.Serializable]
	private class Point
	{
		public float x;
		public float y;
		public float z;

		public Point(float pX, float pY, float pZ)
		{
			x = pX;
			y = pY;
			z = pZ;
		}
	}

	[SerializeField] private string _filePath;
	private Ajxo _ajxo;

	private Ajxo SerializedAjxo
	{
		get
		{
			if(_ajxo == null)
			{
				_ajxo = GetComponent<Ajxo>();
			}

			return _ajxo;
		}
	}

	private static Vector3 PointToVector3(Point pPoint)
	{
		return new Vector3(pPoint.x, pPoint.y, pPoint.z);
	}

	private static Point Vector3ToPoint(Vector3 pVector)
	{
		return new Point(pVector.x, pVector.y, pVector.z);
	}

	public bool ReadAjxo()
	{
		Ajxo ajxo = SerializedAjxo;

		if(ajxo==null || string.IsNullOrEmpty(_filePath) || !File.Exists(_filePath))
		{
			return false;
		}

		string jsonData = File.ReadAllText(_filePath);
		AjxoData ajxoData = JsonUtility.FromJson<AjxoData>(jsonData);
		int nbCubes = ajxo.NbCubes;
		Point[] blockPositions = ajxoData.blockPositions;

		if(blockPositions.Length != nbCubes)
		{
			return false;
		}

		ajxo.transform.position = PointToVector3(ajxoData.position);
		for(int i=0; i<nbCubes; i++)
		{
			ajxo.GetCube(i).transform.position = PointToVector3(blockPositions[i]);
		}

		return true;
	}

	public void SerializeAjxo()
	{
		Ajxo ajxo = SerializedAjxo;

		AjxoData ajxoData;
		ajxoData.name = ajxo.name;
		ajxoData.position = Vector3ToPoint(ajxo.transform.position);

		int nbCubes = ajxo.NbCubes;
		Point[] blockPositions = new Point[nbCubes];
		for(int i=0; i<nbCubes; i++)
		{
			blockPositions[i] = Vector3ToPoint(ajxo.GetCube(i).transform.position);
		}
		ajxoData.blockPositions = blockPositions;

		string jsonData = JsonUtility.ToJson(ajxoData, true);
		File.WriteAllText(_filePath, jsonData);
	}
}
