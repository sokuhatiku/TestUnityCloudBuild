using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float range = 180;

    Vector3 rotationSpeed;
    Vector3 targetSpeed;
    Vector3 velocity;
    private float elapsedTime;
    private float nextChangeTime;
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > nextChangeTime)
        {
            nextChangeTime = Random.Range(0f, 10f);
            targetSpeed = new Vector3(
                Random.Range(-range, range), 
                Random.Range(-range, range), 
                Random.Range(-range, range));
            
            elapsedTime = 0;
        }

        rotationSpeed = Vector3.SmoothDamp(rotationSpeed, targetSpeed, ref velocity, nextChangeTime / 2);


        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
