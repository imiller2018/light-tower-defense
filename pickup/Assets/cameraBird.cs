using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBird : MonoBehaviour
{
    public Transform player;
    public float height;

    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, height, player.position.z);
        //transform.LookAt(player);
    }
}
