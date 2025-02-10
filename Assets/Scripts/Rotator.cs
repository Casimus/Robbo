using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2f;

    void Start()
    {
        rotationSpeed = Random.Range(0.5f * rotationSpeed, 1.5f * rotationSpeed);
    }

   
    void Update()
    {
        transform.Rotate(new Vector3(0,0,1f) * rotationSpeed *Time.deltaTime);
    }
}
