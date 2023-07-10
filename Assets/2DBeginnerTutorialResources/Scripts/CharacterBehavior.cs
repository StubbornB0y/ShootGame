using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Move_behavior;
using Attack_behavior;
public class CharacterBehavior : MonoBehaviour
{	
	public GameObject prefab;
	public Camera cam;
	public float movespeed = 5f;
	private Vector3 mousepos;
	private IMoveBehavior movebehavior;
	private AttackBehavior attackbehavior;
	private Rigidbody2D rdb2;
	private Animator anim;
	// Start is called before the first frame update
	private void Awake()
	{
		
	}
	void Start()
    {
		rdb2 = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
        movebehavior = new PlayerMove();
		attackbehavior = new Shoot();
    }

    // Update is called once per frame
    void Update()
    {
		bool isrun;
		isrun=movebehavior.Move(ref rdb2,movespeed);
		anim.SetBool("Isrun", isrun);
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("左键按下");
			Vector2 fireDirection;
			fireDirection = Trans();
			//预制体
			attackbehavior.Attack(fireDirection, transform.position,prefab);
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
