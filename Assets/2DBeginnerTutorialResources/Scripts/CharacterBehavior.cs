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
			Debug.Log("�������");
			Vector2 fireDirection;
			fireDirection = Trans();
			attackbehavior.Attack(fireDirection, transform.position,prefab);
		}
    }
	//��ȡ��굱ǰ���겢ת��������������ļн�
	private Vector2 Trans()
	{
		mousepos = Input.mousePosition; //��ȡ��ǰ��Ļ�������
		mousepos = cam.ScreenToWorldPoint(mousepos); //ת��Ϊ��������
		Vector3 gunPos = transform.position;
		float fireangle;
		Vector2 targetDir = (mousepos - gunPos).normalized;
		fireangle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
		return targetDir;
	}
}
