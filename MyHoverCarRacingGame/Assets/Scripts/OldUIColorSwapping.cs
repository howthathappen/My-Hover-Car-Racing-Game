using UnityEngine;
using System.Collections;

public class OldUIColorSwapping : MonoBehaviour {

	public Camera UICamera;
	public Canvas puzzleCanvas;
	public RaycastHit hit;
	
	private RaycastHit hit2;
	private Material hit2Material;
	//private GameObject selectedStorageCell;
	//private StorageCellInformation storageCellInformationScript;
	private bool playerOpenedPuzzleMenu = false;
	
	private void Awake ()
	{
		//storageCellInformationScript = GameObject.FindGameObjectWithTag("StorageCellManager").transform.GetComponent<StorageCellInformation>();
	}
	
	private void Update ()
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(Physics.Raycast(UICamera.ScreenPointToRay(Input.mousePosition), out hit, 100f))
			{
				//unnecessary code
//				if(hit.collider.gameObject.tag == "CarStorageCell")
//				{
//					selectedStorageCell = hit.collider.gameObject;
//					Debug.Log(selectedStorageCell);
//				}
//				Debug.Log(hit.collider.tag);
			}
		}
		
		if(Input.GetMouseButtonUp(0))
		{
			if(Physics.Raycast(UICamera.ScreenPointToRay(Input.mousePosition), out hit2, 100f))
			{
				if(hit2.collider.gameObject != hit.collider.gameObject && hit2.collider.gameObject.tag == ("CarStorageCell") && hit.collider.gameObject.tag == ("CarStorageCell"))
				{
					//swap materials
					hit2Material = hit2.collider.gameObject.GetComponent<MeshRenderer>().material;
					hit2.collider.gameObject.GetComponent<MeshRenderer>().material = hit.collider.gameObject.GetComponent<MeshRenderer>().material;
					hit.collider.gameObject.GetComponent<MeshRenderer>().material = hit2Material;
					
					//make sure we still know which cells have the default material now that we have swapped materials
					if(hit.collider.gameObject.GetComponent<DefaultMaterialTrue>() && !hit2.collider.gameObject.GetComponent<DefaultMaterialTrue>())
					{
						Destroy(hit.collider.gameObject.GetComponent<DefaultMaterialTrue>());
						hit2.collider.gameObject.AddComponent<DefaultMaterialTrue>();
					}
					else if(!hit.collider.gameObject.GetComponent<DefaultMaterialTrue>() && hit2.collider.gameObject.GetComponent<DefaultMaterialTrue>())
					{
						Destroy(hit2.collider.gameObject.GetComponent<DefaultMaterialTrue>());
						hit.collider.gameObject.AddComponent<DefaultMaterialTrue>();
					}
				}
			}
		}
		
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			if(puzzleCanvas.enabled == false)
			{
				puzzleCanvas.enabled = true;
				playerOpenedPuzzleMenu = true;
			}
			else
			{
				puzzleCanvas.enabled = false;
				playerOpenedPuzzleMenu = false;
			}
		}
		//Debug.Log(UICamera.pixelRect);
		//Debug.Log(Input.mousePosition);
		
		if(Input.GetMouseButton(0) && hit.collider.gameObject.tag == ("CarStorageCell") && Input.mousePosition.x <= UICamera.pixelRect.x)
		{
			puzzleCanvas.enabled = true;
		}
		else if(!playerOpenedPuzzleMenu)
		{
			puzzleCanvas.enabled = false;
		}
		//Debug.Log(Input.GetMouseButton(0));
		//Debug.Log(hit.collider.gameObject.tag);
	}
}