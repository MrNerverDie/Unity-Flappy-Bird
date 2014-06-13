using UnityEngine;
using System.Collections;
using System;


public class TubeController : MonoBehaviour {


	// Use this for initialization
	void Start () {
        GetComponent<Observer>().AddEventHandler("GameOver", OnGameOver);
	}

    void OnGameOver(object sender, EventArgs e)
    {
        rigidbody2D.velocity = new Vector2(0, 0);
    }

}

