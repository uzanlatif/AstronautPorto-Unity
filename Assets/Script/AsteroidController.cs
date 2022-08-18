using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public GameObject gems1,gems2,gems3;
    public GameObject spPoint1, spPoint2, spPoint3;
    // Start is called before the first 

    private void Start() {
    }
    public void digged(){
        Invoke("spawnGems",3f);
    }

    public void spawnGems(){
        Destroy(gameObject);
        Instantiate (gems1,spPoint1.transform.position, Quaternion.identity);
        Instantiate (gems2,spPoint2.transform.position, Quaternion.identity);
        Instantiate (gems3,spPoint3.transform.position, Quaternion.identity);
    }
}
