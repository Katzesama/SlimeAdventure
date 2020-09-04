using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
	{
		// infinitely rotate this coin about the Y axis in world space
		transform.Rotate(0, 5f, 0, Space.World);
	}

	void OnTriggerEnter(Collider other)
	{

		// trigger coin pickup function if a helicopter collides with this
		GameObject.FindObjectOfType<SlimeController>().EatCake();
		GameObject.Find("CakeEatten").GetComponent<AudioSource>().Play();
		Destroy(gameObject);
	}
}
