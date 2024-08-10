using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherMove : MonoBehaviour
{
    Transform other_object;
    float move_sideways;
    [SerializeField] float speed = 5f;
    void Start()
    {
        other_object = transform;
        move_sideways = other_object.position.x;
    }
    void Update()
    {
        move_sideways -= Time.deltaTime * speed;
        other_object.position = new Vector3(move_sideways, other_object.position.y, other_object.position.z);
        // ある程度進んだら消す
        if(other_object.position.x < -15.0f)
            Destroy(this.gameObject);  
    }
}
