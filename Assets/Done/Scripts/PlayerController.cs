using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	//variables used to place shots fired
	public GameObject shot;
	public Transform shotSpawn;

	//keeps bullets from tilting with player
	public Quaternion noRotation;

	//controls the rate of fire
	public float fireRate;

	//stores the time until next shot can be fired
	private float nextFire;

	void Update ()
	{
		//checks to see if fire button is pressed and if shot can be fired
		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			//added fireRate to current time to decide next time a shot can be fired
			nextFire = Time.time + fireRate;

			//creates a bullet based on variable positions
			Instantiate (shot, shotSpawn.position, noRotation);

			//plays audio clip
			audio.Play ();
		}
	}

	//method for controlling the player ship
	void FixedUpdate ()
	{
		//determines the controls being input
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//applies input controls to a new vector and applies speed variable
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed;

		//applies the new position to the player ship and limits to boundries
		rigidbody.position = new Vector3
		(
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
		);

		//applies tilt to player ship
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}
