using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
	{

		// trigger coin pickup function if a helicopter collides with this
		GameObject.FindObjectOfType<SlimeController>().Die();
		GetComponent<AudioSource>().Play();
	}
}
