using UnityEngine;
using System.Collections;

public class action : MonoBehaviour {

	public enum type {pickup,recorder,door}
	public type actionType;

	public string record_text;
	public float recorder_time;

	public string pickup_name;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void play()
		{
		switch(actionType)
			{
			case type.pickup:
				pickup_action();
				break;

			case type.recorder:
				recorder_action();
				break;

			case type.door:
				door_action();
				break;
			}
		}

	private void pickup_action()
		{
		GameObject.Find("First Person Controller").GetComponent<inventoryControl>().add(pickup_name);
		Destroy(gameObject);
		
		}


	private void recorder_action()
		{
		
		}


	private void door_action()
		{
		GetComponent<doorOpen>().open();
		}
}
