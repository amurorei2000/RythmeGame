using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMove : MonoBehaviour
{
    public float downTime = 3.0f;
    public float moveDistance = 0;

    void Start()
    {
        float bps = downTime / Time.fixedDeltaTime;
        moveDistance = 9.0f / bps;
        print($"{bps}, {moveDistance}");

        Invoke("DeActivateSelf", 5.0f);
    }

    void FixedUpdate()
    {
        transform.position += Vector3.down * moveDistance;
    }

    void DeActivateSelf()
    {
        gameObject.SetActive(false);
    }
}
