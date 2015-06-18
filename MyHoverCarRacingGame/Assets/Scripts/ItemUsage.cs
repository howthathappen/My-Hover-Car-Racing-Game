using UnityEngine;
using System.Collections;

public class ItemUsage : MonoBehaviour {

	public GameObject teleporterPrefab;

	private GameObject teleporterGameObject;
	private Vector3 carPosition;
	private Vector3 teleporterPosition;
	private bool playerHasTeleportItem;
	private bool teleporterDropped;
	
	private void Update ()
	{
		if(Input.GetKeyDown(KeyCode.E) && !teleporterDropped)
		{
			carPosition = transform.position;
			RaycastHit hit;
			if(Physics.Raycast(carPosition, -Vector3.up, out hit, 100000f))
			{
				teleporterGameObject = Instantiate(teleporterPrefab, hit.point + new Vector3(0f, .51f, 0f), Quaternion.Euler(-90f, 0f, 0f)) as GameObject;
			}
			teleporterPosition = teleporterGameObject.transform.position;
			teleporterDropped = true;
		}
		else if(Input.GetKeyDown(KeyCode.E) && teleporterDropped)
		{
			this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, this.gameObject.GetComponent<Rigidbody>().velocity.z);//Vector3.zero;
			this.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, this.gameObject.GetComponent<Rigidbody>().angularVelocity.z);//Vector3.zero;
			Physics.gravity = new Vector3(0f, -50f, 0f); //just to be safe
			transform.position = (teleporterPosition + new Vector3(0f, 3f, 0f));
			Destroy(GameObject.FindWithTag("Teleporter"));
			teleporterDropped = false;
		}
	}
}
