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
    public float maxRotationSpeed;
    private float final_roll = 0;
    public Transform aimTarget;


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
        RotationLook(horizontal, vertical);
        HorizontalLean(transform.GetChild(0), horizontal, 80, .1f);
    }


    void localMove(float vertical, float horizontal)
    {
        transform.localPosition += new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
        ClampPosition();
    }
    void ClampPosition()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void RotationLook(float vertical, float horizontal)
    {
        //aimTarget.parent.position = Vector3.zero;
        aimTarget.localPosition = new Vector3(horizontal, vertical, 1);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimTarget.position), Mathf.Deg2Rad * speed);
    }
    //void HorizontalRotation(Transform target, float )

    void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime)
    {
        Vector3 targetEulerAngels = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngels.x, targetEulerAngels.y, Mathf.LerpAngle(targetEulerAngels.z, -axis * leanLimit, lerpTime));
    }

    /*
    void Rotation(float pitch, float yaw)
    {
        float inc_pitch = pitch * maxRotationSpeed * Time.deltaTime;
        float current_pitch = transform.localRotation.eulerAngles.x;
        //float current_pitch = rb.rotation.eulerAngles.x;
        if (current_pitch > 180f)
        {
            current_pitch -= 360;
        }
        float final_pitch = current_pitch + inc_pitch;
        final_pitch = Mathf.Clamp(final_pitch, -60, 60f);

        float inc_yaw = yaw * maxRotationSpeed * Time.deltaTime;
        float current_yaw = transform.localRotation.eulerAngles.y;
        //float current_yaw = rb.rotation.eulerAngles.y;

        if (current_yaw > 180f)
        {
            current_yaw -= 360;
        }
        float final_yaw = current_yaw + inc_yaw;
        final_yaw = Mathf.Clamp(final_yaw, -60, 60f);
        Debug.Log(final_yaw);
        if (yaw != 0)
        {
            final_roll = Mathf.Lerp(final_roll, -yaw * 60f, 0.1f);
        }
        else
        {
            final_roll = Mathf.Lerp(final_roll, 0, 0.1f);
        }
        transform.localRotation = Quaternion.Euler(final_pitch, final_yaw, final_roll);
        //rb.rotation = Quaternion.Euler(final_pitch, final_yaw, final_roll);

    }
    */

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(aimTarget.position, .5f);
        Gizmos.DrawSphere(aimTarget.position, .15f);
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
