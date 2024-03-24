using UnityEngine;

// "Ajxo" means "thing" in Esperanto.
public class Ajxo : MonoBehaviour
{
	[SerializeField] private GameObject[] _cubes;
	private AjxoSerializer _serializer;

	public int NbCubes
	{
		get
		{
			return _cubes.Length;
		}
	}

	void Awake()
	{
		_serializer = GetComponent<AjxoSerializer>();
	}

	public GameObject GetCube(int pCubeIndex)
	{
		if(pCubeIndex < 0 || pCubeIndex >= NbCubes)
		{
			return null;
		}

		return _cubes[pCubeIndex];
	}

	public void ReadJson()
	{
		if(_serializer)
		{
			_serializer.ReadAjxo(this);
		}
	}

	public void WriteAsJson()
	{
		if(_serializer)
		{
			_serializer.SerializeAjxo(this);
		}
	}
}
