using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject child;
    public float timer;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0).gameObject;
        child.SetActive(false);
        time = Random.Range(20, 30);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > time) child.SetActive(true);
        timer += Time.deltaTime;
    }
}
