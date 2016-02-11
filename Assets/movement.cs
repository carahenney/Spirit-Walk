using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	// switches//
	public bool bird = false;
	public bool human = true;
	public bool wolf = false;
	public bool onground = false;
	public bool doublejump = false;
	//human variables//
	public float movementspeed = 10f;
	public float jumpspeed = 300f;
	// wolf variables//
	public float movementspeedwolf = 15f;
	public float jumpspeedwolf = 250f;
	// bird variables//
	public float movementspeedbird = 10f;
	public float jumpspeedbird = 100f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (human == true) 
		{
			Humanform ();
		}	
		if (wolf == true) 
		{
			Wolfform ();
		}
		if (bird == true) 
		{
			Birdform ();
		}

		if (Input.GetKey (KeyCode.K)) // WOLF form switch//
		{
			wolf = true;
			human = false;
			bird = false;
		} 
		else if (Input.GetKey (KeyCode.L)) // Bird form switch//
		{
			wolf = false;
			human = false;
			bird = true;
		} 
		else 
		{
			bird = false;
			human = true;
			wolf = false;
		}

	}







	void Wolfform()
	{
		if ((onground | doublejump) & Input.GetKeyDown (KeyCode.W))
		{
			rigidbody2D.AddForce (Vector2.up * jumpspeedwolf);
			doublejump = false;
		}
		if (onground == true)
			if (Input.GetKey (KeyCode.D)) 
		{
			rigidbody2D.AddForce (Vector2.right * movementspeedwolf);
		}
		if (onground == true)
			if (Input.GetKey (KeyCode.A))
		{
			rigidbody2D.AddForce (Vector2.right * -movementspeedwolf);
		}
	}
	void Humanform()
	{
		if ((onground | doublejump) & Input.GetKeyDown (KeyCode.W))
		{
			rigidbody2D.AddForce (Vector2.up * jumpspeed);
			doublejump = false;
		}
		if (onground == true)
			if (Input.GetKey (KeyCode.D)) 
		{
			rigidbody2D.AddForce (Vector2.right * movementspeed);
		}
		if (onground == true)
			if (Input.GetKey (KeyCode.A))
		{
			rigidbody2D.AddForce (Vector2.right * -movementspeed);
		}
	}
	void Birdform()
	{
		if ( Input.GetKey (KeyCode.W))
		{
			rigidbody2D.AddForce (Vector2.up * jumpspeedbird);
		}
			if (Input.GetKey (KeyCode.D)) 
		{
			rigidbody2D.AddForce (Vector2.right * movementspeedbird);
		}
			if (Input.GetKey (KeyCode.A))
		{
			rigidbody2D.AddForce (Vector2.right * -movementspeedbird);
		}
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "ground")
			onground = true;
	}
	
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.name == "ground")
			onground = false;
		doublejump = true;
	}








}
