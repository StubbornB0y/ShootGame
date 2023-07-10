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
		// Start is called before the first frame update
		private void Awake()
		{

		}
		public void Start()
		{
			
		}

		// Update is called once per frame
		public void Update()
		{
			if (health <= 0)
			{
				Destroy(gameObject);
			}
		}
		public void Attack(Vector2 fireDirection, Vector2 position, GameObject bPrefab)
		{
			attackbehavior.Attack(fireDirection, position, bPrefab);
		}
		public bool Move(ref Rigidbody2D rb2d, float speed)
		{
			return movebehavior.Move(ref rb2d, speed);
		}
		public void hurt(float damage)
		{
			health -= damage;
		}
	}
}
