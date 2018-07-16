using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    GameObject[] holes;

	// Use this for initialization
	void Start () {
        holes = GameObject.FindGameObjectsWithTag("Hole");
	}
	
	// Update is called once per frame
	void Update () {
        if (CheckWin())
        {
            OnWin();
        }
	}

    bool CheckWin()
    {
        foreach (GameObject hole in holes)
        {
            print(hole.GetComponent<Hole>().Full);
            if (!hole.GetComponent<Hole>().Full)
            {
                print("still some empty hole...");
                return false;
            }
        }
        print("all full!");
        return true;

    }

    void OnWin()
    {
        print("Win!");
        foreach (GameObject hole in holes)
            hole.GetComponent<Hole>().Win = true;
    }

}
