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
		// ������
		currentRemainTime = fadeTime;
		spRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		// �c�莞�Ԃ��X�V
		currentRemainTime -= Time.deltaTime;

		if (currentRemainTime <= 0f)
		{
			// �c�莞�Ԃ������Ȃ����玩�����g������
			GameObject.Destroy(gameObject);
			return;
		}

		// �t�F�[�h�A�E�g
		float alpha = currentRemainTime / fadeTime;
		var color = spRenderer.color;
		color.a = alpha;
		spRenderer.color = color;
	}
}