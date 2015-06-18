using UnityEngine;
using System.Collections;

public class LaunchPad : MonoBehaviour {

	public Vector3 launchForce;
	
	private bool usedBoost = false;

	private void OnTriggerEnter (Collider other)
	{
		if(other.transform.root.gameObject.tag == ("Player") && usedBoost == false)
		{
			other.transform.root.gameObject.GetComponent<Rigidbody>().AddForce(launchForce, ForceMode.VelocityChange);
			usedBoost = true;
		}
	}
	
	private void OnTriggerExit (Collider other)
	{
		usedBoost = false;
	}
}
