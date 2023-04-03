using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDriver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float slowTime = 1.5f;
    [SerializeField] float boostSpeed = 25f;
    [SerializeField] float boostTime = 1f;


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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boost")
        {
            moveSpeed = boostSpeed;
            StartCoroutine(UndoBoost(boostTime));
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Slow")
        {
            moveSpeed = slowSpeed;
            StartCoroutine(UndoBoost(slowTime));
        }
    }

    private IEnumerator UndoBoost(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        moveSpeed = 12f;
    }
}
