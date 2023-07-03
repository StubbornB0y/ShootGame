using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Move_behavior
{
    public interface IMoveBehavior
	{
		Vector2 Move(Vector2 position);
    }
    public class PlayerMove : IMoveBehavior
	{
		private float speed = 5f;
		public Vector2 Move(Vector2 position)
		{
			float moveX = Input.GetAxisRaw("Horizontal");
			float moveY = Input.GetAxisRaw("Vertical");
			Vector2 positiontemp = position;
			positiontemp.x += moveX * speed * Time.deltaTime;
			positiontemp.y += moveY * speed * Time.deltaTime;
			return positiontemp;
		}
	}
}
