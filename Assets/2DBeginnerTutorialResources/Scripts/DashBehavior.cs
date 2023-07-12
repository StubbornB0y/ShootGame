using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDashBehavior 
{
    Vector2 Dash(ref Rigidbody2D rb2d, float speed, Vector2 Direction);
}

public class PlayerDash : IDashBehavior
{
    public Vector2 Dash(ref Rigidbody2D rb2d, float speed, Vector2 Direction)
	{
		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");
		if (moveX == 0 && moveY == 0)
		{
			Vector2 tempspeed = Direction;
			tempspeed.x *= speed;
			tempspeed.y *= speed;
			rb2d.velocity = tempspeed;
			return tempspeed;
		}
		else
		{
			Vector2 velocity = new(moveX * speed, moveY * speed);
			rb2d.velocity = velocity;
			return velocity;
		}
	}
}

