using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMove : MonoBehaviour
{
    public float moveSpeed = 2;

    void Start()
    {
        Invoke("DeActivateSelf", 5.0f);
    }

    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }

    void DeActivateSelf()
    {
        gameObject.SetActive(false);
    }
}
