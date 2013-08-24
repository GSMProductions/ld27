using UnityEngine;
using System.Collections;

public class navMonster : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
		{
		float dt = Time.deltaTime;
		GetComponent<NavMeshAgent>().destination= target.transform.position;
		}
}
