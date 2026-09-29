using UnityEngine;

public class LeavesManager : MonoBehaviour
{
	[SerializeField] GameObject leavesPrefab;

	int maxLeaves = 200;
	int leavesCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (maxLeaves > leavesCount)
		{
			GameObject leave = Instantiate(leavesPrefab);
			leave.transform.position = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f));
			leavesCount++;
		}
	}
}
