using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{
    public KeyCode setKey;
    public GameObject effectObject;

    ParticleSystem keyFX;

    void Start()
    {
        keyFX = effectObject.GetComponent<ParticleSystem>();
    }


    void Update()
    {
        if(Input.GetKeyDown(setKey))
        {
            Collider[] cols = Physics.OverlapBox(transform.position, new Vector3(0.8f, 0.4f, 1), Quaternion.identity, 1<<6);

            if(cols.Length > 0)
            {
                cols[0].gameObject.SetActive(false);
                effectObject.transform.position = transform.position;
                keyFX.Play();
            }
        }
    }
}
