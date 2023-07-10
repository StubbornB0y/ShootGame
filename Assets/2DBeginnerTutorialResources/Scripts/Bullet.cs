using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rdbd;
    public float destroyDistance = 50f;
    public float speed = 10f;
    private Vector3 startpos;
    private Vector2 direction;
	//{
    //    get { return direction; }
    //    set { direction = value; }
	//}
	/*
	void Awake()
	{
        rdbd = GetComponent<Rigidbody2D>();
        startpos = transform.position;
        rdbd.velocity = speed * transform.right;
    }
    */
	// Start is called before the first frame update
	void Start()
    {
        rdbd = GetComponent<Rigidbody2D>();
        startpos = transform.position;
        rdbd.velocity = speed * transform.right;
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

		}
	}
	public void Setvelocity(Vector2 firedirection)
	{
        direction = firedirection;
        rdbd.velocity = speed * direction;
    }
}
