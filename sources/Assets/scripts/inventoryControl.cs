using UnityEngine;
using System.Collections;

public class inventoryControl : MonoBehaviour 
	{

	// Use this for initialization
	void Start () {
		guiTexture.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		 Debug.Log("enabled --> " + guiTexture.enabled);
		if(guiTexture.enabled)
			{
 		
			if (Input.GetKeyDown(KeyCode.E)||Input.GetKeyDown(KeyCode.Escape)) 
				{
			    // hide
			   Debug.Log("False");
			   guiTexture.enabled = false;
				}
			}
		else
			{
			if (Input.GetKeyDown(KeyCode.E)) 
				{
    			Debug.Log("True");
    			guiTexture.enabled = true;
				}
			}
		}
		
	}

