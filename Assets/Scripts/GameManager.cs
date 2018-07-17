using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField]
    GameObject[] holes;
    [SerializeField]
    GameObject prefabBall;
    int[] fulls = new int[3];
    [SerializeField]
    Text messageText;

    // Win Check Support
    float winDetectionTime;
    bool win = false;
    const float wait = 2f;

    // Use this for initialization
    void Start () {
        holes = GameObject.FindGameObjectsWithTag("Hole");
        messageText.text = string.Empty;

        for (int i = 0; i < 3; i++)
        {
            Vector3 randomPosition = new Vector3((Random.value - 0.5f)*7f, (Random.value + 0.5f) * 2, (Random.value - 0.5f) * 7);
            Instantiate(prefabBall,randomPosition, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (CheckWin() && !win)
        {
            win = true;
            winDetectionTime = Time.time;
        }


        if (win && Time.time >= winDetectionTime + wait)
            OnWin();

        if (win && !CheckWin())
        {
            messageText.text = string.Empty;
            win = false;
        }


    }

    bool CheckWin()
    {
        for (int i = 0; i < holes.Length; i++)
        {
            if (holes[i].GetComponent<Hole>().Full)
                fulls[i] = 1;
            else fulls[i] = 0;
        }
        return (fulls.Sum() == fulls.Length);
    }

    void OnWin()
    {
        messageText.text = "A Win!";
    }

    IEnumerator WaitHalfSecond()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
