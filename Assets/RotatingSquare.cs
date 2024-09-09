using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSquare : MonoBehaviour
{
    public float rotationSpeed = 30f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
