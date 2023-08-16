using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public int targetFrameRate = 60;
	
	public Sprite[] jellySpriteList;
	
	public string[] jellyNameList;
	
	public int[] jellyJelatinList;
	
	public int[] jellyGoldList;
	
	public int[] numGoldList;
	
	public int[] clickGoldList;
	
	public Vector3[] PointList;
	
	public RuntimeAnimatorController[] LevelAc;
	
	private void Start()
	{
		QualitySettings.vSyncCount = 0; // 关闭VSync
		Application.targetFrameRate = targetFrameRate;
	}
	
	public void ChangeAc(Animator anim, int level) {
		anim.runtimeAnimatorController = LevelAc[level - 1];
	}
}
