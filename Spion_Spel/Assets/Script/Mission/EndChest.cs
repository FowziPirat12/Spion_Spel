using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndChest : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.position, transform.position) <= 1.5f && Input.GetKeyDown(KeyCode.E)) SceneManager.LoadScene(1);;
    }
}
