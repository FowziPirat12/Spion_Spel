using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Animator rAnimation;
    public GunTyps gun;
    public GameObject muzzleFlash;
    public GameObject impactEffect;
    public GameObject bloodEffect;
    public GameObject bulletTrail;
    public Transform muzzlePos;
    public Camera fpsCam;
    private Recoil recoilScript;
    public TMP_Text ammo;
    public float damage;
    public float range;
    public int currentAmmo;
    public int magSize;
    public int mags;
    public float fireRate;
    public float inaccutacyDistance;
    public int bulletsPerShot;
    public bool automatic;
    public bool shotgun;
    public bool reloading;
    private float timer;
    public float snappiness;

    // Start is called before the first frame update
    void Start()
    {
        recoilScript = GameObject.FindGameObjectWithTag("Recoil").GetComponent<Recoil>();
        mags = 100;
        rAnimation = GetComponent<Animator>();
        damage = gun.damage;
        range = gun.range;
        currentAmmo = gun.currentAmmo;
        magSize = gun.magSize;
        ammo.text = $"{currentAmmo}/{magSize}";
        fireRate = gun.fireRate;
        snappiness = gun.snappiness;
        recoilScript.snappiness = snappiness;
        inaccutacyDistance = gun.inaccutacyDistance;
        bulletsPerShot = gun.bulletsPerShot;
        automatic = gun.automatic;
        shotgun = gun.shotgun;
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
                    timer = 0;
                    Shoot();
                    currentAmmo--;
                }
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0) && currentAmmo > 0 && !reloading)
            {
                if(timer >= fireRate)
                {
                    timer = 0;
                    Shoot();
                    currentAmmo--;
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
        if(shotgun)
        {
            for (int i = 0; i < bulletsPerShot; i++)
            {
                Vector3 shootingDir = GetShootingDirection();
                if(Physics.Raycast(fpsCam.transform.position, shootingDir, out hit, range))
                {
                    Entity enemy = hit.transform.GetComponent<Entity>();
                    if(enemy != null)
                    {
                        GameObject impactGO = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                        Destroy(impactGO, .5f);
                        enemy.hp -= 10;
                        Debug.Log(enemy.hp);
                    }
                    else
                    {
                        GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                        Destroy(impactGO, .5f);
                    }
                    //CreatTrail(hit.point);
                }
                //else CreatTrail(fpsCam.transform.position + shootingDir * range);
            }
        }
        else
        {
            Vector3 shootingDir = GetShootingDirection();
            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Entity enemy = hit.transform.GetComponent<Entity>();
                if(enemy != null)
                {
                    GameObject impactGO = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactGO, .5f);
                    enemy.hp -= 10;
                    Debug.Log(enemy.hp);
                }
                else
                {
                    GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactGO, .5f);   
                }
                CreatTrail(hit.point);
            }
            else CreatTrail(fpsCam.transform.position + shootingDir * range);
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

    Vector3 GetShootingDirection()
    {
        Vector3 targetPos = fpsCam.transform.position + fpsCam.transform.forward * range;
        targetPos = new Vector3(
            targetPos.x + Random.Range(-inaccutacyDistance, inaccutacyDistance),
            targetPos.y + Random.Range(-inaccutacyDistance, inaccutacyDistance),
            targetPos.z + Random.Range(-inaccutacyDistance, inaccutacyDistance)
        );
        Vector3 direction = targetPos - fpsCam.transform.forward;
        return direction.normalized;
    }
    void CreatTrail(Vector3 end)
    {
        LineRenderer lr = Instantiate(bulletTrail).GetComponent<LineRenderer>();
        lr.SetPositions(new Vector3[2] {muzzlePos.position, end});
        Destroy(lr, 2f);
    }
}