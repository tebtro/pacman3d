using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour {

    ParticleSystem explosion;
    AudioSource explosionSound;
	// Use this for initialization
	void Start () {
        explosion = GetComponent<ParticleSystem>();
        explosion.Play();

        explosionSound = GetComponent<AudioSource>();
        explosionSound.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (explosion)
        {
            if (!explosion.IsAlive())
            {
                Debug.Log("Destroying Explosion");
                Destroy(gameObject);
            }
        }
	}
}
