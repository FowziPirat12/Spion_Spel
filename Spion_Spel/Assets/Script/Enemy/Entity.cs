
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Player player;
    public float hp;
    [SerializeField]protected bool hit;
    protected int dmg;
    // Start is called before the first frame update
    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        hit = false;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(hp <= 0){
            Destroy(this.gameObject);
        }
    }
}
