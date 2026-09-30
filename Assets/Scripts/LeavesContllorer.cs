using Unity.VisualScripting;
using UnityEngine;

public class LeavesContllorer : MonoBehaviour
{
	Rigidbody2D rigid2D;
	[SerializeField] SpriteRenderer spriteRenderer;

	//[SerializeField]GameObject dustPan;
	//public GameObject dustPan{ get; set; }

	[SerializeField] Sprite leaves1;
	[SerializeField] Sprite leaves2;
	[SerializeField] Sprite leaves3;
	[SerializeField] Sprite leaves4;
	[SerializeField] Sprite leaves5;
	[SerializeField] Sprite leaves6;
	[SerializeField] Sprite leaves7;
	[SerializeField] Sprite leaves8;
	[SerializeField] Sprite leaves9;
	[SerializeField] Sprite leaves10;
	[SerializeField] Sprite leaves11;
	[SerializeField] Sprite leaves12;
	[SerializeField] Sprite leaves13;
	[SerializeField] Sprite leaves14;
	[SerializeField] Sprite leaves15;
	[SerializeField] Sprite leaves16;

	int randImg;
	float randColor;
	float randSize;
	float randSwingX;
	float randSwingY;
	int swingNum;
	int nowSwing=0;
	bool flag = true;
	bool swing = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		rigid2D = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
		if (transform.position.y > 7) 
		{
			Destroy(gameObject);
		}

		if (swing == false)
		{
			transform.position = new Vector3(transform.position.x+randSwingX/nowSwing, transform.position.y + randSwingY / nowSwing);
			nowSwing++;
			if (nowSwing > swingNum)
			{
				randSwingX -= randSwingX / 2;
				randSwingY -= randSwingY / 2;
				nowSwing = 0;
				swing = true;
			}
		}
		else
		{
			transform.position = new Vector3(transform.position.x - randSwingX / nowSwing, transform.position.y - randSwingY / nowSwing);
			nowSwing++;
			if (nowSwing > swingNum)
			{
				randSwingX -= randSwingX / 2;
				randSwingY -= randSwingY / 2;
				nowSwing = 0;
				swing = false;
			}
		}

		if(randSwingX<0.2&&-0.2<randSwingX&& randSwingY < 0.2 && -0.2 < randSwingY)
		{
			randSwingX = 0;
			randSwingY = 0;
		}

		transform.localScale = new Vector3(randSwingX, randSize, randSize);

		if (flag)
		{
			rigid2D.rotation = Random.Range(0, 359);    // 向きを変更
			randImg = Random.Range(0, 16);  // 画像を変更
			if (randImg == 0) spriteRenderer.sprite = leaves1;
			if (randImg == 1) spriteRenderer.sprite = leaves2;
			if (randImg == 2) spriteRenderer.sprite = leaves3;
			if (randImg == 3) spriteRenderer.sprite = leaves4;
			if (randImg == 4) spriteRenderer.sprite = leaves5;
			if (randImg == 5) spriteRenderer.sprite = leaves6;
			if (randImg == 6) spriteRenderer.sprite = leaves7;
			if (randImg == 7) spriteRenderer.sprite = leaves8;
			if (randImg == 8) spriteRenderer.sprite = leaves9;
			if (randImg == 9) spriteRenderer.sprite = leaves10;
			if (randImg == 10) spriteRenderer.sprite = leaves11;
			if (randImg == 11) spriteRenderer.sprite = leaves12;
			if (randImg == 12) spriteRenderer.sprite = leaves13;
			if (randImg == 13) spriteRenderer.sprite = leaves14;
			if (randImg == 14) spriteRenderer.sprite = leaves15;
			if (randImg == 15) spriteRenderer.sprite = leaves16;

			randColor = Random.Range(0.5f, 1.2f);   // 色の濃さを変更
			spriteRenderer.color = new Color(randColor, randColor, randColor);

			randSize = Random.Range(0.8f, 1.2f);    // 大きさを変更
			transform.localScale = new Vector3(randSize, randSize, randSize);

			if (Random.Range(0, 2) == 0)    // 画像を反転するかどうか
			{
				spriteRenderer.flipX = true;
			}

			randSwingX = Random.Range(-1.0f, 1.0f);
			randSwingY = Random.Range(-1.0f, 1.0f);
			swingNum = Random.Range(20, 50);

			flag = false;
		}
	}

	/*private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == dustPan)
		{
			spriteRenderer.sprite = leaves1;
			gameObject.layer = LayerMask.NameToLayer("Clean");
		}
	}*/
}
