using System.Collections;

using UnityEngine;

public class Scientest : Entity
{
    public float distance;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        hp = 100;
        dmg = 10;
    }

    // Update is called once per frame
    public override void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if(Vector3.Distance(player.transform.position, transform.position) <= 1.5f && !hit)
        {
            StartCoroutine(Hit());
        }
        if(hp <= 0){
            Destroy(this.gameObject);
        }
    }

    IEnumerator Hit(){
        if(!hit)player.TakeDamage(dmg);
        hit = true;
        yield return new WaitForSeconds(3);
        hit = false;
    }
}
