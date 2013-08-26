using UnityEngine;
using System.Collections;

public class doorOpenable : MonoBehaviour {

	public bool unlocked = true;
	public enum doorStates {Closed, Closing, Open, Opening};
	public doorStates currentState = doorStates.Opening;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (currentState == doorStates.Opening) {
			transform.Rotate(0,0,Time.deltaTime*50);
		}
	
	}
}
