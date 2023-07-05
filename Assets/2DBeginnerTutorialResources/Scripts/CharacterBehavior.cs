using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Move_behavior;
using Attack_behavior;
public class CharacterBehavior : MonoBehaviour
{
	public Camera cam;
	private Vector3 mousepos;
	private IMoveBehavior movebehavior;
	private AttackBehavior attackbehavior;
	public GameObject prefab;
	// Start is called before the first frame update
	private void Awake()
	{
		
	}
	void Start()
    {
        movebehavior = new PlayerMove();
		attackbehavior = new Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = movebehavior.Move(transform.position);
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("左键按下");
			Vector2 fireDirection;
			fireDirection = Trans();
			attackbehavior.Attack(fireDirection, transform.position,prefab);
		}
    }
	//获取鼠标当前坐标并转换成人物相对鼠标的夹角
	private Vector2 Trans()
	{
		mousepos = Input.mousePosition; //获取当前屏幕鼠标坐标
		mousepos = cam.ScreenToWorldPoint(mousepos); //转化为世界坐标
		Vector3 gunPos = transform.position;
		float fireangle;
		Vector2 targetDir = (mousepos - gunPos).normalized;
		fireangle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
		return targetDir;
	}
}
