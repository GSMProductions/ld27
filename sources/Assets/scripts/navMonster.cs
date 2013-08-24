using UnityEngine;
using System.Collections;

public class navMonster : MonoBehaviour {

	public GameObject target;
	public GameObject global;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
		{

		if(global.GetComponent<clock>().who == clock.turn.enemy)
			{
			GetComponent<NavMeshAgent>().destination= target.transform.position;
			GetComponent<NavMeshAgent>().Resume();
			}
		else
			{
			GetComponent<NavMeshAgent>().Stop();
			}
		
		}
}
