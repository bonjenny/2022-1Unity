using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;

public class HandCtrl : MonoBehaviour {
	// public ActionBasedController controller;
	public GameObject Bullet;
	public Transform FirePos;
	public AudioClip ShotSound;

	private AudioSource _audio;
	float span = 1.0f;
	float delta = 0;
	bool isPressed;

	void Start () 
	{
		// controller = GetComponent<ActionBasedController>();
		// controller.selectAction.action.performed += SelectAction;
    // controller.activateAction.action.performed += TriggerDown;
		_audio = GetComponent<AudioSource> ();
	}

  // private void TriggerDown(UnityEngine.InputSystem.InputAction.CallbackContext obj) { Shoot(); }
	// private void SelectAction(UnityEngine.InputSystem.InputAction.CallbackContext obj) { Debug.Log("Shoot"); }

	private void Shoot()
	{
		Debug.Log("Shoot");
		// controller.SendHapticImpulse(0.7f, 0.5f);
		_audio.PlayOneShot(ShotSound);
		Instantiate(Bullet, FirePos.position, FirePos.rotation);
	}

	void Update () 
	{
		this.delta += Time.deltaTime;
		if (this.delta > this.span) { this.delta = 0; /* Shoot() */ }
		if (Input.GetMouseButtonDown(0))
		{
			Shoot(); // 총을 쏜다.
		}
	}
}
