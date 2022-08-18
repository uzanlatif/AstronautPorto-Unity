using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    private int currentGem;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="PickAsteroid"){
            Debug.Log("dropedGem");
            currentGem=PlayerPrefs.GetInt("gemMothership");
            currentGem++;
            PlayerPrefs.SetInt("gemMothership",currentGem);        
        }
    }
}
