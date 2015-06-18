using UnityEngine;
using System.Collections;

public class IgnoreLighting : MonoBehaviour {

	public Light directionalLight; //this variable is the light you want to ignore

	private void OnPreCull () 
	{
		if (directionalLight != null)
		{
			directionalLight.enabled = false;
		}
	}
	
	private void OnPreRender() 
	{
		if (directionalLight != null)
		{
			directionalLight.enabled = false;
		}
	}
	
	private void OnPostRender() {
		if (directionalLight != null)
		{
			directionalLight.enabled = true;
		}
	}
}
