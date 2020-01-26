using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour {

    public float speed;
    public ParticleSystem explosionPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        move();
        if (!explosionPrefab.IsAlive())
        {
            Destroy(explosionPrefab);
        }
	}

    private void move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        speed += 0.1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pacman")
        {
            return;
        }
        if (other.tag == "Ghost")
        {
            FindObjectOfType<GameManager>().updateScore(256);
            Destroy(other.gameObject);
        }
        Console.WriteLine("BUMM");
        Instantiate(explosionPrefab,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
