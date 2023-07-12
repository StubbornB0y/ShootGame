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
		public GameObject deadprefab;
		//public Camera cam;
		public float movespeed = 5f;
		public float attack = 1f;
		public float health = 10f;
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
		private IDashBehavior dashbehavior;
		public IDashBehavior dashBehavior
		{
			set
			{
				dashbehavior = value;
			}
		}
		// Start is called before the first frame update
		public void Awake()
		{

		}
		public void Start()
		{
			
		}

		// Update is called once per frame
		public void Update()
		{
			Dead();
		}
		public void Attack(Vector2 fireDirection, Vector2 position, GameObject bPrefab, float damage = 1f)
		{
			attackbehavior.Attack(fireDirection, position, bPrefab, damage);
		}
		public bool Move(ref Rigidbody2D rb2d, float speed)
		{
			return movebehavior.Move(ref rb2d, speed);
		}
		public Vector2 Dash(ref Rigidbody2D rb2d, float speed, Vector2 Direction)
		{
			return dashbehavior.Dash(ref rb2d, speed, Direction);
		}
		public void Hurt(float damage)
		{
			health -= damage;
		}
		public void Dead()
		{
			if (health <= 0)
			{
				Destroy(gameObject);
				Instantiate(deadprefab, transform.position, Quaternion.identity);
			}
		}

	}
}
