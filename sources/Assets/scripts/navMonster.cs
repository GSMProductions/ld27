using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class navMonster : MonoBehaviour {

	public GameObject target;
	public GameObject global;
	// Use this for initialization

	private List<Vector3> targets = new List<Vector3>();
	private bool trackPlayer = false;

	private int index=-1;
	

	
	void Start () 
		{

        foreach (GameObject target in GameObject.FindGameObjectsWithTag("monsterPoint")) 
        	{
            targets.Add(target.transform.position);
			}
			chooseTarget();
		}
	
	// Update is called once per frame
	void Update () 
		{
		if(global.GetComponent<clock>().who == clock.turn.enemy)
			{
			GetComponent<NavMeshAgent>().Resume();
			if(trackPlayer)
				{
				GetComponent<NavMeshAgent>().destination= target.transform.position;
				}
			else
				{
				if(GetComponent<NavMeshAgent>().remainingDistance <= GetComponent<NavMeshAgent>().stoppingDistance)
					{
					    chooseTarget();
					}
				}
			}
		else
			{
			GetComponent<NavMeshAgent>().Stop();
			}
	
		}

	private void chooseTarget()
		{
		
		int newindex = Random.Range(0,targets.Count);
		while(newindex==index)
			newindex = Random.Range(0,targets.Count);

		index = newindex;
		GetComponent<NavMeshAgent>().destination= targets[index];
		}
}
