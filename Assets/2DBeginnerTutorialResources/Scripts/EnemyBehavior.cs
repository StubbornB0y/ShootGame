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
	// Start is called before the first frame update
	new public void Awake()
	{
        base.Awake();
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
    
}
