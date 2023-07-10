using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Move_behavior;
using Attack_behavior;

namespace Abstract_behavior
{
	public abstract class AbstractBehavior : MonoBehaviour
	{
		public GameObject prefab;
		//public Camera cam;
		public float movespeed = 5f;
		//private Vector3 mousepos;
		private IMoveBehavior movebehavior;
		public IMoveBehavior moveBehavior
		{
			set
			{
				movebehavior = value;
			}
		}
		private AttackBehavior attackbehavior;
		public AttackBehavior attackBehavior
		{
			set
			{
				attackbehavior = value;
			}
		}
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

		}
		//根据鼠标的向量确定角色是否要反转

	}
}
