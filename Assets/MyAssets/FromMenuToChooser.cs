using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromMenuToChooser : MonoBehaviour {

    public void ChangeMenuScene(string scenename)
    {
        Application.LoadLevel(scenename);
    }
}
