using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private Transform playerPos;
    private Vector3 toPlayerVector;
    private Vector3 currentOffset = Vector3.zero;

    private Vector3 targetPosition;

    [SerializeField] private float limX = 1, limY = 1;
    Vector3 originalLocalPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        originalLocalPos = transform.localPosition;
        playerPos = GameManager.gameManager.getPlayer().transform;
        toPlayerVector = playerPos.position - transform.position;
    }

    public void setOffset(Vector3 offset)
    {

        Debug.Log("Offset: " + offset);
        //Limitar en x e y

    }

    public void Update()
    {
        Vector3 offset = GameManager.gameManager.getPlayer().GetComponent<movementTest>().playerOffset;
        offset.x = Mathf.Sign(offset.x) * Mathf.Min(Mathf.Abs(offset.x), limX);
        offset.y = Mathf.Sign(offset.y) * Mathf.Min(Mathf.Abs(offset.y), limY);
        offset = Vector3.Lerp(currentOffset, offset, .5f);
        transform.localPosition = originalLocalPos + offset;

        if (offset != Vector3.zero)
        {
            Debug.Log("Offset: " + offset.normalized);
        }

        currentOffset = offset;
    }
}
