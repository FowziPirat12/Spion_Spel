using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGun", menuName = "Gun")]
public class GunTyps : ScriptableObject
{
    [Header("Info")]
    public new string name;

    [Header("shooting")]
    public float damage;
    public float speed;
    public float range;

    [Header("Reloading")]
    public int currentAmmo;
    public int magSize;
    public float fireRate;
    public float reloadTime;

    [Header("Automatic")]
    public bool automatic;
    
    [Header("Typ")]
    public bool multiShot;
    public int shoots;
}
