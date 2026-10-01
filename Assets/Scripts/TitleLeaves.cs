using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleLeaves : MonoBehaviour
{
	[SerializeField] GameObject leavesPrefab;
	[SerializeField] GameObject leavesManager;
	[SerializeField] int maxLeaves = 150;
	int leavesCount = 0;

	// 葉っぱを出現させる座標
	[SerializeField] float xPlus = 10f;
	[SerializeField] float xMinus = 10f;
	[SerializeField] float yPlus = 5f;
	[SerializeField] float yMinus = 5f;

	// タイトルにかぶらないよう葉っぱを出現させない範囲
	[SerializeField] float titleXp;
	[SerializeField] float titleXm;
	[SerializeField] float titleYp;
	[SerializeField] float titleYm;

	float leaveX = 0;
	float leaveY = 0;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		Application.targetFrameRate = 60;
	}

	// Update is called once per frame
	void Update()
	{
		// 葉っぱ出現
		for (int i = leavesCount; maxLeaves > i; i++)
		{
			leaveX = Random.Range(-xMinus, xPlus);
			leaveY = Random.Range(-yMinus, yPlus);
			while (leaveX < titleXp && leaveX > -titleXm && leaveY < titleYp && leaveY > -titleYm)
			{
				leaveX = Random.Range(-xMinus, xPlus);
				leaveY = Random.Range(-yMinus, yPlus);
			}

			GameObject leave = Instantiate(leavesPrefab);
			leave.transform.position = new Vector2(leaveX, leaveY);
			leave.transform.parent = leavesManager.transform;
			leavesCount++;
		}

		//if (onetime == true) 
		//{
		//	for (int i = 0; 20 > i; i++)
		//	{
		//		{ 
		//			leaveX = Random.Range(-1, 0.5f);
		//			leaveY = Random.Range(0.2f, 1);
		//		}

		//		GameObject leave = Instantiate(leavesPrefab);
		//		leave.transform.position = new Vector2(leaveX, leaveY);

		//		leavesCount++;
		//	}
		//	onetime = false;

		//}

		if (Keyboard.current.eKey.wasPressedThisFrame)
		{
			SceneManager.LoadScene("GameScene");
		}
	}
}
