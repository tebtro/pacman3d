using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManAttack : MonoBehaviour {

    public int ammo;
    public GameObject bulletPrefab;
    public GameObject player;
    public Transform bulletSpawnPoint;

    // Use this for initialization
    void Start () {
        FindObjectOfType<GameManager>().ammoText.text = ammo + "";
    }

    public void shoot()
    {
        if(ammo > 0)
        {
            
            Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
            ammo -= 1;
            FindObjectOfType<GameManager>().ammoText.text = ammo + "";
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
