using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed =  20f;
    [SerializeField] float normalSpeed =  20f;
    [SerializeField] float boostSpeed =  30f;
    [SerializeField] float outOfRoadSpeed = 10f;
    bool boostAllowed;
    

    void Update()
    {
        float steerAmount1 = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount2 = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0 , 0 , -steerAmount1);
        transform.Translate(0 , moveAmount2 , 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedUp")
        {
            moveSpeed = boostSpeed;
            Debug.Log("booooooooooooooost");
            boostAllowed = true;
        }
        if (other.tag == "SuperSpeed")
        {
            moveSpeed = 100f;
            Debug.Log("SUPER BOOOOSTTT!!!!!!");
            boostAllowed = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = outOfRoadSpeed;
        Debug.Log("booo slooowww speed");
        boostAllowed = false;
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "roads" && !boostAllowed)
        {
            moveSpeed = outOfRoadSpeed;
            Debug.Log("Out of the Road!");
        }
    }

     void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "roads" && !boostAllowed) 
        { 
            moveSpeed = normalSpeed;
            Debug.Log("Return to normalSpeed");
        }
    }
}
