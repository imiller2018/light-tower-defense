using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(AudioSource))]

public class camera : MonoBehaviour
{
    public bool topright = false;
    public bool bottomleft = false;

    public Vector3 origPos;
    public Vector3 topRPos;
    public Vector3 botLPos;
    public Vector3 bothPos;
    public Vector3 newpostion;
    public AudioClip clip;


    void Start()
    {
        origPos = this.transform.position;
        newpostion = this.transform.position;
    }

    void Update()
    {
        if (Mathf.Abs(newpostion.x - this.transform.position.x) > 1 || Mathf.Abs(newpostion.y - this.transform.position.y)> 1)
        {
            Vector3 diff = newpostion - this.transform.position;
            diff = diff.normalized;
            transform.position = this.transform.position + diff * 0.5f;
        }
    }

    private void updateCamera()
    {
        if (topright && bottomleft)
        {
            newpostion = bothPos;
        }
        else if (topright == true)
        {
            newpostion = topRPos;
        }
        else if (bottomleft)
        {
            newpostion = botLPos;
        }
        else
        {
            newpostion = origPos;
        }
    }

    public void changestatus(string stat)
    {
        if (stat == "BL")
        {
            AudioSource.PlayClipAtPoint(clip, this.transform.position, 4f);
            bottomleft = !bottomleft;
            updateCamera();
        }
        else if (stat == "TR")
        {
            AudioSource.PlayClipAtPoint(clip, this.transform.position, 4f);
            topright = !topright;
            updateCamera();
        }
    }
}
