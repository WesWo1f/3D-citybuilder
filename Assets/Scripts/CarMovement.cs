using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 10f;

    public GameObject car;

    public Light[] carLights;

    void Update()
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) > 500f)
        {
            carLights[0].enabled = false;
            carLights[1].enabled = false;
            carLights[2].enabled = false;
            carLights[3].enabled = false;
            carLights[4].enabled = false;
            carLights[5].enabled = false;
            carLights[6].enabled = false;
            
        }
        else
        {
            carLights[0].enabled = true;
            carLights[1].enabled = true;
            carLights[2].enabled = true;
            carLights[3].enabled = true;
            carLights[4].enabled = true;
            carLights[5].enabled = true;
            carLights[6].enabled = true;

        }
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
    public void OnCollisionEnter(Collision col)
    {
        Destroy(this.gameObject);
        print("collison");
    }
    public void CarDistance()
    {

    }
}
