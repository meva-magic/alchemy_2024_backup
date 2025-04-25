using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeBeasts : MonoBehaviour
{
    public GameObject[] eyeshroom;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Beast")
        {   
            Destroy(collision.collider.gameObject, 0.5f);
            Instantiate(eyeshroom[0], transform.position, Quaternion.identity);
        }
    }
}
