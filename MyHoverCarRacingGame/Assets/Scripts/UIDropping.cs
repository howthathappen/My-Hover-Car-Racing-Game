using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class UIDropping : MonoBehaviour, IDropHandler {

	public Material defaultCellMaterial;

	private GameObject objectBeingDroppedOn;
	private StorageCellInformation storageCellInformationScript;
	private GameObject puzzlePanel;
	private int numberOfPuzzlePiecesSolved;
	
	private void Awake ()
	{
		storageCellInformationScript = GameObject.FindGameObjectWithTag("StorageCellManager").GetComponent<StorageCellInformation>();
		puzzlePanel = GameObject.FindGameObjectWithTag("PuzzlePanel");
	}

	#region IDropHandler implementation

	public void OnDrop (PointerEventData eventData)
	{
		objectBeingDroppedOn = this.gameObject;
		Debug.Log("Tag = " + objectBeingDroppedOn.transform.tag);
		
		//dropping on the puzzle canvas start
		if(objectBeingDroppedOn.transform.tag == ("GreenPuzzlePiece") && objectBeingDroppedOn.GetComponent<Image>().color.a != 1f && eventData.pointerDrag.transform.GetComponent<Image>().color.g == 1f)
		{
			Color temp = objectBeingDroppedOn.GetComponent<Image>().color;
			temp.a = 1f; //0.3137254901960784f makes the alpha 80. uses zero to 1 instead of 0 to 255... lol just to make life interesting I guess
			objectBeingDroppedOn.GetComponent<Image>().color = temp;
			
			//storageCellInformationScript.storageCellList
			Color temp2 = eventData.pointerDrag.transform.GetComponent<Image>().color;
			temp2.a = 1f; //which should equal an alpha of 150;
			temp2.r = 0.4352941176470588f; //should all be a value of 111 with this
			temp2.g = 0.4352941176470588f;
			temp2.b = 0.4352941176470588f;
			eventData.pointerDrag.transform.GetComponent<Image>().color = temp2;
			
			//eventData.pointerDrag.AddComponent<DefaultMaterialTrue>();
			storageCellInformationScript.storageCellList[eventData.pointerDrag.transform.GetSiblingIndex()].AddComponent<DefaultMaterialTrue>();
			storageCellInformationScript.storageCellList[eventData.pointerDrag.transform.GetSiblingIndex()].GetComponent<MeshRenderer>().material = defaultCellMaterial;
		}
		
		if(objectBeingDroppedOn.transform.tag == ("RedPuzzlePiece") && objectBeingDroppedOn.GetComponent<Image>().color.a != 1f && eventData.pointerDrag.transform.GetComponent<Image>().color.r == 1f)
		{
			Color temp = objectBeingDroppedOn.GetComponent<Image>().color;
			temp.a = 1f; //0.3137254901960784f makes the alpha 80. uses zero to 1 instead of 0 to 255... lol just to make life interesting I guess
			objectBeingDroppedOn.GetComponent<Image>().color = temp;
			
			//storageCellInformationScript.storageCellList
			Color temp2 = eventData.pointerDrag.transform.GetComponent<Image>().color;
			temp2.a = 1f; //which should equal an alpha of 150;
			temp2.r = 0.4352941176470588f; //should all be a value of 111 with this
			temp2.g = 0.4352941176470588f;
			temp2.b = 0.4352941176470588f;
			eventData.pointerDrag.transform.GetComponent<Image>().color = temp2;
			
			storageCellInformationScript.storageCellList[eventData.pointerDrag.transform.GetSiblingIndex()].AddComponent<DefaultMaterialTrue>();
			storageCellInformationScript.storageCellList[eventData.pointerDrag.transform.GetSiblingIndex()].GetComponent<MeshRenderer>().material = defaultCellMaterial;
		}
		
		numberOfPuzzlePiecesSolved = 0;
		for(int i = 0; i < puzzlePanel.transform.childCount; i++)
		{
			if(puzzlePanel.transform.GetChild(i).GetComponent<Image>().color.a == 1f)
			{
				numberOfPuzzlePiecesSolved++;
			}
			else
			{
				break;
			}
		}
		if(numberOfPuzzlePiecesSolved == puzzlePanel.transform.childCount)
		{
			Debug.Log("puzzle is solved");
		}
		//dropping on the puzzle canvas end
		
		//ui color swapping
		if(objectBeingDroppedOn.tag == "UICellObject" && eventData.pointerDrag.tag == "UICellObject")
		{
			//swap the colors
			Color savedColor = objectBeingDroppedOn.GetComponent<Image>().color;
			objectBeingDroppedOn.GetComponent<Image>().color = eventData.pointerDrag.GetComponent<Image>().color;
			eventData.pointerDrag.GetComponent<Image>().color = savedColor;
			
			//swap the default material tags if applicable
			//objectBeingDroppedOn.transform.GetSiblingIndex();
			if(objectBeingDroppedOn.GetComponent<Image>().color.a == 1f) //if objectBeingDroppedOn has the default gray color
			{
				Debug.Log("entered");
				if(eventData.pointerDrag.GetComponent<Image>().color.a == 1f) //if they both have default gray color, do nothing
				{
					
				}
				else //else switch colors and default color tags
				{
					Destroy(storageCellInformationScript.storageCellList[eventData.pointerDrag.transform.GetSiblingIndex()].GetComponent<DefaultMaterialTrue>());
					Material saveMaterial = storageCellInformationScript.storageCellList[eventData.pointerDrag.transform.GetSiblingIndex()].GetComponent<MeshRenderer>().material;
					storageCellInformationScript.storageCellList[eventData.pointerDrag.transform.GetSiblingIndex()].GetComponent<MeshRenderer>().material = storageCellInformationScript.storageCellList[objectBeingDroppedOn.transform.GetSiblingIndex()].GetComponent<MeshRenderer>().material;
					
					storageCellInformationScript.storageCellList[objectBeingDroppedOn.transform.GetSiblingIndex()].AddComponent<DefaultMaterialTrue>();
					storageCellInformationScript.storageCellList[objectBeingDroppedOn.transform.GetSiblingIndex()].GetComponent<MeshRenderer>().material = saveMaterial;
				}
			}
			else if(eventData.pointerDrag.GetComponent<Image>().color.a == 1f) //if eventData.pointerDrag has the default gray color
			{
				Debug.Log("entered2");
				if(objectBeingDroppedOn.GetComponent<Image>().color.a == 1f) //if they both have the default gray color, do nothing
				{
					
				}
				else //else switch colors and default color tags
				{	
					Destroy(storageCellInformationScript.storageCellList[objectBeingDroppedOn.transform.GetSiblingIndex()].GetComponent<DefaultMaterialTrue>());
					Material saveMaterial = storageCellInformationScript.storageCellList[objectBeingDroppedOn.transform.GetSiblingIndex()].GetComponent<MeshRenderer>().material;
					storageCellInformationScript.storageCellList[objectBeingDroppedOn.transform.GetSiblingIndex()].GetComponent<MeshRenderer>().material = storageCellInformationScript.storageCellList[eventData.pointerDrag.transform.GetSiblingIndex()].GetComponent<MeshRenderer>().material;
						
					storageCellInformationScript.storageCellList[eventData.pointerDrag.transform.GetSiblingIndex()].AddComponent<DefaultMaterialTrue>();
					storageCellInformationScript.storageCellList[eventData.pointerDrag.transform.GetSiblingIndex()].GetComponent<MeshRenderer>().material = saveMaterial;
				}
			}
			else //if neither of them are the default gray color, just swap colors
			{
				Material saveMaterial = storageCellInformationScript.storageCellList[objectBeingDroppedOn.transform.GetSiblingIndex()].GetComponent<MeshRenderer>().material;
				storageCellInformationScript.storageCellList[objectBeingDroppedOn.transform.GetSiblingIndex()].GetComponent<MeshRenderer>().material = storageCellInformationScript.storageCellList[eventData.pointerDrag.transform.GetSiblingIndex()].GetComponent<MeshRenderer>().material;
				
				storageCellInformationScript.storageCellList[eventData.pointerDrag.transform.GetSiblingIndex()].GetComponent<MeshRenderer>().material = saveMaterial;
			}
			
		}
	}

	#endregion
}
