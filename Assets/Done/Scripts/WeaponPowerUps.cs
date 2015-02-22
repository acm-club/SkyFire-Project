using UnityEngine;
using System.Collections;

public class WeaponPowerUps : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;
	
	public GameObject startShot;
	public Transform startShotSpawn;
	
	
	public GameObject shot;
	public Transform shotSpawn;
	
	//edited variables
	public GameObject shot2;
	public Transform shotSpawn2;
	//edited variables
	public GameObject shot3;
	public Transform shotSpawn3;
	public GameObject shot4;
	public Transform shotSpawn4;
	public GameObject shot5;
	public Transform shotSpawn5;
	public GameObject shot6;
	public Transform shotSpawn6;
	public GameObject shot7;
	public Transform shotSpawn7;
	//end of edits
	
	//counter for number of shots for spreadshot before it fades
	public int myCounter = 0;
	//Shot wait between power up
	public float shotWait;
	
	public float fireRate;
	
	private float nextFire;
	
	//Boolean for if spread shot powerup is activated
	private bool spreadShotBool = false;
	
	void Update ()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			
			//Regular shot spead if spreadShotBool requirments not met
			if(spreadShotBool == false)
			{
				nextFire = Time.time + fireRate;
				Instantiate (startShot, startShotSpawn.position, startShotSpawn.rotation);
				audio.Play ();
			}
			
			
			//If user score is > then 50, spreadShotBool is actived for power up to begin
			if(GameController.score > 50)
			{
				spreadShotBool = true;
			}
			
			//If spreadShotBool is activated, ship fires 19 times before being set to false
			if(spreadShotBool == true && myCounter < 19)
			{
				myCounter++;
				nextFire = Time.time + fireRate;
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
				//new shot student code
				Instantiate(shot2, shotSpawn2.position, shotSpawn2.rotation);
				Instantiate(shot3, shotSpawn3.position, shotSpawn3.rotation);
				Instantiate(shot4, shotSpawn4.position, shotSpawn4.rotation);
				Instantiate(shot5, shotSpawn5.position, shotSpawn5.rotation);
				Instantiate(shot6, shotSpawn6.position, shotSpawn6.rotation);
				Instantiate(shot7, shotSpawn7.position, shotSpawn7.rotation);
				audio.Play ();
				
			}
			
			//After spreadShotBool has shot 19 times the power up is turned off
			if(myCounter >= 19)
				spreadShotBool = false;
			
		}
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed;
		
		rigidbody.position = new Vector3
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
				);
		
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}
