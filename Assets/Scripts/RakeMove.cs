using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class RakeMove : MonoBehaviour
{
	Rigidbody2D rigid2D;

	[SerializeField]int moveSpeed = 20;			// 動くスピード
	[SerializeField]float rotateSpeed = 0.2f;   // 向くスピード
	[SerializeField] int rotateMar = 90;        // どこまでの範囲なら回転できるようにするか

	[SerializeField]CircleCollider2D col1;
	[SerializeField]CircleCollider2D col2;
	[SerializeField]CircleCollider2D col3;
	[SerializeField]CircleCollider2D col4;

	bool wKey=false;
	bool aKey=false;
	bool sKey=false;
	bool dKey=false;

	bool shiftKey=false;
	//float rakeX = 0;
	//float rakeY = -5;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		rigid2D = GetComponent<Rigidbody2D>();
		Application.targetFrameRate = 60;
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
			//if (wKey == false && aKey == false && sKey == false && dKey == false)
				if (shiftKey == false)
				{ rigid2D.AddForce(Vector2.up * moveSpeed, ForceMode2D.Impulse); }
			else { rigid2D.AddForce(Vector2.up * (moveSpeed / 2), ForceMode2D.Impulse); }
		}
		if (Keyboard.current.downArrowKey.IsPressed())
		{
			//if (wKey == false && aKey == false && sKey == false && dKey == false)
			if (shiftKey == false)
			{ rigid2D.AddForce(Vector2.down * moveSpeed, ForceMode2D.Impulse); }
			else { rigid2D.AddForce(Vector2.down * (moveSpeed / 2), ForceMode2D.Impulse); }
		}
		if (Keyboard.current.rightArrowKey.IsPressed())
		{
			//if (wKey == false && aKey == false && sKey == false && dKey == false)
			if (shiftKey == false)
			{ rigid2D.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse); }
			else { rigid2D.AddForce(Vector2.right * (moveSpeed / 2), ForceMode2D.Impulse); }
		}
		if (Keyboard.current.leftArrowKey.IsPressed())
		{
			//if (wKey == false && aKey == false && sKey == false && dKey == false)
			if (shiftKey == false)
			{ rigid2D.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse); }
			else { rigid2D.AddForce(Vector2.left * (moveSpeed / 2), ForceMode2D.Impulse); }
		}

		// WASDキーでの回転
		if (wKey == true && aKey == false && dKey == false)
		{
			if (rigid2D.rotation < 270 + rotateMar && rigid2D.rotation > 180) rigid2D.rotation -= rotateSpeed;
			else if (rigid2D.rotation > 90 - rotateMar) rigid2D.rotation += rotateSpeed;
		}
		if (aKey == true && wKey == false && sKey == false)
		{
			if (rigid2D.rotation < rotateMar || rigid2D.rotation > 270) rigid2D.rotation -= rotateSpeed;
			else if (rigid2D.rotation > 180 - rotateMar) rigid2D.rotation += rotateSpeed;
		}
		if (sKey == true && aKey == false && dKey == false)
		{
			if (rigid2D.rotation < 90 + rotateMar) rigid2D.rotation -= rotateSpeed;
			else if (rigid2D.rotation > 270 - rotateMar) rigid2D.rotation += rotateSpeed;
		}
		if (dKey == true && wKey == false && sKey == false)
		{
			if (rigid2D.rotation < 180 + rotateMar && rigid2D.rotation > 90) rigid2D.rotation -= rotateSpeed;
			else if (rigid2D.rotation > 360 - rotateMar || rigid2D.rotation < 90) rigid2D.rotation += rotateSpeed;
		}

		// 斜め回転
		if (wKey == true && aKey == true && dKey == false)
		{
			if (rigid2D.rotation < 315 + rotateMar && rigid2D.rotation > 225) rigid2D.rotation -= rotateSpeed;
			else if (rigid2D.rotation > 135 - rotateMar) rigid2D.rotation += rotateSpeed;
		}
		if (wKey == true && dKey == true && aKey == false)
		{
			if (rigid2D.rotation < 225 + rotateMar && rigid2D.rotation > 135) rigid2D.rotation -= rotateSpeed;
			else if (rigid2D.rotation > 45 - rotateMar) rigid2D.rotation += rotateSpeed;
		}
		if (sKey == true && aKey == true && dKey == false)
		{
			if (rigid2D.rotation < 45 + rotateMar||rigid2D.rotation>315) rigid2D.rotation -= rotateSpeed;
			else if (rigid2D.rotation > 225 - rotateMar && rigid2D.rotation < 315) rigid2D.rotation += rotateSpeed;
		}
		if (sKey == true && dKey == true && aKey == false)
		{
			if (rigid2D.rotation < 135 + rotateMar && rigid2D.rotation > 45) rigid2D.rotation -= rotateSpeed;
			else if (rigid2D.rotation > 315 - rotateMar || rigid2D.rotation < 45) rigid2D.rotation += rotateSpeed;
		}

		//if (wKey == false && aKey == false && sKey == false && dKey == false)
		if(shiftKey==false)
		{
			col1.enabled = false;
			col2.enabled = false;
			col3.enabled = false;
			col4.enabled = false;
		}
		else
		{
			col1.enabled = true;
			col2.enabled = true;
			col3.enabled = true;
			col4.enabled = true;
		}


		// キー入力確認
		if (Keyboard.current.wKey.IsPressed()) wKey = true;
		else wKey = false;
		if (Keyboard.current.aKey.IsPressed()) aKey = true;
		else aKey = false;
		if (Keyboard.current.sKey.IsPressed()) sKey = true;
		else sKey = false;
		if (Keyboard.current.dKey.IsPressed()) dKey = true;
		else dKey = false;
		if (Keyboard.current.shiftKey.IsPressed()) shiftKey = true;
		else shiftKey = false;

		// 回転の度数リセット処理
		if (rigid2D.rotation > 360) rigid2D.rotation -= 360;   
		if (rigid2D.rotation < 0) rigid2D.rotation += 360;
	}
}
