﻿using System.Collections;
using UnityEngine;

public class ZombieFollow : MonoBehaviour {
	
	public GameObject ThePlayer;
	public float TargetDistance;
	public float AllowedRange = 10;
	public GameObject TheEnemy;
	public float EnemySpeed;
	public int AttackTrigger;
	public RaycastHit Shot;
	
	public int isAttacking;
	public GameObject PlayerHurtScreen;
	
	
	void Update() {
		transform.LookAt(ThePlayer.transform);
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot)) {
			TargetDistance = Shot.distance;
			if (TargetDistance < AllowedRange) {
				EnemySpeed = 0.01f;
				if (AttackTrigger == 0) {
					TheEnemy.GetComponent<Animation>().Play("Walking");
					transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);
				}
			}else {
				EnemySpeed = 0;
				TheEnemy.GetComponent<Animation>().Play("Idle");
			}
		}
		if (AttackTrigger == 1) {
			EnemySpeed = 0;
			TheEnemy.GetComponent<Animation>().Play("Attacking");
		}
	}
	
	void OnTriggerEnter() {
		AttackTrigger = 1;
	}
	
	void OnTriggerExit() {
		AttackTrigger = 0;
	}
	
}
