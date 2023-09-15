using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]float curSpeed = 10f;
    [SerializeField]float turnCar = 180f;
    [SerializeField]float slow = 5f;
    [SerializeField]float fast = 20f;
    float steerAmount, speedAmount;

    void Update()
    {
        steerAmount = -Input.GetAxis("Horizontal")*turnCar*Time.deltaTime;
        speedAmount = Input.GetAxis("Vertical")*curSpeed*Time.deltaTime;
        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0, speedAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(curSpeed > 10f)
            curSpeed = 10f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boost"){
            Debug.Log("Sonic Boom joke");
            curSpeed = fast;
        }
        
        if(other.tag == "Bump"){
            Debug.Log("Fucking dogshit");
            curSpeed = slow;
        }
    }
}
