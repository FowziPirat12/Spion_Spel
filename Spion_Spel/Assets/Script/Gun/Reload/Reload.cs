using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public int maxCarry;
    public float reloadTime;
    public TMP_Text text;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int Reloading(int ammo)
    {
        text.text = "Reloading";
        if(reloadTime > timer)
        {
            timer += Time.deltaTime;
        }
        timer = 0;
        return ammo;
    }
}
