using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField]
    GameObject[] holes;     // array for keeping track of the holes states
    [SerializeField]
    GameObject prefabBall;  // for instantiating balls

    [SerializeField]
    Text messageText;   // for winning message

    // Win Check Support (used to delay the win, to make sure the balls are still inside the holes)
    float winDetectionTime;
    bool win = false;
    const float wait = 2f;

    // Use this for initialization
    void Start () {
        holes = GameObject.FindGameObjectsWithTag("Hole");  // filling the holes array
        messageText.text = string.Empty;                    // hiding the message text (until a win occurs)
        RandomBalls(3);                                     // inserting 3 balls in random spots
	}
	
	// Update is called once per frame
	void Update () {

        // checking a win and marking the time (to see if it's still a win after 2 seconds)
        if (CheckWin() && !win)
        {
            win = true;
            winDetectionTime = Time.time;
        }

        // declaring a win if the balls stayed in their holes after 2 seconds
        if (win && Time.time >= winDetectionTime + wait)
            OnWin();

        // cancelling the win if a ball left
        if (win && !CheckWin())
        {
            messageText.text = string.Empty;
            win = false;
        }
    }

    // going over the holes, updating the fulls array and returning true if they're all full
    bool CheckWin()
    {
        for (int i = 0; i < holes.Length; i++)
        {
            if (!holes[i].GetComponent<Hole>().Full) // accessing the Hole script and it's "Full" property
                return false;
        }
        return true;
    }

    // what happens on a win...
    void OnWin()
    {
        messageText.text = "A Win!";
    }
    
    // for instantiatig as many balls as needed, at random places
    void RandomBalls(int balls)
    {
        for (int i = 0; i < balls; i++)
        {
            Vector3 randomPosition = new Vector3((Random.value - 0.5f) * 7f, (Random.value + 0.5f) * 2, (Random.value - 0.5f) * 7); // picking a valid random position
            Instantiate(prefabBall, randomPosition, Quaternion.identity);
        }
    }
}
