using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GunTyps gun;
    public int currentAmmo;
    public int magSize;
    public int mags;
    public TMP_Text ammo;
    public float fireRate;
    public float reloadTime;
    public int shoots;
    public GameObject spawnPos;
    public GameObject bulletPrefab;
    public bool automatic;
    public bool multiShot;
    public bool reloading;
    private float timer;
    public float spin;
    // Start is called before the first frame update
    void Start()
    {
        mags = 100;
        currentAmmo = gun.currentAmmo;
        magSize = gun.magSize;
        ammo.text = $"{currentAmmo}/{magSize}";
        fireRate = gun.fireRate;
        shoots = gun.shoots;
        automatic = gun.automatic;
        multiShot = gun.multiShot;
        reloadTime = gun.reloadTime;
        timer = 0;
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
                        GameObject go = Instantiate(bulletPrefab, spawnPos.transform.position, spawnPos.transform.rotation);
                        go.GetComponent<Bullet>().speed = gun.speed;
                        go.GetComponent<Bullet>().range = gun.range;
                        go.GetComponent<Bullet>().bulletDmg = gun.damage;
                        go.SetActive(true);
                        currentAmmo--;
                    }
                    if(multiShot)
                    {
                    timer = 0;
                    GameObject[] go = new GameObject[shoots];
                    for(int i = 0; i < shoots; i++)
                    {
                        go[i] = Instantiate(bulletPrefab, spawnPos.transform.position + new Vector3(Random.Range(0f,0.5f),Random.Range(0f,0.5f),Random.Range(0f,0.5f)), spawnPos.transform.rotation);
                        go[i].GetComponent<Bullet>().speed = gun.speed;
                        go[i].GetComponent<Bullet>().range = gun.range;
                        go[i].GetComponent<Bullet>().bulletDmg = gun.damage;
                    }
                    foreach(GameObject i in go) i.SetActive(true);
                    currentAmmo -= shoots;
                    }
                }
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                
                if(timer >= fireRate && currentAmmo > 0 && !reloading)
                {
                     if(!multiShot)
                    {
                        timer = 0;
                        GameObject go = Instantiate(bulletPrefab, spawnPos.transform.position, spawnPos.transform.rotation);
                        go.GetComponent<Bullet>().speed = gun.speed;
                        go.GetComponent<Bullet>().range = gun.range;
                        go.GetComponent<Bullet>().bulletDmg = gun.damage;
                        go.SetActive(true);
                        currentAmmo--;
                    }
                    if(multiShot)
                    {
                    timer = 0;
                    GameObject[] go = new GameObject[shoots];
                    for(int i = 0; i < shoots; i++)
                    {
                        go[i] = Instantiate(bulletPrefab, spawnPos.transform.position + new Vector3(Random.Range(0f,0.5f),Random.Range(0f,0.5f),Random.Range(0f,0.5f)), spawnPos.transform.rotation);
                        go[i].GetComponent<Bullet>().speed = gun.speed;
                        go[i].GetComponent<Bullet>().range = gun.range;
                        go[i].GetComponent<Bullet>().bulletDmg = gun.damage;
                    }
                    foreach(GameObject i in go) i.SetActive(true);
                    currentAmmo -= shoots;
                    }
                }
            }
        }
        timer += Time.deltaTime;
        if(!reloading) ammo.text = $"{mags}  {currentAmmo}/{magSize}";
        if(reloading)
        {
            //gameObject.transform.Rotate(spin * Time.deltaTime, 0, 0, Space.Self);
            transform.rotation = Quaternion.FromToRotation(transform.rotation.ToEuler(), new Vector3(90,0,0)) ;
        }
        if(transform.rotation.x == 90 && reloading) Debug.Log("90");
    }
    IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = magSize;
        reloading = false;
    }
}
