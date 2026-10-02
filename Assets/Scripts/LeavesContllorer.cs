using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
	[SerializeField] Sprite leaves9;
	[SerializeField] Sprite leaves10;
	[SerializeField] Sprite leaves11;
	[SerializeField] Sprite leaves12;
	[SerializeField] Sprite leaves13;
	[SerializeField] Sprite leaves14;
	[SerializeField] Sprite leaves15;
	[SerializeField] Sprite leaves16;

	//[SerializeField] LeavesManager leavesManager;
	//public LeavesManager LeavesManager { get; set; }

	int randImg;
	float randColor;
	float randSize;
	float randSwingX;
	float randSwingY;
	int swingNum;
	int nowSwing=1;
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
		if (transform.position.y > 7)	// 回収されるとスコアを増やして削除する
		{
			//leavesManager.Score = leavesManager.Score + 1;
			int tempScore = transform.parent.gameObject.GetComponent<LeavesManager>().Score;
			transform.parent.gameObject.GetComponent<LeavesManager>().Score = tempScore + 100;
			int tempLeaves = transform.parent.gameObject.GetComponent<LeavesManager>().LeavesCount;
			transform.parent.gameObject.GetComponent<LeavesManager>().LeavesCount = tempLeaves - 1;
			Destroy(gameObject);
		}

		if (swing == false)	// クローンされたときに揺れる
		{
			transform.position = new Vector3(transform.position.x+randSwingX/nowSwing, transform.position.y + randSwingY / nowSwing);
			nowSwing++;
			if (nowSwing > swingNum)
			{
				randSwingX -= randSwingX / 2;
				randSwingY -= randSwingY / 2;
				nowSwing = 1;
				swing = true;
			}
			if (transform.position.y > 5) randSwingY = 0;
		}
		else
		{
			transform.position = new Vector3(transform.position.x - randSwingX / nowSwing, transform.position.y - randSwingY / nowSwing);
			nowSwing++;
			if (nowSwing > swingNum)
			{
				randSwingX -= randSwingX / 2;
				randSwingY -= randSwingY / 2;
				nowSwing = 1;
				swing = false;
			}
			if (transform.position.y > 5) randSwingY = 0;
		}

		if(randSwingX<0.1&&-0.1<randSwingX&& randSwingY < 0.1 && -0.1 < randSwingY)	// 揺れを抑える
		{
			randSwingX = 0;
			randSwingY = 0;
		}

		transform.localScale = new Vector3(randSize+randSwingX/2, randSize+ randSwingY/2, randSize);

		if (flag)	// クローンされたときのみ
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

			//if (Random.Range(0, 3) == 0)
			
			randSwingX = Random.Range(-1.0f, 1.0f);
			randSwingY = Random.Range(-1.0f, 1.0f);
			swingNum = Random.Range(20, 50);

			
			flag = false;
		}
		if (SceneManager.GetActiveScene().name == "ResultScene")
		{
			if (Keyboard.current.upArrowKey.wasPressedThisFrame)
			{
				rigid2D.AddForce(Vector2.up*Random.Range(0,5.0f), ForceMode2D.Impulse);
			}
			if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
			{
				rigid2D.AddForce(Vector2.up * Random.Range(0, 2.0f), ForceMode2D.Impulse);
				rigid2D.AddForce(Vector2.right * Random.Range(0, 2.0f), ForceMode2D.Impulse);
			}
			if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
			{
				rigid2D.AddForce(Vector2.up * Random.Range(0, 2.0f), ForceMode2D.Impulse);
				rigid2D.AddForce(Vector2.left * Random.Range(0, 2.0f), ForceMode2D.Impulse);
			}
		}
	}
}
