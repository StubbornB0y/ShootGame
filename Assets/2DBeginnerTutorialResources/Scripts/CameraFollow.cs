using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //������ҵ�target
    public Transform target;
    //���ø���ƽ����
    public float smoothing;

    // Start is called before the first frame update
    void Start()
    {
        smoothing = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void FixedUpdate()
	{
		if (target != null)
		{
            //����󶨳ɹ�
			if (transform.position != target.position)
			{
                //�������һ��ƽ���ķ�ʽ�������������
                Vector3 targetpos = target.position;
                transform.position = Vector3.Lerp(transform.position, targetpos, smoothing);
			}
		}
	}
}
