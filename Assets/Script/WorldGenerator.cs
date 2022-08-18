using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public GameObject prefabAsteroid;
    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i < 30; i++) {
            
           var position= new Vector3(Random.Range(377, 470), 232, Random.Range(-33, 59));

           Instantiate(prefabAsteroid, position, Quaternion.identity);
            
        }

    }
}
