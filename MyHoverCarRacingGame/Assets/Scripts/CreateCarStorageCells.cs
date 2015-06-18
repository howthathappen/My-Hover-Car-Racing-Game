using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateCarStorageCells : MonoBehaviour {

	public GameObject storageCellPrefab;
	public GameObject defaultUICellPrefab;

	private StorageCellInformation storageCellInformationScript;
	private GameObject newStorageCell;
	private GameObject newUICell;
	private Vector3 carPosition;
	private Vector3 carScale;
	private Vector3 cellScale;

	void Awake ()
	{
		storageCellInformationScript = transform.GetComponent<StorageCellInformation>();
		carPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
		carScale = GameObject.FindGameObjectWithTag("Player").transform.localScale;
		Vector3 tempCarScale = carScale;
		tempCarScale.z *= (float)(1f / (float)storageCellInformationScript.interiorCellCount); //scale our z so we can fit all of the cells inside the car
		cellScale = tempCarScale;
		
		for(int i = 0; i < storageCellInformationScript.interiorCellCount; i++)
		{
			newStorageCell = Instantiate(storageCellPrefab, carPosition, Quaternion.identity) as GameObject;
			newStorageCell.transform.localScale = cellScale;
			Debug.Log(cellScale);
			newStorageCell.transform.localPosition += new Vector3(0, 0, cellScale.z * i - (carScale.z/2 - cellScale.z/2));
			newStorageCell.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
			storageCellInformationScript.storageCellList.Add(newStorageCell);
			newStorageCell.AddComponent<DefaultMaterialTrue>(); //add this script to any cell with a default material
			Debug.Log("called");
			
			newUICell = Instantiate(defaultUICellPrefab, Vector3.zero, Quaternion.identity) as GameObject; //create a ui element
			newUICell.transform.SetParent(GameObject.FindGameObjectWithTag("UISidePanel").transform, false); //recommended on the unity API to use SetParent and set the WorldPositionStays value to false
			newUICell.GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, 11f+(-22f*storageCellInformationScript.interiorCellCount*0.5f));//set the srart position for the ui elements
			newUICell.GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, 22f*i); //move each ui element based on the order it was created in
			storageCellInformationScript.uiStorageCellList.Add(newUICell);
		}
	}
}
