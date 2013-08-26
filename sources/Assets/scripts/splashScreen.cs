using UnityEngine;
using System.Collections;

public class splashScreen : MonoBehaviour {

	public float timer = 2f;
	public string levelToLoad = "Level";

	// Use this for initialization
	void Start () {
		StartCoroutine("DisplayScene");
	}
	

	IEnumerator DisplayScene() {
		yield return new WaitForSeconds(timer);
		//Application.LoadLevel(levelToLoad);
		CameraFade.StartAlphaFade( Color.black, false, 2f, 2f, () => { Application.LoadLevel(levelToLoad); } );
	}

	// Update is called once per frame
	void Update () {
	
	}
}
