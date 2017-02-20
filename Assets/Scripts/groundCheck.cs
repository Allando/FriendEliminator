using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class groundCheck : MonoBehaviour {

	private playerScript player;

	// Use this for initialization
	void Start ()
	{
		player = gameObject.GetComponentInParent<playerScript>();	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        player.Grounded = true;
    }

    void OnTriggerStay20(Collider2D col)
    {
        player.Grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player.Grounded = false;
    }
	
}
