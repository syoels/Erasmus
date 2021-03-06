﻿using UnityEngine;
using System.Collections;

public class SwarmSingle : MonoBehaviour {

	[Range (0, 100)]
	public int decayRate;
	[Range (0, 100)]
	public int halfLife;
	[Range (0, 1)]
	public float hitChance;
	public float lightThresh;
	private Animator anim;
	private SpriteRenderer sprite;
	private Affector affector;
	private Rigidbody2D rb;


	void Awake() {
		anim = GetComponent<Animator> ();
		affector = GetComponent<Affector> ();
		sprite = GetComponent<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Decay", decayRate, decayRate);
		if (RenderSettings.ambientIntensity > lightThresh)
			anim.SetTrigger ("day");
	}

	void FixedUpdate() {
		sprite.flipX = rb.velocity.x > 0;
	}

	void OnDisable() {
		CancelInvoke ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (Random.value < hitChance) {
			if (col.CompareTag ("Creature")) {
				affector.Affect (col.gameObject);
				Destroy (this.gameObject);
			} else if (col.CompareTag ("Food")) {
				col.gameObject.SetActive (false);
			}
		}
	}

	private void Decay (){
		if (--this.halfLife < 0 && !sprite.isVisible)
			Destroy (this.gameObject);
	}


}
