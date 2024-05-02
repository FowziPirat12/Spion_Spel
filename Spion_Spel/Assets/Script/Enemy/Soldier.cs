using System.Collections;

using UnityEngine;

public class Soldier : Entity
{
    public float distance;
    public EnemyUI enemyUI;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        enemyUI = this.gameObject.GetComponent<EnemyUI>();
        hp = 170;
        dmg = 15;
    }

    // Update is called once per frame
    public override void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if(Vector3.Distance(player.transform.position, transform.position) <= 5f && !hit)
        {
            enemyUI.chase=false;
            StartCoroutine(Hit());
        }
        else if(Vector3.Distance(player.transform.position, transform.position) > 5f) enemyUI.chase=true;
        if(hp <= 0){
            Destroy(this.gameObject);
        }
    }

    IEnumerator Hit(){
        if(!hit)player.TakeDamage(dmg);
        hit = true;
        yield return new WaitForSeconds(1.5f);
        hit = false;
    }
}
