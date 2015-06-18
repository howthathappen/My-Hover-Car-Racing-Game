using UnityEngine;
using System.Collections;

public class PortalScript : MonoBehaviour {

	public GameObject destination;
	
	private void OnTriggerEnter (Collider other)
	{
		if(other.transform.gameObject.transform.root.tag == "Player")
		{
			destination.GetComponent<BoxCollider>().enabled = false;
			other.transform.gameObject.transform.root.position = destination.transform.position + 3f * Vector3.forward - 45f * Vector3.up;
			other.transform.gameObject.transform.root.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, other.transform.gameObject.transform.root.GetComponent<Rigidbody>().velocity.z);
			other.transform.gameObject.transform.root.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, other.transform.gameObject.transform.root.GetComponent<Rigidbody>().angularVelocity.z);
		}
	}
	
	private void OnTriggerExit (Collider other)
	{
		Invoke("EnablePortal", 5f);
//		StartCoroutine(Delay()); //also can use invoke, although not the same
//		portalUsed = false;
//		Debug.Log("portalUsed = " + portalUsed);
	}
	
	private void EnablePortal ()
	{
		destination.GetComponent<BoxCollider>().enabled = true;
	}
}
