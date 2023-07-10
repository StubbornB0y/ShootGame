using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Move_behavior
{
    public interface IMoveBehavior
	{
		bool Move(ref Rigidbody2D rb2d,float speed);
    }
    public class PlayerMove : IMoveBehavior
	{
		//private float speed = 5f;
		public bool Move(ref Rigidbody2D rb2d,float speed)
		{
			float moveX = Input.GetAxisRaw("Horizontal");
			float moveY = Input.GetAxisRaw("Vertical");
			Vector2 velocity = new Vector2(moveX * speed, moveY * speed);
			rb2d.velocity = velocity;
			if(moveX==0 && moveY == 0)
			{
				return false;
			}
			else
			{
				return true;
			}
			//positiontemp.x += moveX * speed * Time.deltaTime;
			//positiontemp.y += moveY * speed * Time.deltaTime;
		}
	}
}
