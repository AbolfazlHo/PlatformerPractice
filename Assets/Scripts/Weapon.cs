using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    int fireRate = 10;
    int i = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (i<fireRate)
        {
            i++; 
        }
        else
        {
            Shoot();
            i = 0;
        }
        

    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bullet, this.transform.position, this.transform.rotation);
        Rigidbody2D _bulletRigid = bulletGO.GetComponent<Rigidbody2D>();
        _bulletRigid.velocity = new Vector2(10.0f, 0.0f);
        Destroy(bulletGO, 2.0f);
    }
}
