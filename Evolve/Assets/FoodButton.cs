using UnityEngine;
using System.Collections; 
using System.Collections.Generic;

public class FoodButton : MonoBehaviour {

	public GameObject foodCell;
	public Vector2 spawnValues;
	public float spawnWait;
	public float spawnMostWait;
	public float spawnLeastWait;
	public int startWait;
	public bool stop;
	public int amount;
	public int currentAmount;

	List<GameObject> FoodOnScene;

	public void OnClick () 
	{
		amount = 0;
		//		currentAmount = 0;
		FoodOnScene = new List<GameObject>();
		StartCoroutine (waitSpawner ());
	}
		

	IEnumerator waitSpawner ()
	{
		yield return new WaitForSeconds (startWait);

		while (amount < 10) 
		{

			Vector3 spawnPosition = new Vector3 (Random.Range (121, 883), Random.Range (117, 684), 0);

			FoodOnScene.Add ((GameObject)Instantiate (foodCell, spawnPosition, gameObject.transform.rotation));

			amount++;


			yield return new WaitForSeconds (spawnWait);

		}
	}
}
