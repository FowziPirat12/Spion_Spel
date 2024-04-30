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
    public float range;
    public Vector3 recoil;
    public float snappiness;
    public float inaccutacyDistance;

    [Header("Reloading")]
    public int currentAmmo;
    public int magSize;
    public float fireRate;

    [Header("Automatic")]
    public bool automatic;
    
    [Header("Typ")]
    public bool shotgun;
    public int bulletsPerShot;
}