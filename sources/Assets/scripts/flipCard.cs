using UnityEngine;
using System.Collections;

public class flipCard : MonoBehaviour {

	public bool hasFlipped = false;
	public bool isFlipping = false;
	public bool activeAtStart = false;
	public GameObject nextCard = null;
	public introCamera camScript = null;
	public AudioSource pageturn = null;

	// Use this for initialization
	void Start () {
		gameObject.SetActive(activeAtStart);
	}
	
	// Update is called once per frame
	void Update () {
		if (isFlipping) {
			transform.Rotate(Time.deltaTime*100, 0, 0);
			if (transform.eulerAngles.x < 300 && transform.eulerAngles.x > 0 ) {
				hasFlipped = true;
				isFlipping = false;
				if (nextCard != null) {
					nextCard.audio.Play();
				}
				gameObject.SetActive(false);
				if (camScript != null) {
					camScript.moving = true;
				}
			}


		}
	}


	void OnMouseDown() {
		Flip();
	}


	void Flip() {
		if (pageturn) {
			pageturn.Play();
		}
		audio.Stop();
		if (nextCard != null) {
			nextCard.SetActive(true);
		}
		if (!hasFlipped) {
			isFlipping = true;
		}
	}


}
