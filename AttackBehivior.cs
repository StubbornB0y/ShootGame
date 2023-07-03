using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attack_behavior
{
    public abstract class AttackBehavior : Object
    {
        // Start is called before the first frame update
        public abstract void Attack(Vector2 fireDirection, Vector2 position) ;
    }
    public class Shoot : AttackBehavior
	{
        public GameObject bulletPrefab;
        override public void Attack(Vector2 fireDirection,Vector2 position)
		{
            float angle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg;    //依照传入的二维向量计算角度
            Vector3 eulerangle = new Vector3(0, 0, angle);      //转化为欧拉角
            bulletPrefab = Instantiate(bulletPrefab, position , Quaternion.Euler(eulerangle));  //创建子弹，设置初始位置和旋转

		}
	}
}
