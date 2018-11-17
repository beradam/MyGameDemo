using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using GracesGames.SimpleFileBrowser.Scripts;



public class OpenAndPlay : MonoBehaviour {

    public GameObject playerObject;
    public GameObject FileBrowserPrefab;

    DemoCaller dc = new DemoCaller();

    public int TicksPerSecond = 60;

    string[] file;
    float _t;
    string[] line;
    int count = 0;

    float coordinate_X, coordinate_Y, coordinate_Z;

    // Use this for initialization
    void Start()
    {

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;

        dc.FileBrowserPrefab = FileBrowserPrefab;
        
        dc.OpenFileBrowser(false);
        
           


        
        // CSAK EDITORBAN MŰKÖDIK, KELL EGY FILE NÉZEGETŐ IDE EHELYETT
        //path = EditorUtility.OpenFilePanel("alma", "", "txt");
        //file = new StreamReader(path);

    }

    void OnEnable()
    {
        _t = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        float dur = 1f / TicksPerSecond;
        _t += Time.deltaTime;
        while (_t >= dur)
        {
            _t -= dur;
            
            MoveTheSphere();
        }

    }

    public void MoveTheSphere()
    {

        if (dc.mehetunketovabb)
        {
            file = dc.passTheFile();
            dc.mehetunketovabb = false;
            count = 0;
        }



        if (file != null && count < file.Length)
        {

            string[] newline = file[count].Split(' ');

            coordinate_X = Convert.ToSingle(newline[0]);
            coordinate_Y = Convert.ToSingle(newline[1]);
            coordinate_Z = Convert.ToSingle(newline[2]);

            playerObject.transform.position = new Vector3(coordinate_X, coordinate_Y, coordinate_Z);

            count++;
            Debug.Log("Count: " + count);
        }
        else
        {

        }
        
    }
}
