using UnityEngine;

// "Ajxo" means "thing" in Esperanto.
public class Ajxo : MonoBehaviour
{
	[SerializeField] private GameObject[] _cubes;

	public int NbCubes
	{
		get
		{
			return _cubes.Length;
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
}
