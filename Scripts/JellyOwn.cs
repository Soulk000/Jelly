using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyDemo : MonoBehaviour
{
	public float moveSpeed = 2f;
	public float moveDistance = 1f;
	public Vector2 xBoundary = new Vector2(-5f, 5f);
	public Vector2 yBoundary = new Vector2(-2f, 1f);

	private Vector3 startPosition;
	private Vector3 targetPosition;
	
	private bool isMoving = false;

	//private float delayTimer = 3f;

	private void Start()
	{
		// 获取初始位置
		startPosition = transform.position;
		// 初始目标位置为起始位置
		targetPosition = startPosition;
		// 启动协程，实现延迟移动
		StartCoroutine(MoveWithDelayRoutine());
	}

	private void Update()
	{
		if (isMoving)
		{
			// 计算移动的步长
			float step = moveSpeed * Time.deltaTime;
			// 使用 MoveTowards 方法逐渐移动到目标位置
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

			// 如果已经到达目标位置，停止移动
			if (transform.position == targetPosition)
			{
				isMoving = false;
			}
		}
	}

	private System.Collections.IEnumerator MoveWithDelayRoutine()
	{
		// 初始等待3秒
		yield return new WaitForSeconds(3f);

		while (true)
		{
			// 每隔3秒执行以下代码

			yield return new WaitForSeconds(3f);

			// 计算下一个目标位置，范围在一定的移动距离内
			targetPosition = new Vector3(
				Random.Range(startPosition.x - moveDistance, startPosition.x + moveDistance),
				Random.Range(startPosition.y - moveDistance, startPosition.y + moveDistance),
				startPosition.z
			);

			// 确保目标位置在指定的边界范围内
			targetPosition.x = Mathf.Clamp(targetPosition.x, xBoundary.x, xBoundary.y);
			targetPosition.y = Mathf.Clamp(targetPosition.y, yBoundary.x, yBoundary.y);

			// 开始移动
			isMoving = true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Boundary"))
		{
			// 碰到边界时，反向移动
			targetPosition = startPosition + (startPosition - targetPosition);
		}
	}
}
