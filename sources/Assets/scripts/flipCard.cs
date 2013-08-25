using UnityEngine;
using System.Collections;

public class flipCard : MonoBehaviour {

	public bool hasFlipped = false;
	public bool isFlipping = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	// Update is called once per frame
	void Update () {
		
		if (isFlipping) {
			transform.Rotate(Time.deltaTime*100, 0, 0);
		}
	}

	void Flip() {
		if (!hasFlipped) {
			isFlipping = true;
		}
	}


}
