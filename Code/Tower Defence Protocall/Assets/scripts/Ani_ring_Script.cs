using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ani_ring_Script : MonoBehaviour
{
    public GameObject followPlayer;
    public GameObject Torrus;
    public float delayTime;
    private float delayCounter = 0;
    // Update is called once per frame
    void Update()
    {
        if (Torrus.transform.localPosition.y < -4f)
        {
            this.transform.localPosition = new Vector3(followPlayer.transform.position.x, 1f, followPlayer.transform.position.z);
            Torrus.transform.localPosition = new Vector3(0, 0, 0);
            Torrus.transform.localScale = new Vector3(30f, 30f, 30f);
            this.GetComponent<Animator>().Play("New Animation", -1, 0f);
            delayCounter = delayTime;
        }
        else
            Torrus.transform.position = Torrus.transform.position - new Vector3(0f, 4f * Time.deltaTime, 0f);
    }
}
