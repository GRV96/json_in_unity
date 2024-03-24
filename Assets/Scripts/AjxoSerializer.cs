using System.IO;
using UnityEngine;

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

	private static Vector3 PointToVector3(Point pPoint)
	{
		return new Vector3(pPoint.x, pPoint.y, pPoint.z);
	}

	private static Point Vector3ToPoint(Vector3 pVector)
	{
		return new Point(pVector.x, pVector.y, pVector.z);
	}

	public bool ReadAjxo(Ajxo pAjxo)
	{
		if(!string.IsNullOrEmpty(_filePath) || !File.Exists(_filePath))
		{
			return false;
		}

		AjxoData ajxoData = JsonUtility.FromJson<AjxoData>(_filePath);
		int nbCubes = pAjxo.NbCubes;
		Point[] blockPositions = ajxoData.blockPositions;

		if(blockPositions.Length != nbCubes)
		{
			return false;
		}

		pAjxo.transform.position = PointToVector3(ajxoData.position);
		for(int i=0; i<nbCubes; i++)
		{
			pAjxo.GetCube(i).transform.position = PointToVector3(blockPositions[i]);
		}

		return true;
	}

	public void SerializeAjxo(Ajxo pAjxo)
	{
		AjxoData ajxoData;
		ajxoData.name = pAjxo.name;
		ajxoData.position = Vector3ToPoint(pAjxo.transform.position);

		int nbCubes = pAjxo.NbCubes;
		Point[] blockPositions = new Point[nbCubes];
		for(int i=0; i<nbCubes; i++)
		{
			blockPositions[i] = Vector3ToPoint(pAjxo.GetCube(i).transform.position);
		}
		ajxoData.blockPositions = blockPositions;

		string jsonData = JsonUtility.ToJson(ajxoData, true);
		File.WriteAllText(_filePath, jsonData);
	}
}
