using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abstract_behavior;

public class EnemyBehavior : AbstractBehavior
{
    public float flashtime;
    public GameObject bleedprefab;
    private SpriteRenderer sr;
    private Color origincolor;
    //private CharacterController character;
	// Start is called before the first frame update
	new public void Awake()
	{
        base.Awake();
        //character = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
		sr = GetComponent<SpriteRenderer>();
	}
	new public void Start()
    {
        base.Start();
       
        origincolor = sr.color;
    }

    // Update is called once per frame
    new public void Update()
    {
        base.Update();
    }

    public void FlashColor(float time)
	{
        sr.color = Color.red;
        Invoke("ResetColor", time);
	}
	public void ResetColor()
	{
        sr.color = origincolor;
	}
    new public void Hurt(float damage)
	{
        base.Hurt(damage);
        FlashColor(flashtime);
        Instantiate(bleedprefab, transform.position, Quaternion.identity);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
		{
            collision.GetComponent<CharacterController>().Hurt(attack);
		}
	}
}
