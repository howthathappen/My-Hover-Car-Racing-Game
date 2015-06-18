using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class UIDraggingAndDropping : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public GameObject uiSidePanel;
	public GameObject objectBeingDragged;
	public UIManager uiManagerScript;
	
	private GameObject puzzleCanvas;
	private GameObject objectBeingDroppedOn;
	private bool beginDragObjectSet = false;
	//private float leftSideOfUIPanel;
	
	private void Awake ()
	{
		uiSidePanel = GameObject.FindGameObjectWithTag("UISidePanel");
		uiManagerScript = GameObject.FindGameObjectWithTag("StorageCellManager").GetComponent<UIManager>();
		puzzleCanvas = uiManagerScript.puzzleCanvasGameObject;
		//leftSideOfUIPanel = uiSidePanel.GetComponent<RectTransform>().rect.xMin;
	}

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		if(beginDragObjectSet == false)
		{
			objectBeingDragged = this.gameObject;
			Debug.Log("objectBeingDragged " + objectBeingDragged);
			beginDragObjectSet = true;
		}
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		if(!Input.GetMouseButtonDown(0))
		{
			objectBeingDragged = null;
			beginDragObjectSet = false;
			//Debug.Log("object set to null");
		}
	}

	#endregion
	
	private void Update ()
	{
		if(objectBeingDragged && Input.mousePosition.x < (Screen.width - uiSidePanel.GetComponent<RectTransform>().rect.width))
		{
			puzzleCanvas.SetActive(true);
		}
		else if((uiManagerScript.playerOpenedPuzzleCanvas == false && Input.mousePosition.x > (Screen.width - uiSidePanel.GetComponent<RectTransform>().rect.width)) || (Input.GetMouseButtonUp(0) && uiManagerScript.playerOpenedPuzzleCanvas == false))
		{
			puzzleCanvas.SetActive(false);
		}
		//Debug.Log(2f*uiSidePanel.GetComponent<RectTransform>().rect.xMin);
		//Debug.Log("Width " + uiSidePanel.GetComponent<RectTransform>().rect.width);
		//Debug.Log(objectBeingDragged);
	}
	
//	#region IDropHandler implementation
//	
//	public void OnDrop (PointerEventData eventData)
//	{
//		objectBeingDroppedOn = this.gameObject;
//		Debug.Log("objectBeingDroppedOn " + objectBeingDroppedOn.gameObject.tag);
//		
////		if(objectBeingDroppedOn.gameObject.tag == ("GreenPuzzlePiece") && objectBeingDroppedOn.GetComponent<Image>().color.a != 1f && objectBeingDragged.gameObject.tag == "UICellObject" && objectBeingDragged.GetComponent<Image>().color.g == 255)
////		{
////			Debug.Log("entered if statement");
////			Color temp = objectBeingDroppedOn.GetComponent<Image>().color;
////			temp.a = 1f; //0.3137254901960784f makes the alpha 80. uses zero to 1 instead of 0 to 255... lol just to make life interesting I guess
////			objectBeingDroppedOn.GetComponent<Image>().color = temp;
////		}
////		else if(objectBeingDroppedOn.gameObject.tag == ("RedPuzzlePiece") && objectBeingDroppedOn.GetComponent<Image>().color.a != 1f && objectBeingDragged.gameObject.tag == "UICellObject" && objectBeingDragged.GetComponent<Image>().color.r == 255)
////		{
////			Debug.Log("entered else statemenet");
////			Color temp = objectBeingDroppedOn.GetComponent<Image>().color;
////			temp.a = 1f; //0.3137254901960784f makes the alpha 80. uses zero to 1 instead of 0 to 255... lol just to make life interesting I guess
////			objectBeingDroppedOn.GetComponent<Image>().color = temp;
////		}
//		Debug.Log("objectBeingDragged " + objectBeingDragged);
//		Color temp = objectBeingDroppedOn.GetComponent<Image>().color;
//		temp.a = 1f; //0.3137254901960784f makes the alpha 80. uses zero to 1 instead of 0 to 255... lol just to make life interesting I guess
//		objectBeingDroppedOn.GetComponent<Image>().color = temp;
//	}
//	
//	#endregion
}
