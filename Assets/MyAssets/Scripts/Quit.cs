using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
