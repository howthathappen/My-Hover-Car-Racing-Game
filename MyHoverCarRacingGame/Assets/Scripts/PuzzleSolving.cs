using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class PuzzleSolving : MonoBehaviour, IEndDragHandler {

	public Material greenPowerUpMaterial;
	public Material redPowerUpMaterial;
	
	private GameObject uiCamera;
	
	private void Awake ()
	{
		uiCamera = GameObject.FindGameObjectWithTag("UICamera");
	}

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		Debug.Log("OnEndDrag Called");
		if(uiCamera.GetComponent<OldUIColorSwapping>().hit.collider.gameObject.tag == ("CarStorageCell") && this.gameObject.GetComponent<Image>().color.a == 80 && this.gameObject.GetComponent<Image>().color.r == 255 && uiCamera.GetComponent<OldUIColorSwapping>().hit.collider.gameObject.GetComponent<MeshRenderer>().material == redPowerUpMaterial)
		{
			Color temp = this.gameObject.GetComponent<Image>().color;
			temp.a = 255; 
			this.gameObject.GetComponent<Image>().color = temp;
		}
		else if(uiCamera.GetComponent<OldUIColorSwapping>().hit.collider.gameObject.tag == ("CarStorageCell") && this.gameObject.GetComponent<Image>().color.a == 80 && this.gameObject.GetComponent<Image>().color.g == 255 && uiCamera.GetComponent<OldUIColorSwapping>().hit.collider.gameObject.GetComponent<MeshRenderer>().material == greenPowerUpMaterial)
		{
			Color temp = this.gameObject.GetComponent<Image>().color;
			temp.a = 255; 
			this.gameObject.GetComponent<Image>().color = temp;
		}
	}

	#endregion
}