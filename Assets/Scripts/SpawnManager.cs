using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public Transform[] SpawnPoint = new Transform[2];
	public GameObject Enemy;
	private float SpawnTime;

	void Start () {
		SpawnTime = 10.0f;
		StartCoroutine (Spawn ());
	}

	IEnumerator Spawn()
	{
		while(true)
		{
			int point = Random.Range (0, 2);
			Instantiate(Enemy, SpawnPoint[point].position, SpawnPoint [point].rotation);
			yield return new WaitForSeconds (SpawnTime);
			SpawnTime -= 0.01f;
		}

		yield return null;
	}
	
	void Update ()
	{

	}
}
