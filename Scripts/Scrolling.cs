using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
	public float Speed = 0.1f;
	public float maxX = 7.0f; // 最大 X 坐标
	public float minX = -7.0f; // 最小 X 坐标
    // Update is called once per frame
    void Update()
    {
	    float moveDistance = Speed * Time.deltaTime;
	    // 更新物体的位置
	    transform.Translate(new Vector3(moveDistance, 0, 0));
	    if (transform.position.x > maxX)
	    {
		    transform.position = new Vector3(minX, transform.position.y, transform.position.z);
	    }
	    // 如果物体的 X 坐标小于 minX，将其重置为 maxX
	    else if (transform.position.x < minX)
	    {
		    transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
	    }
    }
}
