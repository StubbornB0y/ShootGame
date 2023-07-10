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
			Debug.Log("�������");
			Vector2 fireDirection;
			fireDirection = Trans();
			//Ԥ����
			attackbehavior.Attack(fireDirection, transform.position,prefab);
		}
    }
	//��ȡ��굱ǰ���겢ת��������������ļн�
	private Vector2 Trans()
	{
		//��ȡ��ǰ��Ļ�������
		mousepos = Input.mousePosition;
		//ת��Ϊ��������
		mousepos = cam.ScreenToWorldPoint(mousepos); 
		Vector3 gunPos = transform.position;
		float fireangle;
		Vector2 targetDir = (mousepos - gunPos).normalized;
		fireangle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
		return targetDir;
	}
}
