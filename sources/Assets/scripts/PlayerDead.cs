using UnityEngine;
using System.Collections;

public class PlayerDead : MonoBehaviour {

	public bool isDead = false;
	public bool godMode = false;

	public float time = 2f;
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
			time -= Time.deltaTime;
			transform.Rotate(Time.deltaTime*30,0f,0f);
			}
			if(time <= 0f)
				{
				Application.LoadLevel("gameover");
				//CameraFade.StartAlphaFade( Color.black, false, 1f, 1f, () => { Application.LoadLevel("gameover"); } );
				}
	}
}
