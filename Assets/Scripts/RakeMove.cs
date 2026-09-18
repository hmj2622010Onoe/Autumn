using UnityEngine;
using UnityEngine.InputSystem;

public class RakeMove : MonoBehaviour
{
	Rigidbody2D rigid2D;
	int moveSwitch = 0;
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
		if (moveSwitch == 1)
		{
			rigid2D.AddForce(Vector2.up,ForceMode2D.Impulse);
		}
		if (moveSwitch == 2)
		{
			rigid2D.AddForce(Vector2.down, ForceMode2D.Impulse);
		}
		if (moveSwitch == 3)
		{
			rigid2D.AddForce(Vector2.right, ForceMode2D.Impulse);
		}
		if (moveSwitch == 4)
		{
			rigid2D.AddForce(Vector2.left, ForceMode2D.Impulse);
		}

		// àÍìxÇ…àÍï˚å¸Ç…ÇµÇ©êiÇ‹Ç»Ç¢ÇΩÇﬂÇÃêÿÇËë÷Ç¶ÇçÏÇÈ
		if (Keyboard.current.upArrowKey.wasPressedThisFrame) moveSwitch = 1;
		if (Keyboard.current.upArrowKey.wasReleasedThisFrame && moveSwitch == 1) moveSwitch = 0;

		if (Keyboard.current.downArrowKey.wasPressedThisFrame) moveSwitch = 2;
		if (Keyboard.current.downArrowKey.wasReleasedThisFrame && moveSwitch == 2) moveSwitch = 0;

		if (Keyboard.current.rightArrowKey.wasPressedThisFrame) moveSwitch = 3;
		if (Keyboard.current.rightArrowKey.wasReleasedThisFrame && moveSwitch == 3) moveSwitch = 0;
		
		if (Keyboard.current.leftArrowKey.wasPressedThisFrame) moveSwitch = 4;
		if (Keyboard.current.leftArrowKey.wasReleasedThisFrame && moveSwitch == 4) moveSwitch = 0;


	}
}
