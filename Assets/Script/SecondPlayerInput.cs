using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SecondPlayerInput : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = new Vector3(speed, _rigidbody.velocity.y, _rigidbody.velocity.z);
    }
}
