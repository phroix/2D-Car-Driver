using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject carToFollow;

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = carToFollow.transform.position + new Vector3(0,0,-10);
    }
}
