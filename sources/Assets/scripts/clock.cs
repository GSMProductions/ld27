using UnityEngine;
using System.Collections;

public class clock : MonoBehaviour {

	public  float time = 10f;

	private float timer = 0.0f;
	public enum turn
		{
		enemy,
		player
		}

	public turn who = turn.enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float dt = Time.deltaTime;
		timer += dt;

		if (timer >= time)
			{
			timer = 0f;
			switchTurn();
			}
	}

	private void switchTurn()
		{
		if(who == turn.enemy)
			who = turn.player;
		else
			who = turn.enemy;
		}

	public float getTime()
		{
		return timer;
		}
}
