using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject timerText;
	[SerializeField] GameObject scoreText;

	int gameTimer = 120;
	int score = 0;

	int timer=0;
	//int startTime = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		Application.targetFrameRate = 60;
	}

    // Update is called once per frame
    void Update()
    {
		timerText.GetComponent<TextMeshProUGUI>().text = "Time:" + gameTimer.ToString();
		scoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + score.ToString();
		timer++;
		if (timer > 60)
		{
			timer -= 60;
			gameTimer--;
		}
    }

	public int Score 
	{
		get {  return score; }
		set { score = value; }
	}
}
