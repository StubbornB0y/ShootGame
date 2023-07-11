using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Move_behavior;
using Attack_behavior;
using Abstract_behavior;
public class CharacterController : AbstractBehavior
{	
	public Camera cam;
	private Vector3 mousepos;
	private Rigidbody2D rdb2;
	private Animator anim;
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
		rdb2 = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
        moveBehavior = new PlayerMove();
		attackBehavior = new Shoot();
    }

    // Update is called once per frame
    new void Update()
    {
		base.Update();
		bool isrun;
		isrun=Move(ref rdb2,movespeed);
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
		Vector2 targetDir = (mousepos - gunPos).normalized;
		fireangle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
		return targetDir;
	}
}
