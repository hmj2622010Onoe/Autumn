using UnityEngine;
using UnityEngine.InputSystem;

public class RakeMove : MonoBehaviour
{
	Rigidbody2D rigid2D;
	int moveSwitch = 0;
	int moveSpeed = 20;
	float rotateSpeed = 0.5f;
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
		//transform.position = new Vector3(rakeX,rakeY);
		rigid2D.linearVelocity = Vector2.zero;
		rigid2D.angularVelocity = 0f;
		if (moveSwitch == 1)
		{
			rigid2D.AddForce(Vector2.up*moveSpeed,ForceMode2D.Impulse);
		}
		if (moveSwitch == 2)
		{
			rigid2D.AddForce(Vector2.down*moveSpeed, ForceMode2D.Impulse);
		}
		if (moveSwitch == 3)
		{
			rigid2D.AddForce(Vector2.right*moveSpeed, ForceMode2D.Impulse);
		}
		if (moveSwitch == 4)
		{
			rigid2D.AddForce(Vector2.left*moveSpeed, ForceMode2D.Impulse);
		}

		// 一度に一方向にしか進まないための切り替えを作る
		if (Keyboard.current.upArrowKey.wasPressedThisFrame) moveSwitch = 1;
		if (Keyboard.current.upArrowKey.wasReleasedThisFrame && moveSwitch == 1) moveSwitch = 0;

		if (Keyboard.current.downArrowKey.wasPressedThisFrame) moveSwitch = 2;
		if (Keyboard.current.downArrowKey.wasReleasedThisFrame && moveSwitch == 2) moveSwitch = 0;

		if (Keyboard.current.rightArrowKey.wasPressedThisFrame) moveSwitch = 3;
		if (Keyboard.current.rightArrowKey.wasReleasedThisFrame && moveSwitch == 3) moveSwitch = 0;
		
		if (Keyboard.current.leftArrowKey.wasPressedThisFrame) moveSwitch = 4;
		if (Keyboard.current.leftArrowKey.wasReleasedThisFrame && moveSwitch == 4) moveSwitch = 0;

		// WASDキーでの回転処理　見た目の都合上、上下左右とも反対の方向に回転する
		if (Keyboard.current.wKey.IsPressed())
		{
			if (rigid2D.rotation < 280&&rigid2D.rotation>180) rigid2D.rotation -= rotateSpeed;
			else if (rigid2D.rotation > 80) rigid2D.rotation += rotateSpeed;
		}
		if (Keyboard.current.dKey.IsPressed())
		{
			if (rigid2D.rotation < 190) rigid2D.rotation -= rotateSpeed;
			else if (rigid2D.rotation > 350||rigid2D.rotation<90 ) rigid2D.rotation += rotateSpeed;
		}
		if (Keyboard.current.sKey.IsPressed())
		{
			if (rigid2D.rotation > 260) rigid2D.rotation -= rotateSpeed;
			else if (rigid2D.rotation < 100) rigid2D.rotation += rotateSpeed;
		}
		if (Keyboard.current.aKey.IsPressed())
		{
			if (rigid2D.rotation > 270||rigid2D.rotation<10) rigid2D.rotation -= rotateSpeed;
			else if (rigid2D.rotation > 170) rigid2D.rotation += rotateSpeed;
		}

		if (rigid2D.rotation > 360) rigid2D.rotation -= 360;	// 回転のリセット処理
	}
}
