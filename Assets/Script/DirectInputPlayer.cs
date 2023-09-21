using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class DirectInputPlayer : MonoBehaviour
{
    public float force = 10f;
    private Keyboard kb;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        kb = Keyboard.current;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forw = 0f, right = 0f;
        if (kb.wKey.isPressed)
            forw = 1f;
        if (kb.sKey.isPressed)
            forw = -1;
        if (kb.dKey.isPressed)
            right = 1f;
        if (kb.aKey.isPressed)
            right = -1f;

        rb.AddForce(new Vector3(right * force, 0, forw * force));
    }
}
