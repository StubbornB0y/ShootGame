using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attack_behavior
{
    public abstract class AttackBehavior : Object
    {
        // Start is called before the first frame update
        public abstract void Attack(Vector2 fireDirection=new Vector2() , Vector2 position=new Vector2(), GameObject bPrefab=null) ;
    }
    public class Shoot : AttackBehavior
	{
        public GameObject bulletPrefab;
        override public void Attack(Vector2 fireDirection,Vector2 position,GameObject bPrefab)
		{

            bulletPrefab = bPrefab;
            //���մ���Ķ�ά��������Ƕ�
            float angle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg;
            //ת��Ϊŷ����
            Vector3 eulerangle = new Vector3(0, 0, angle);
            //�����ӵ������ó�ʼλ�ú���ת
            bulletPrefab = Instantiate(bulletPrefab, position , Quaternion.Euler(eulerangle));  
            //��ȡԤ����󶨵Ľű�
            Bullet bullet = bulletPrefab.GetComponent<Bullet>();
			if (bullet != null)
			{
                bullet.Setvelocity(fireDirection);
			}
		}
	}
}
