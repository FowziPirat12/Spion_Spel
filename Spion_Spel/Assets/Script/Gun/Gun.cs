<<<<<<< Updated upstream
using UnityEngine.Events;
=======
using System.Collections;
using TMPro;
using Unity.VisualScripting;
>>>>>>> Stashed changes
using UnityEngine;

public class Gun : MonoBehaviour
{
<<<<<<< Updated upstream
    public UnityEvent onGunShoot;
    public float fireCooldown;

    public bool automatic;

    private float currentCooldown;
    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = fireCooldown;
=======
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
    // Start is called before the first frame update
    void Start()
    {
        mags = 2;
        currentAmmo = gun.currentAmmo;
        magSize = gun.magSize;
        ammo.text = $"{currentAmmo}/{magSize}";
        fireRate = gun.fireRate;
        shoots = gun.shoots;
        automatic = gun.automatic;
        multiShot = gun.multiShot;
        reloadTime = gun.reloadTime;
        timer = 0;
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
=======
        if(Input.GetKeyDown(KeyCode.R) && !reloading && mags > 0)
        {
            reloading = true;
            StartCoroutine(Reloading());
            ammo.text = "Reloading";
            mags--;
        }
        
>>>>>>> Stashed changes
        if(automatic)
        {
            if(Input.GetMouseButton(0))
            {
                if(currentCooldown <= 0f)
                {
<<<<<<< Updated upstream
                    onGunShoot.Invoke();
                    currentCooldown = fireCooldown;
=======
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
>>>>>>> Stashed changes
                }
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(currentCooldown <= 0f)
                {
<<<<<<< Updated upstream
                    onGunShoot.Invoke();
                    currentCooldown = fireCooldown;
                }
            }
        }
        currentCooldown -= Time.deltaTime;
=======
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
        if(!reloading)ammo.text = $"{mags}  {currentAmmo}/{magSize}";
    }
    IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = magSize;
        reloading = false;
>>>>>>> Stashed changes
    }
    
}
