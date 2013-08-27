using UnityEngine;
using System.Collections;

public class doorOpen : MonoBehaviour {

	public float rot;
	public float speed;

	public bool unlockable = true;
	public bool locked = false;
	private bool opened = false;
	public string keyName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(unlockable)
			if(opened)
				{
				if(transform.eulerAngles.y < rot)
					{
					transform.Rotate(0f,0f,Time.deltaTime*speed);
					}
				}
	}

	public void open()
		{
		if(unlockable)
			{
			if(locked)
				{
				if(GameObject.Find("First Person Controller").GetComponent<inventoryControl>().isInInventory(keyName))
					{
					locked = false;
					opened = true;
					}
				else
					{
					GameObject.Find("subtitle GUI").GetComponent<subtitles>().display("porte_fermee_clef",3f);
					}
				}
			else
				if(opened==false)
					{
					opened = true;
					}
			}
		else
			{

			}
		}
}
