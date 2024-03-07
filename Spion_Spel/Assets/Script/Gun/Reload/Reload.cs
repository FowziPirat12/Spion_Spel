using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public Gun gun;
    public int maxCarry;
    public float reloadTime;
    public bool reloading;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        reloading = false;
        gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
    }

    void Update()
    {
        if(reloadTime > timer && reloading){
            timer += Time.deltaTime;
        }
        else if(timer > reloadTime)
        {
            reloading = true;
        }
        if(!reloading && timer > reloadTime)
        {
            reloading = false;
            Reloading(maxCarry);
        }
    }

    public void Reloading(int ammo)
    {
        timer = 0;
        gun.currentAmmo = ammo;
        gun.Reloading();
    }
}
