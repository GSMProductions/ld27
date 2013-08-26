using UnityEngine;
using System.Collections;

public class introCamera : MonoBehaviour {

	public bool moving = false;
	public flicker lightScript = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(moving) {
			transform.Translate(0f,0f,-0.3f*Time.deltaTime,Space.Self);
			if (transform.position[1] > 1.4) {
				lightScript.flickering = true;
				audio.Play();
			}
			if (transform.position[1] > 1.55) {
				audio.Stop();
				lightScript.flickering = false;
				lightScript.TurnOff();
				moving = false;
			}
		}
	}
}
