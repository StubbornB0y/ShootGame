using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEffect : MonoBehaviour
{
    public float TimetoDestroy = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TimetoDestroy);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
