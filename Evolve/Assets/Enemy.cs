using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private Vector2 movement;
	GameObject obj;
	public int startEnergy = 10;
	public int currentEnergy;

	private Rigidbody2D rd;

	void Start()
	{
		rd = GetComponent<Rigidbody2D> ();
		currentEnergy = startEnergy;
		obj = this.gameObject;
	}


	void FixedUpdate()
	{
		movement.x = Random.Range(-80, 80) * 2;
		movement.y = Random.Range(-80, 80) * 2;

		rd.AddForce(movement);

	}

	void Update()
	{
		if (currentEnergy > 15) 
		{
			Vector3 spawnPosition = obj.transform.position;
			Instantiate (obj, spawnPosition, gameObject.transform.rotation);
			currentEnergy = 5;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.name == "TopBorder") 
		{
			//			Debug.Log ("Collision with the top!");
			movement = Vector2.Reflect (movement, Vector2.left);
			rd.AddForce (movement);
		}

		if (collision.gameObject.name == "BottomBorder") 
		{
			//			Debug.Log ("Collision with the bottom!");
			movement = Vector2.Reflect (movement, Vector2.up);
			rd.AddForce (movement);
		}

		if (collision.gameObject.name == "LeftBorder") 
		{
			//			Debug.Log ("Collision with the left!");

			movement = Vector2.Reflect (movement, Vector2.right);

			rd.AddForce (movement);
		}

		if (collision.gameObject.name == "RightBorder") 
		{
			//			Debug.Log ("Collision with the right!");

			movement = Vector2.Reflect (movement, Vector2.left);

			rd.AddForce (movement);
		}

		if (collision.gameObject.name == "Cell") 
		{
			Debug.Log ("Hit the cell!");
			currentEnergy -= 1;
		}


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("Food was eaten!");
		Debug.Log (other.gameObject.tag);

		Destroy(other.gameObject);
		currentEnergy += 1;

	}

}
