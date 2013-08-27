using UnityEngine;
using System.Collections;

public class outro : MonoBehaviour {
	float timeSinceStart;

	// Use this for initialization
	void Start () {
		timeSinceStart = 0f;
		CameraFade.StartAlphaFade(Color.black, true, 3f, 17f, () => { } );
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceStart += Time.deltaTime;

		if (timeSinceStart > 28f) {
			Application.LoadLevel("MainMenu");
		}

	}
}
