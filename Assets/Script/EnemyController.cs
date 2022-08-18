using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{   public GameObject prefabBullet;
    public Transform firepoint;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootBullet",1f,1f);
    }

    public void ShootBullet(){

        GameObject projectileGO = (GameObject) Instantiate(prefabBullet, firepoint.transform.position, firepoint.transform.rotation);
        Rigidbody projectileRb = projectileGO.GetComponent<Rigidbody>();
        projectileRb.AddForce(-50 * Vector3.forward, ForceMode.Impulse);
    }
}
