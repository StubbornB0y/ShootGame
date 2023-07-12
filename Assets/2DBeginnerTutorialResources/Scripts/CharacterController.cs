using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Move_behavior;
using Attack_behavior;
using Abstract_behavior;
public class CharacterController : AbstractBehavior
{	
	public Camera cam;
	public float startdashTime = 0.5f;
	public int Blinks = 3;
	public float blinkpertime = 0.1f;
	private Vector3 mousepos;
	private Rigidbody2D rdb2;
	private Animator anim;
	private float dashTime = 0;
	private bool dashFlag = false;
	private Renderer myrenderer;
	//public GameObject prefab;
	//private AttackBehavior attackbehavior;
	//private IMoveBehavior movebehavior;
	//public float movespeed = 5f;
	// Start is called before the first frame update
	new private void Awake()
	{
		
	}
	new void Start()
    {
		base.Start();
		HealthBar.HealthCurrent = (int)health;
		HealthBar.HealthMax = (int)health;
		myrenderer = GetComponent<Renderer>();
		rdb2 = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
        moveBehavior = new PlayerMove();
		attackBehavior = new Shoot();
		dashBehavior = new PlayerDash();
    }

	// Update is called once per frame
	new void Update()
	{
		//base.Update();
		//当未执行冲刺操作时，执行冲刺操作后直接锁死所有操作
		if (dashFlag == false)
		{
			bool isrun;
			isrun = Move(ref rdb2, movespeed);
			anim.SetBool("Isrun", isrun);

			Vector2 fireDirection;
			fireDirection = Trans();
			Flip(fireDirection);
			if (Input.GetMouseButtonDown(0))
			{
				Debug.Log("左键按下");
				//预制体
				Attack(fireDirection, transform.position, prefab, attack);
			}
			//按下空格键时
			if (Input.GetKeyDown(KeyCode.Space))
			{

				Vector2 returndirection = Dash(ref rdb2, movespeed * 3, fireDirection.normalized);
				dashFlag = true;
				anim.SetBool("Isdash", dashFlag);
				dashTime = startdashTime;
				Flip(returndirection);
			}

		}
		else if(dashFlag == true)
		{
			dashTime -= Time.deltaTime;
			if (dashTime <= 0)
			{
				dashFlag = false;
				anim.SetBool("Isdash", dashFlag);
			}
		}
    }
	//根据鼠标的向量确定角色是否要反转
	private void Flip(Vector2 direction)
	{
		if (direction.x < 0)
		{
			transform.localRotation = Quaternion.Euler(0, 180, 0);
		}
		else if (direction.x > 0)
		{
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		}
	}
	//获取鼠标当前坐标并转换成人物相对鼠标的夹角
	private Vector2 Trans()
	{
		//获取当前屏幕鼠标坐标
		mousepos = Input.mousePosition;
		//转化为世界坐标
		mousepos = cam.ScreenToWorldPoint(mousepos); 
		Vector3 gunPos = transform.position;
		float fireangle;
		Vector2 targetDir = ((mousepos - gunPos).normalized);
		fireangle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
		return targetDir;
	}
	new public void Hurt(float damage)
	{
		base.Hurt(damage);
		if (health < 0)
		{
			health = 0;
		}
		HealthBar.HealthCurrent = (int)health;
		if(health == 0)
		{
			anim.SetTrigger("Die");
			Invoke(nameof(Dead), dashTime);
		}
		BlinkPlayer(Blinks, blinkpertime);
	}
	void BlinkPlayer(int numBlinks, float seconds)
	{
		StartCoroutine(DoBlinks(numBlinks, seconds));
	}
	IEnumerator DoBlinks(int numBlinks, float seconds)
	{
		for(int i=0; i < numBlinks * 2; i++)
		{
			myrenderer.enabled = !myrenderer.enabled;
			yield return new WaitForSeconds(seconds);
		}
		myrenderer.enabled = true;
	}
}
