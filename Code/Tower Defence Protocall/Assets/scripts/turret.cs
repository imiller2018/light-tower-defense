using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public GameObject bullet;
    public GameObject ammobar;

    private int maxAmmo = 20;
    private int ammo = 0;
    private float reloadSpeed = 0.3f;
    private float reloadTimer = 0;
    private float bulletSpeed = 5;

    void start()
    {
        ammobar.active = false;
        ammo = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (reloadTimer >0)
        {
            reloadTimer -= Time.deltaTime;
        }
    }

    public void Fire()
    {
        if(reloadTimer <= 0 && ammo > 0)
        {
            reloadTimer = reloadSpeed;
            GameObject newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation) as GameObject;
            newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed * 100);
            ammo--;
            updateammo();
        }
    }

    public void addAmmo(GameObject go)
    {
        Destroy(go);
        ammo = 20;
        updateammo();
    }

    public void updateammo()
    {
        float ratio = ammo / (float)maxAmmo * 10;
        ammobar.transform.localScale = new Vector3(ratio, ammobar.transform.localScale.y, ammobar.transform.localScale.z);
    }

    public void setup()
    {
        ammobar.GetComponent<Renderer>().enabled = true;
        updateammo();
    }

    public void putdown()
    {
        ammobar.GetComponent<Renderer>().enabled = false;
    }
}
