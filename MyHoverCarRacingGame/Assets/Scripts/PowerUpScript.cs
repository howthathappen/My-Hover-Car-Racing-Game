using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerUpScript : MonoBehaviour {
	
	public Material powerUpMaterial;
	public Material greenPowerUpMaterial;
	public Material redPowerUpMaterial;
	
	private ScoreManager scoreManagerScript;
	private StorageCellInformation storageCellInformationScript;
	
	private void Awake ()
	{
		scoreManagerScript = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
		storageCellInformationScript = GameObject.FindGameObjectWithTag("StorageCellManager").GetComponent<StorageCellInformation>();
	}
	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.transform.root.tag == "Player")
		{
			Debug.Log("Hit Player");
			Destroy(this.gameObject);
			
			//other.gameObject.GetComponent<MeshRenderer>().material.color = Color.green; //destroy the green cube power-up and change the color of our player accordingly
			scoreManagerScript.greenCubesCollected += 1; //add 1 to the number of cubes we have collected
			
			for(int i = 0; i < storageCellInformationScript.storageCellList.Count; i++)
			{
				if(storageCellInformationScript.storageCellList[i].GetComponent<DefaultMaterialTrue>())
				{
					storageCellInformationScript.storageCellList[i].GetComponent<MeshRenderer>().material = powerUpMaterial;
					Debug.Log("set");
					Destroy(storageCellInformationScript.storageCellList[i].GetComponent<DefaultMaterialTrue>()); //remove the default material script since it no longer has a default material
					
					if(powerUpMaterial == greenPowerUpMaterial)
					{
						Color temp = storageCellInformationScript.uiStorageCellList[i].GetComponent<Image>().color;
						temp.a = 0.5882352941176471f; //which should equal an alpha of 150;
						temp.r = 0f;
						temp.g = 1f;
						temp.b = 0f;
						storageCellInformationScript.uiStorageCellList[i].GetComponent<Image>().color = temp;
					}
					else if(powerUpMaterial == redPowerUpMaterial)
					{
						Color temp = storageCellInformationScript.uiStorageCellList[i].GetComponent<Image>().color;
						temp.a = 0.5882352941176471f; //which should equal an alpha of 150;
						temp.r = 1f;
						temp.g = 0f;
						temp.b = 0f;
						storageCellInformationScript.uiStorageCellList[i].GetComponent<Image>().color = temp;
					}
					else
					{
						Color temp = storageCellInformationScript.uiStorageCellList[i].GetComponent<Image>().color;
						temp.a = 1f; //which should equal an alpha of 150;
						temp.r = 0.4352941176470588f; //should all be a value of 111 with this
						temp.g = 0.4352941176470588f;
						temp.b = 0.4352941176470588f;
						storageCellInformationScript.uiStorageCellList[i].GetComponent<Image>().color = temp;
					}
					return; //once we find the next storage cell that still has the default material, change it and exit the for loop
				}
				Debug.Log("not set");
			}
		}
	}
}
