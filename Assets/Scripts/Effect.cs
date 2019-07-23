using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private float delay = 0.23f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyEffect", delay);
    }

    void DestroyEffect(){
        Destroy(this.gameObject);
    }
}
