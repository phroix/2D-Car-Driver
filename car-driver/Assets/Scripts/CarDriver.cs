using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDriver : MonoBehaviour
{
    [SerializeField]float steerSpeed = 1f;
    [SerializeField]float moveSpeed = .01f;


    // Update is called once per frame
    void Update()
    {
        MoveCar();
    }

    private void MoveCar()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        if (moveAmount > 0 || moveAmount < 0) transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
