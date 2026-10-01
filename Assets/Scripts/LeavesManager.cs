using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LeavesManager : MonoBehaviour
{
	[SerializeField] GameObject leavesPrefab;
	[SerializeField] GameObject leavesResultPrefab;

	[SerializeField]int maxLeaves = 200;
	[SerializeField]int leavesCount = 0;
	public int LeavesCount { get { return leavesCount; } set { leavesCount = value; } }

	[SerializeField] float xPlus=10f;
	[SerializeField] float xMinus=10f;
	[SerializeField] float yPlus=5f;
	[SerializeField] float yMinus=5f;

	int leavesResultCount=0;

	[SerializeField] GameObject timerText;
	[SerializeField] GameObject scoreText;

	[SerializeField]int gameTimer = 120;
	[SerializeField]static int score = 0;
	public int Score {  get { return score; } set { score = value; } }

	int timer = 0;

	bool leavesClone = true;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		Application.targetFrameRate = 60;
	}

    // Update is called once per frame
    void Update()
    {
		if (timerText) { timerText.GetComponent<TextMeshProUGUI>().text = "Time:" + gameTimer.ToString(); }
		if (scoreText&& SceneManager.GetActiveScene().name != "ResultScene") { scoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + score.ToString(); }
		if (SceneManager.GetActiveScene().name == "GameScene")timer++;
		if (timer >= 60)
		{
			timer -= 60;
			gameTimer--;
			if (gameTimer == 60) { leavesClone = true; maxLeaves = 250; }
			if (gameTimer == 30) { leavesClone = true; maxLeaves = 300; }
			if (Random.Range(0, 5) == 0 && leavesCount != maxLeaves) 
			{
				int randClone= Random.Range(1, 5);
				if (leavesCount + randClone > maxLeaves) randClone = maxLeaves - leavesCount;
				for (int i = 0; randClone > i; i++)
				{
					GameObject leave = Instantiate(leavesPrefab);
					leave.transform.position = new Vector2(Random.Range(-xMinus, xPlus), Random.Range(-yMinus, yPlus));
					leavesCount++;
					//leave.GetComponent<LeavesContllorer>().LeavesManager = gameObject.GetComponent<LeavesManager>();
					leave.transform.parent = gameObject.transform;
				}
			}
			if (gameTimer == 0)
			{
				SceneManager.LoadScene("ResultScene");
			}
		}

		// クローンOKなら最大数までクローンする
		if (leavesClone == true)
		{
			for (int i = leavesCount; maxLeaves > i; i++)
			{
				GameObject leave = Instantiate(leavesPrefab);
				leave.transform.position = new Vector2(Random.Range(-xMinus, xPlus), Random.Range(-yMinus, yPlus));
				leavesCount++;
				//leave.GetComponent<LeavesContllorer>().LeavesManager = gameObject.GetComponent<LeavesManager>();
				leave.transform.parent = gameObject.transform;
			}
			leavesClone = false;
		}

		if(SceneManager.GetActiveScene().name == "ResultScene")
		{
			if (leavesResultCount < score / 100)
			{
				GameObject leaveResult = Instantiate(leavesResultPrefab);
				leaveResult.transform.position = new Vector2(Random.Range(Random.Range(-5, 0), Random.Range(0, 5)), 5);
				leavesResultCount++;
			}
			if (leavesResultCount >= score / 100)
			{
				scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
				if (Keyboard.current.tKey.wasPressedThisFrame)
				{
					score = 0;
					SceneManager.LoadScene("TitleScene");
				}
				if (Keyboard.current.rKey.wasPressedThisFrame)
				{
					score = 0;
					SceneManager.LoadScene("GameScene");
				}
			}
		}
	}
}
