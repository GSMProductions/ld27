using UnityEngine;
using System.Collections;

public class LDInputControler : MonoBehaviour {

	public GameObject global;
	private CharacterMotor motor;

	void Start () 
		{
		motor = GetComponent<CharacterMotor>();
		}

	
	// Update is called once per frame
	void Update () {

		if(global.GetComponent<clock>().who == clock.turn.player)
			{
			if(GetComponent<inventoryControl>().guiInventory.guiTexture.enabled)
				motor.canControl = false;
			else
				motor.canControl = true;
			}
		else
			{
			motor.canControl = false;
			}
		}
}


