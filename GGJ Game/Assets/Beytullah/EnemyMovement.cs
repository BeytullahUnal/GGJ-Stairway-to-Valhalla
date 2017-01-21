﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour {

	NavMeshAgent enemyAgent;

	GameObject[] destinations;
	Vector3 patrolDst;

	int itemCount;
	int index;


	public bool isOnTarget = false;
	GameObject targetPlayer;

	public GameObject Player;
	bool isStunned = false;


	void Start () {
		enemyAgent = GetComponent<NavMeshAgent> ();
		destinations = GameObject.FindGameObjectsWithTag ("Destination");
		itemCount = destinations.Length;

		Debug.Log ("Assigning Initial Destination");
		index = Random.Range (0, itemCount);
		patrolDst = destinations [index].transform.position;
		enemyAgent.SetDestination (patrolDst);

	}


	void Update () {

		if (isStunned)
			return;

		float dist = enemyAgent.remainingDistance;
		if (isOnTarget == false) 
		{
			if (enemyAgent.remainingDistance == 0) 
			{
				Debug.Log ("Assign Attempt");		
				AssignNewDestination ();
			}
		}

		if(isOnTarget == true)
		{	
			
			if(Vector3.Distance(Player.transform.position, this.transform.position) > 2)
			{
				
				enemyAgent.Resume ();
				enemyAgent.SetDestination (Player.transform.position);

			}
			else
			{
				enemyAgent.Stop ();
				Vector3 lookVector = new Vector3 (Player.transform.position.x, transform.position.y, Player.transform.position.z);
				transform.LookAt (lookVector);
			}
			if (dist != Mathf.Infinity && enemyAgent.remainingDistance >= 2) 
			{
				//enemyAgent.SetDestination (Player.transform.position);
			}
			if(enemyAgent.remainingDistance < 2)
			{
				//enemyAgent.ResetPath ();
				//Vector3 lookVector = new Vector3 (Player.transform.position.x, transform.position.y, Player.transform.position.z);
				//transform.LookAt (lookVector);
			}

		}
		
	}

	void AssignNewDestination()
	{
		Debug.Log ("Assigning New Destination");

		index = Random.Range (0, itemCount);
		patrolDst = destinations [index].transform.position;
		enemyAgent.SetDestination (patrolDst);
	}



	public virtual void DisablePatrol()
	{
		Debug.Log ("Disable Patrol Called");
		enemyAgent.ResetPath ();
	}
    public virtual void MoveToMelee(GameObject target)
    {
		Debug.Log ("Move to Melee Called");
		targetPlayer = target;
		//enemyAgent.SetDestination (targetPlayer.transform.position);
		isOnTarget = true;
    }

	public virtual void InitiateStun ()
	{
		Debug.Log ("Initiate Stun Called");
		isStunned = true;
		StartCoroutine (StunEffect ());
	}

	IEnumerator StunEffect()
	{
		enemyAgent.Stop ();
		Debug.Log ("Is Stunned");
		for(int i = 0; i<5; i++)
		{
			yield return new WaitForSeconds (1f);
		}
		enemyAgent.Resume ();
		isStunned = false;
	}

}
