using UnityEngine;
using System.Collections;

public class clockGui : MonoBehaviour {

	public float fps=9.0f;

	public GameObject global;
	public Texture2D[] frames;
	public Texture2D[] framesMonster;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		float time;
		int i_time;

		time = global.GetComponent<clock>().getTime();
		i_time = (int)(time*fps);
		
		Texture2D tex;
		if(global.GetComponent<clock>().who == clock.turn.enemy)
			tex = framesMonster[i_time];
		else
			tex = frames[i_time];

		GameObject.Find(this.name).GetComponent<GUITexture>().texture =  tex;
	}
}
