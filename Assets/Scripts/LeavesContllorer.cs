using Unity.VisualScripting;
using UnityEngine;

public class LeavesContllorer : MonoBehaviour
{
	Rigidbody2D rigid2D;
	[SerializeField] SpriteRenderer spriteRenderer;

	[SerializeField] Sprite leaves1;
	[SerializeField] Sprite leaves2;
	[SerializeField] Sprite leaves3;
	[SerializeField] Sprite leaves4;
	[SerializeField] Sprite leaves5;
	[SerializeField] Sprite leaves6;
	[SerializeField] Sprite leaves7;
	[SerializeField] Sprite leaves8;

	int randImg;
	bool flag=true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		rigid2D = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
		if (flag)
		{
			rigid2D.rotation = Random.Range(0, 359);
			randImg = Random.Range(0, 8);
			if (randImg == 0) spriteRenderer.sprite = leaves1;
			if (randImg == 1) spriteRenderer.sprite = leaves2;
			if (randImg == 2) spriteRenderer.sprite = leaves3;
			if (randImg == 3) spriteRenderer.sprite = leaves4;
			if (randImg == 4) spriteRenderer.sprite = leaves5;
			if (randImg == 5) spriteRenderer.sprite = leaves6;
			if (randImg == 6) spriteRenderer.sprite = leaves7;
			if (randImg == 7) spriteRenderer.sprite = leaves8;
			flag = false;
		}
	}
}
