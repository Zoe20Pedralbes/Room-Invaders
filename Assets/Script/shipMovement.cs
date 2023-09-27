using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class shipMovement : MonoBehaviour
{
    public float speed = 3;

    public InputActionAsset movementActions;
    private InputAction actionUp;
    private InputAction actionHorizontal;



    // Start is called before the first frame update
    void Start()
    {
        actionUp = movementActions.FindActionMap("movement").FindAction("Up");
        actionHorizontal = movementActions.FindActionMap("movement").FindAction("Horizontal");
        Debug.Log(actionUp + " " + actionHorizontal);
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = actionUp.ReadValue<float>();
        float horizontal = actionHorizontal.ReadValue<float>();
        Debug.Log(vertical + " " + horizontal);
        localMove(vertical, horizontal);

    }

    void localMove(float vertical, float horizontal)
    {
        transform.localPosition += new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
    }
    void cameraPos()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    private void OnEnable()
    {
        movementActions.Enable();
    }
    private void OnDisable()
    {
        movementActions.Disable();
    }
}
