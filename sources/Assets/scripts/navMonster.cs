using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class navMonster : MonoBehaviour {

	public GameObject target;
	public GameObject global;
	// Use this for initialization

	private List<Vector3> targets = new List<Vector3>();
	private int index=-1;
	
	public float searchRadius = 10f;

	private int nSearch = 3;

	private enum state
		{
		hunting,
		warning,
		walking
		}

	private state status = state.walking;
	
	void Start () 
		{

        foreach (GameObject target in GameObject.FindGameObjectsWithTag("monsterPoint")) 
        	{
            targets.Add(target.transform.position);
			}
			chooseTarget();
		}
	
	// Update is called once per frame
	void Update() 
		{
		
		switch(status)
			{
			
			case state.walking :

				if(playerInFieldVision())
					{
					GetComponent<NavMeshAgent>().destination= target.transform.position;
					status = state.hunting;
					}	
				else
					{
					if(GetComponent<NavMeshAgent>().remainingDistance <= GetComponent<NavMeshAgent>().stoppingDistance)
						{
					    chooseTarget();
						}
					}
				break;
			case state.hunting:

				if(playerInFieldVision())
					{
					GetComponent<NavMeshAgent>().destination= target.transform.position;
					}
				else
					{
					status = state.warning;
					}
				break;

			case state.warning :

				if(playerInFieldVision())
					{
					GetComponent<NavMeshAgent>().destination= target.transform.position;
					status = state.hunting;
					}	
				else
					{
					if(GetComponent<NavMeshAgent>().remainingDistance <= GetComponent<NavMeshAgent>().stoppingDistance)
						{
						if(nSearch > 0)
							{
							GetComponent<NavMeshAgent>().destination =  getRandomPoint(transform.position,searchRadius);
							nSearch-=1;
							}
						else
							{
					    	status = state.walking;
					    	}
						}
					}
				break;
			}

			if(global.GetComponent<clock>().who == clock.turn.enemy)
				{
				GetComponent<NavMeshAgent>().Resume();
				}
			else
				{
				GetComponent<NavMeshAgent>().Stop();
				}
			
		}

	private Vector3 getRandomPoint(Vector3 origin, float reach)
		{
		float dx = Random.Range(-reach,reach);
		float dy = Random.Range(-reach,reach);

		origin.x += dx;
		origin.y += dy;

		return origin;
		}

	private void chooseTarget()
		{
		
		int newindex = Random.Range(0,targets.Count);
		while(newindex==index)
			newindex = Random.Range(0,targets.Count);

		index = newindex;
		GetComponent<NavMeshAgent>().destination= targets[index];
		}

	private bool playerInFieldVision()
		{
		Vector3 direction = transform.forward;

		Vector3 targetPosition = target.transform.position;
		Vector3 vectorTarget = new Vector3(targetPosition.x-transform.position.x, targetPosition.y-transform.position.y, targetPosition.z-transform.position.z);


		float scalarProduct = direction.x * vectorTarget.x +  direction.y * vectorTarget.y +  direction.z * vectorTarget.z;

		if (scalarProduct < 0f)
			{
			return false;
			}

		Ray ray = new Ray(transform.position,transform.forward);
		RaycastHit hit;

		Color color = Color.clear;

		if (Physics.Raycast(transform.position,vectorTarget.normalized, out hit))
			{
			color = Color.green;
			if (hit.collider==target.collider)
				{
				color = Color.blue;
				float radius = searchRadius;
				if(status != state.walking)
					{
					radius *= 1.5f;
					}

				if(hit.distance <= radius)
					{
					color = Color.red;
					return true;
					}
				}

	   	 	Debug.DrawLine(ray.origin, hit.transform.position,color);
	   	 	}
		return false;
		}
}
