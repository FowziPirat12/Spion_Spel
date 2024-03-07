using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    Reload reload;
    public GunTyps gun;
    public int currentAmmo;
    public int magSize;
    public int mags;
    public TMP_Text ammo;
    public float fireRate;
    public GameObject spawnPos;
    public GameObject bulletPrefab;
    public bool automatic;
    public bool reloading;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        reload = GameObject.FindGameObjectWithTag("Player").GetComponent<Reload>();
        mags = 1;
        currentAmmo = gun.currentAmmo;
        magSize = gun.magSize;
        ammo.text = $"{currentAmmo}/{magSize}";
        fireRate = gun.fireRate;
        automatic = gun.automatic;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && !reloading && mags > 0)
        {
            reloading = true;
            reload.reloadTime = gun.reloadTime;
            reload.maxCarry = magSize;
            ammo.text = "Reloading";
            mags--;
            reload.reloading = true;
        }
        
        if(automatic)
        {
            if(Input.GetMouseButton(0) && currentAmmo > 0 && !reloading)
            {
                if(timer >= fireRate)
                {
                    timer = 0;
                    GameObject go = Instantiate(bulletPrefab, spawnPos.transform.position, spawnPos.transform.rotation);
                    go.GetComponent<Bullet>().speed = gun.speed;
                    go.GetComponent<Bullet>().maxDistance = gun.maxDistance;
                    go.GetComponent<Bullet>().bulletDmg = gun.damage;
                    go.SetActive(true);
                    currentAmmo--;
                }
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                
                if(timer >= fireRate && currentAmmo > 0 && !reloading)
                {
                    timer = 0;
                    GameObject go = Instantiate(bulletPrefab, spawnPos.transform.position, spawnPos.transform.rotation);
                    go.GetComponent<Bullet>().speed = gun.speed;
                    go.GetComponent<Bullet>().maxDistance = gun.maxDistance;
                    go.GetComponent<Bullet>().bulletDmg = gun.damage;
                    go.SetActive(true);
                    currentAmmo--;
                }
            }
        }
        timer += Time.deltaTime;
        if(!reloading) ammo.text = $"{mags}  {currentAmmo}/{magSize}";
    }
    public void Reloading()
    {
        reloading = false;
    }
}
