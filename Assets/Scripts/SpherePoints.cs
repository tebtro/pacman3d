using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePoints : MonoBehaviour {

    public int points;
    private GameManager gameManager;


	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pacman")
        {
            gameManager.updateScore(points);
            Destroy(this.gameObject);
        }
    }
}
