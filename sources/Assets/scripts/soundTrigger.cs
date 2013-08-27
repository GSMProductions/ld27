using UnityEngine;
using System.Collections;



public class soundTrigger : MonoBehaviour {
	
	public startingCutscene cutscene;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "audio") {
			Destroy(other.gameObject);
			cutscene.playNext();
		}

	}

}
