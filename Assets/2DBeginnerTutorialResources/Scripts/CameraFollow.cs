using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //调用玩家的target
    public Transform target;
    //设置跟随平滑度
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
            //如果绑定成功
			if (transform.position != target.position)
			{
                //将相机以一个平滑的方式跟随在玩家身上
                Vector3 targetpos = target.position;
                transform.position = Vector3.Lerp(transform.position, targetpos, smoothing);
			}
		}
	}
}
