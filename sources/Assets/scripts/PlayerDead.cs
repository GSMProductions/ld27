using UnityEngine;
using System.Collections;

public class PlayerDead : MonoBehaviour {

	public bool isDead = false;
	public bool godMode = false;
	// Use this for initialization
	void Start () {
	
	}
	
	public void kill()
		{
		if(godMode== false)
			isDead = true;
		}
	// Update is called once per frame
	void Update () {
	
		if(isDead)
			{
			Debug.Log("Player Dead!");
			}

	}
}
