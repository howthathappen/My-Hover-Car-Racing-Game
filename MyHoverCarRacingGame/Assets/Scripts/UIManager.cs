using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	//public Canvas puzzleCanvas;
	public GameObject puzzleCanvasGameObject;
	public bool playerOpenedPuzzleCanvas;
	
	private void Awake ()
	{
		puzzleCanvasGameObject.SetActive(false);
	}
	
	private void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			//if(puzzleCanvas.enabled == false)
			if(puzzleCanvasGameObject.activeInHierarchy == false) //checks if the GameObject is active in the scene. GameObject.activeSelf can be confusing since the GameObject may be inactive because a parent is not active, even if activeSelf returns true.
			{
				//puzzleCanvas.enabled = true;
				puzzleCanvasGameObject.SetActive(true);
				playerOpenedPuzzleCanvas = true;
			}
			else
			{
				//puzzleCanvas.enabled = false;
				puzzleCanvasGameObject.SetActive(false);
				playerOpenedPuzzleCanvas = false;
			}
		}
	}
}
