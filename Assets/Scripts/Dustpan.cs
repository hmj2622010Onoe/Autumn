using UnityEngine;
using UnityEngine.InputSystem;

public class Dustpan : MonoBehaviour
{
	[SerializeField] BoxCollider2D closeCol;
	[SerializeField] AudioClip cleanSE;

	float locationX = 0;
	float locationY = 7;

	bool cleanTime = false;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = new Vector3(locationX, locationY, 0);
		if (cleanTime == false&& transform.position.y > 3.7)
		{
			closeCol.enabled = true;
			locationY -= 0.1f;
		}
		else { closeCol.enabled = false; }

		if(cleanTime==true&& transform.position.y < 10)
		{
			closeCol.enabled = true;
			locationY += 0.1f;
		}
		
		if (cleanTime == true && transform.position.y > 10)
		{ 
			cleanTime = false;
			locationX = Random.Range(-5f, 5f);
		}

		if (Keyboard.current.spaceKey.wasPressedThisFrame)
		{
			AudioSource.PlayClipAtPoint(cleanSE, transform.position);
			cleanTime = true;
		}
    }
}
