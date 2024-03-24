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

	private AjxoSerializer Serializer
	{
		get
		{
			if(_serializer == null)
			{
				_serializer = GetComponent<AjxoSerializer>();
			}

			return _serializer;
		}
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
		AjxoSerializer serializer = Serializer;

		if(serializer)
		{
			serializer.ReadAjxo(this);
		}
	}

	public void WriteAsJson()
	{
		AjxoSerializer serializer = Serializer;

		if(serializer)
		{
			serializer.SerializeAjxo(this);
		}
	}
}
