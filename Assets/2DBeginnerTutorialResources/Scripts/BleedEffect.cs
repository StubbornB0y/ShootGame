using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedEffect : MonoBehaviour
{
    public float TimetoDestroy = 1f;
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
