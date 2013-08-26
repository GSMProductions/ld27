using UnityEngine;
using System.Collections;

public class monsterAnimation : MonoBehaviour {


	protected Animator animator;
	public clock globals;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (animator) {
			if (globals.who == clock.turn.enemy) {
				animator.SetFloat("Speed", 2f);
			}
			else {
				animator.SetFloat("Speed",0f);
			}
		}

	}
}
