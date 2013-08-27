using UnityEngine;
using System.Collections;

public class reset : MonoBehaviour {

	public float time = 30f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;

		if(time <= 0f||Input.GetKeyDown(KeyCode.Space))
			{
			CameraFade.StartAlphaFade( Color.black, false, 2f, 2f, () => { Application.LoadLevel("MainMenu"); } );
			}
	}
}
