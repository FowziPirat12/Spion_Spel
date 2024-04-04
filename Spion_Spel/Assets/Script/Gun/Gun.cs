using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Animator rAnimation;
    public GameObject muzzleFlash;
    public GunTyps gun;
    public float damage;
    public float range;
    public int currentAmmo;
    public int magSize;
    public int mags;
    public TMP_Text ammo;
    public float fireRate;
    public float reloadTime;
    public int shoots;
    public bool automatic;
    public bool multiShot;
    public bool reloading;
    private float timer;

    public GameObject impactEffect;
    public Camera fpsCam;

    private Recoil recoilScript;

    // Start is called before the first frame update
    void Start()
    {
        recoilScript = transform.Find("CameraRot/CameraRecoil").GetComponent<Recoil>();
        mags = 100;
        rAnimation = GetComponent<Animator>();
        damage = gun.damage;
        range = gun.range;
        currentAmmo = gun.currentAmmo;
        magSize = gun.magSize;
        ammo.text = $"{currentAmmo}/{magSize}";
        fireRate = gun.fireRate;
        shoots = gun.shoots;
        automatic = gun.automatic;
        multiShot = gun.multiShot;
        reloadTime = gun.reloadTime;
        timer = 0;
        muzzleFlash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && !reloading && mags > 0)
        {
            gameObject.transform.Rotate(1, 0, 0);
            reloading = true;
            StartCoroutine(Reloading());
            ammo.text = "Reloading";
            mags--;
            gameObject.transform.Rotate(-1, 0, 0);
        }
        if(automatic)
        {
            if(Input.GetMouseButton(0) && currentAmmo > 0 && !reloading)
            {
                if(timer >= fireRate)
                {
                     if(!multiShot)
                    {
                        timer = 0;
                        Shoot();
                        currentAmmo--;
                    }
                    /*if(multiShot)
                    {
                    timer = 0;
                    
                    currentAmmo -= shoots;
                    }*/
                }
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0) && currentAmmo > 0 && !reloading)
            {
                if(timer >= fireRate)
                {
                     if(!multiShot)
                    {
                        timer = 0;
                        Shoot();
                        currentAmmo--;
                    }
                    /*if(multiShot)
                    {
                    timer = 0;
                    
                    currentAmmo -= shoots;
                    }*/
                }
            }
        }
        timer += Time.deltaTime;
        if(!reloading) ammo.text = $"{mags}  {currentAmmo}/{magSize}";
    }

    void Shoot()
    {
        StartCoroutine(MuzzleFlash());
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            rAnimation.SetTrigger("Recoil");
            Entity enemy = hit.transform.GetComponent<Entity>();
            if(enemy != null)
            {
                enemy.hp -= 10;
                Debug.Log(enemy.hp);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, .5f);
        }
        recoilScript.recoilFire();
    }
    IEnumerator Reloading()
    {
        rAnimation.SetTrigger("Spin");
        yield return new WaitForSeconds(1);
        currentAmmo = magSize;
        reloading = false;
    }

    IEnumerator MuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        muzzleFlash.SetActive(false);
    }   
}