using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {

	public float speed = 90f;
	public float turnSpeed = 500f;
	public float hoverForce = 65f;
	public float hoverHeight = 3.5f;
	public float jumpBoost = 50f;
	public LayerMask myLayerMask;
	
	private float currentHeight;
	private Vector3 jumpBoostVector3;
	private float powerInput;
	private float turnInput;
	private Rigidbody carRigidbody;
	
	
	void Awake () 
	{
		carRigidbody = GetComponent <Rigidbody>();
		jumpBoostVector3 = jumpBoost * Vector3.up;
	}
	
	void Update () 
	{
		powerInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
	}
	
	void FixedUpdate()
	{
		Ray ray = new Ray (transform.position, -transform.up);
		RaycastHit hit;
		
		if (Physics.Raycast(ray, out hit, hoverHeight, myLayerMask))
		{
			float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
			Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
			carRigidbody.AddForce(appliedHoverForce, ForceMode.Acceleration);
		}
		
		if (Physics.Raycast(ray, out hit, 10000f))
		{
			if(hit.distance > 170f)//hoverHeight*500f)
			{
				Physics.gravity = new Vector3(0f, -5000f, 0f);
				Debug.Log("Physics.gravity = " + Physics.gravity);
				//carRigidbody.AddForce(-(0.1f * jumpBoostVector3), ForceMode.Acceleration);
			}
			else
			{
				Physics.gravity = new Vector3(0f, -50f, 0f);//(0f, -9.8f, 0f);
				//carRigidbody.AddForce((0.1f * jumpBoostVector3), ForceMode.VelocityChange);
			}
		}
		
		Mathf.Clamp(transform.position.y, 2, int.MaxValue);
		
		carRigidbody.AddRelativeForce(0f, 0f, powerInput * speed); //Adds a force to the rigidbody relative to its coordinate system.
		
		if(powerInput >= 0)
		{
			carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f); //Adds a torque to the rigidbody relative to its coordinate system.
		}
		else
		{
			carRigidbody.AddRelativeTorque(0f, (turnInput * turnSpeed) * -1f, 0f); //if we are moving backward, turn the car in the direction a normal car would turn
		}
		
		if(Input.GetKeyDown(KeyCode.Space)) //jump boosting
		{
			//jumpBoostVector3 = jumpBoost * Vector3.up;
			//Vector3 tempY = jumpBoostVector3;
			//tempY.y *= 100f;
			//jumpBoostVector3 = tempY;
			Debug.Log(jumpBoostVector3);
			carRigidbody.AddForce(jumpBoostVector3, ForceMode.VelocityChange);
		}
	}
}