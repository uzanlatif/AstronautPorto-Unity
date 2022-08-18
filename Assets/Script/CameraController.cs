using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
     void Update()
     {
         float xAxisValue = Input.GetAxis("Horizontal") * 0.1f;
         float zAxisValue = Input.GetAxis("Vertical") * 0.1f;
         float yAxisValue = Input.GetAxis("Mouse ScrollWheel") * -5f;
 
         transform.position = new Vector3(
            transform.position.x + xAxisValue, 
            transform.position.y+ yAxisValue, 
            transform.position.z + zAxisValue
            );
     }
}
