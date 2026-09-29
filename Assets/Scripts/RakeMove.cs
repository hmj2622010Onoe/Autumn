using UnityEngine;
using UnityEngine.InputSystem;

public class RakeMove : MonoBehaviour
{
	Rigidbody2D rigid2D;

	[SerializeField]int moveSpeed = 20;			// 上下左右に動くスピード
	[SerializeField]float rotateSpeed = 0.2f;   // 上下左右に向くスピード
	[SerializeField] int rotateMar = 90;		// どこまでの範囲なら回転できるようにするか
	//float rakeX = 0;
	//float rakeY = -5;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		rigid2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		// キー入力が止まった後に動かないように勢いをリセットする
		rigid2D.linearVelocity = Vector2.zero;
		rigid2D.angularVelocity = 0f;

		// 矢印キーでの移動
		if (Keyboard.current.upArrowKey.IsPressed())
		{
			rigid2D.AddForce(Vector2.up * moveSpeed, ForceMode2D.Impulse);
		}
		if (Keyboard.current.downArrowKey.IsPressed())
		{
			rigid2D.AddForce(Vector2.down * moveSpeed, ForceMode2D.Impulse);
		}
		if (Keyboard.current.rightArrowKey.IsPressed())
		{
			rigid2D.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);
		}
		if (Keyboard.current.leftArrowKey.IsPressed())
		{
			rigid2D.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);
		}

		// WASDキーでの回転
		if (Keyboard.current.wKey.IsPressed())
		{
			if (rigid2D.rotation < 270 + rotateMar && rigid2D.rotation > 180) rigid2D.rotation -= rotateSpeed;
			else if (rigid2D.rotation > 90 - rotateMar) rigid2D.rotation += rotateSpeed;
		}
		if (Keyboard.current.dKey.IsPressed())
		{
			if (rigid2D.rotation < 180 + rotateMar && rigid2D.rotation > 90) rigid2D.rotation -= rotateSpeed;
			else if (rigid2D.rotation > 360 - rotateMar || rigid2D.rotation < 90) rigid2D.rotation += rotateSpeed;
		}
		if (Keyboard.current.sKey.IsPressed())
		{
			if (rigid2D.rotation < 90 + rotateMar) rigid2D.rotation -= rotateSpeed;
			else if (rigid2D.rotation > 270 - rotateMar) rigid2D.rotation += rotateSpeed;
		}
		if (Keyboard.current.aKey.IsPressed())
		{
			if (rigid2D.rotation < rotateMar || rigid2D.rotation > 270) rigid2D.rotation -= rotateSpeed;
			else if (rigid2D.rotation > 180 - rotateMar) rigid2D.rotation += rotateSpeed;
		}


		// 回転の度数リセット処理
		if (rigid2D.rotation > 360) rigid2D.rotation -= 360;   
		if (rigid2D.rotation < 0) rigid2D.rotation += 360;
	}
}
