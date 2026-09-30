using UnityEngine;

public class LeavesManager : MonoBehaviour
{
	[SerializeField] GameObject leavesPrefab;
	[SerializeField] GameObject dustPan;

	[SerializeField]int maxLeaves = 200;
	int leavesCount = 0;

	[SerializeField] float xPlus=10f;
	[SerializeField] float xMinus=10f;
	[SerializeField] float yPlus=5f;
	[SerializeField] float yMinus=5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		for (int i = leavesCount; maxLeaves > i; i++)
		{
			GameObject leave = Instantiate(leavesPrefab);
			leave.transform.position = new Vector2(Random.Range(-xMinus, xPlus), Random.Range(-yMinus, yPlus));
			//leave.GetComponent<LeavesContllorer>().dustPan = this.dustPan;
			leavesCount++;
		}
	}
}
