using UnityEngine;
using System.Collections;

public class flipCard : MonoBehaviour {

	public bool hasFlipped = false;
	public bool isFlipping = false;
	public bool activeAtStart = false;
	public GameObject nextCard = null;

	// Use this for initialization
	void Start () {
		gameObject.SetActive(activeAtStart);
	}
	
	// Update is called once per frame
	void Update () {
		if (isFlipping) {
			transform.Rotate(Time.deltaTime*100, 0, 0);
		}
	}


	void OnMouseDown() {
		Flip();
	}


	void Flip() {
		if (nextCard != null) {
			nextCard.SetActive(true);
			audio.Stop();
			nextCard.audio.Play();
		}
		if (!hasFlipped) {
			isFlipping = true;
		}
	}


}
