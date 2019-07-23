using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    //public Vector3 camera_position = Vector3.zero;
    public Transform obj;
    public int min_position, max_position; 
    //private bool bounds = true;

    // Update is called once per frame
    void Update()
    {
        //Faz a camera se mover com delay   
        float move_x = Mathf.SmoothStep(transform.position.x, obj.transform.position.x, 0.2f);
        transform.position = new Vector3(move_x, transform.position.y, transform.position.z);

        //Limita o movimento da camera
        float clamp_x = Mathf.Clamp(transform.position.x, min_position, max_position);
        transform.position = new Vector3(clamp_x, transform.position.y, transform.position.z);

    }

}
