using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrint : MonoBehaviour
{
	public float fadeTime = 1f;

	private float currentRemainTime;
	private SpriteRenderer spRenderer;

	// Use this for initialization
	void Start()
	{
		// 初期化
		currentRemainTime = fadeTime;
		spRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		// 残り時間を更新
		currentRemainTime -= Time.deltaTime;

		if (currentRemainTime <= 0f)
		{
			// 残り時間が無くなったら自分自身を消滅
			GameObject.Destroy(gameObject);
			return;
		}

		// フェードアウト
		float alpha = currentRemainTime / fadeTime;
		var color = spRenderer.color;
		color.a = alpha;
		spRenderer.color = color;
	}
}