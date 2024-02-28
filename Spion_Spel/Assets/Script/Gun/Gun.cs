using UnityEngine.Events;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public UnityEvent onGunShoot;
    public float fireCooldown;

    public bool automatic;

    private float currentCooldown;
    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = fireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(automatic)
        {
            if(Input.GetMouseButton(0))
            {
                if(currentCooldown <= 0f)
                {
                    onGunShoot.Invoke();
                    currentCooldown = fireCooldown;
                }
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(currentCooldown <= 0f)
                {
                    onGunShoot.Invoke();
                    currentCooldown = fireCooldown;
                }
            }
        }
        currentCooldown -= Time.deltaTime;
    }
    
}
