﻿#pragma strict

var AmmoSound : AudioSource;

function OnTriggerEnter (col : Collider) {
	AmmoSound.Play();
	if (GlobalAmmo.LoadedAmmo == 0) {
		GlobalAmmo.LoadedAmmo += 10;
	}else {
		GlobalAmmo.CurrentAmmo += 10;
	}	
	this.gameObject.SetActive(false);
}
