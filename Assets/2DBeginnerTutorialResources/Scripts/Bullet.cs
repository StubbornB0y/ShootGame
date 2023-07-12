using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1f;
    Rigidbody2D rdbd;
    public float destroyDistance = 50f;
    public float speed = 10f;
    private Vector3 startpos;
    private Vector2 direction;
    private BoxCollider2D coll2d;
	//{
    //    get { return direction; }
    //    set { direction = value; }
	//}

	//Debug:不将这三行代码放在Awake里会导致报一个很奇怪的错误
	void Awake()
	{
        rdbd = GetComponent<Rigidbody2D>();
        coll2d = GetComponent<BoxCollider2D>();
        startpos = transform.position;
        rdbd.velocity = speed * transform.right;
    }
    
	// Start is called before the first frame update
    
    
	void Start()
    {
        //rdbd = GetComponent<Rigidbody2D>();
        //startpos = transform.position;
        //rdbd.velocity = speed * transform.right;
    }
    
    // Update is called once per frame
    void Update()
    {
        float distance = (transform.position - startpos).sqrMagnitude;
        if (distance >= destroyDistance)
		{
            Destroy(gameObject);
		}
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
            Debug.Log("hit");
            collision.GetComponent<EnemyBehavior>().Hurt(damage);
            Destroy(gameObject);
		}
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall");
            //collision.GetComponent<EnemyBehavior>().Hurt(damage);
            Destroy(gameObject);
        }
    }
	public void Setvelocity(Vector2 firedirection)
	{
        direction = firedirection;
        rdbd.velocity = speed * direction;
    }
}
