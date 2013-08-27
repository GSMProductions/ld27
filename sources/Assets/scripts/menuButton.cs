using UnityEngine;
using System.Collections;

public class menuButton : MonoBehaviour {

	Rect rectPlay, rectQuit, rectCredits, rectCommands;

	public enum menuStates {Main, Credits, Commands};
	public menuStates currentState = menuStates.Main;
	public GUITexture mainTex, creditsTex, commandsTex;

	// Use this for initialization
	void Start () {
		rectPlay = new Rect(0.1f,0.4f,0.1f,0.16f);
		rectQuit = new Rect(0.8f,0.7f,0.2f,0.3f);
		rectCredits = new Rect(0.6f,0.3f,0.3f,0.5f);
		rectCommands = new Rect(0.3f,0.7f,0.6f,0.8f);

		mainTex.enabled = true;
		creditsTex.enabled = false;
		commandsTex.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnGUI() {

		Vector2 mousepos = new Vector2(Event.current.mousePosition[0]/Screen.width, Event.current.mousePosition[1]/Screen.height );
		//Debug.Log(mousepos);
		if (currentState == menuStates.Main) {
			if (Input.GetMouseButtonDown(0) && rectPlay.Contains(mousepos)) {
				Application.LoadLevel ("floor1");
			} else if (Input.GetMouseButtonDown(0) && rectQuit.Contains(mousepos)) {
				Application.Quit();			
			} else if (Input.GetMouseButtonDown(0) && rectCredits.Contains(mousepos)) {
				mainTex.enabled = false;
				creditsTex.enabled = true;
				currentState = menuStates.Credits;
			} else if (Input.GetMouseButtonDown(0) && rectCommands.Contains(mousepos)) {
				mainTex.enabled = false;
				commandsTex.enabled = true;
				currentState = menuStates.Commands;
			}
		} else if (currentState == menuStates.Credits) {
			if (Input.GetMouseButtonDown(0) && rectQuit.Contains(mousepos)) {
				currentState = menuStates.Main;

				mainTex.enabled = true;
				creditsTex.enabled = false;
			}
		} else if (currentState == menuStates.Commands) {
			if (Input.GetMouseButtonDown(0) && rectQuit.Contains(mousepos)) {
				currentState = menuStates.Main;
				mainTex.enabled = true;
				commandsTex.enabled = false;
			}
		}




	}

}
