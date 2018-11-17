using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.IO;
using UnityEngine;

public class ReadData : MonoBehaviour
{
    private string path = @"D:\BA_1_K2_2017_10_20 12_19_09.csv";

    float milisec_now = 0f;
    float milisec_next = 0f;

    string[] lines;
    string[] line;
    int szamlalo = 0;
    int currentLine;
    float offset_x, offset_y, offset_z;

    //RIGHT ARM
    public GameObject right_hand;
    public GameObject right_lower_arm;
    public GameObject right_upper_arm;

    //TOP
    public GameObject right_shoulder;
    public GameObject head;
    public GameObject neck;
    public GameObject left_shoulder;
    
    //LEFT ARM
    public GameObject left_upper_arm;
    public GameObject left_lower_arm;
    public GameObject left_hand;

    //SPINE
    public GameObject spine_shoulder;
    public GameObject spine_mid;
    public GameObject spine_base; 
    
    //LEFT LEG
    public GameObject left_hip;
    public GameObject left_thigh;
    public GameObject left_lower_leg;
    public GameObject left_foot;

    //RIGHT LEG
    public GameObject right_hip;
    public GameObject right_thigh;
    public GameObject right_lower_leg;
    public GameObject right_foot;

    // Start is called before the first frame update
    void Start()
    {
        lines = File.ReadAllLines(path);
        line = lines[1].Split(';');

        offset_x = float.Parse(line[1].Replace(',', '.')) - 0;
        offset_y = float.Parse(line[2].Replace(',', '.')) - 4;
        offset_z = float.Parse(line[3].Replace(',', '.')) - 2;



        // HEAD
        head.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
        Instantiate(head, new Vector3(float.Parse(line[1].Replace(',', '.')) - offset_x, 
            float.Parse(line[2].Replace(',', '.')) - offset_y,
            float.Parse(line[3].Replace(',', '.'))), Quaternion.identity);

        // RIGHT HAND
        right_hand.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(right_hand, new Vector3((float.Parse(line[10].Replace(',', '.')) - offset_x), (float.Parse(line[11].Replace(',', '.')) - offset_y), (float.Parse(line[12].Replace(',', '.')) - offset_z)), Quaternion.identity);

        // CALCULATE RIGHT_LOWER_ARM POS AND ROTATION AND INSTANTIATE
        Transform myTransform = CalculateTransform(new Vector3((float.Parse(line[13].Replace(',', '.')) - offset_x), (float.Parse(line[14].Replace(',', '.')) - offset_y), (float.Parse(line[15].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[16].Replace(',', '.')) - offset_x), (float.Parse(line[17].Replace(',', '.')) - offset_y), (float.Parse(line[18].Replace(',', '.')) - offset_z)),
            right_lower_arm.transform);
        right_lower_arm.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(right_lower_arm, myTransform.position, myTransform.rotation);

        // CALCULATE RIGHT_UPPER_ARM POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[16].Replace(',', '.')) - offset_x), (float.Parse(line[17].Replace(',', '.')) - offset_y), (float.Parse(line[18].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[19].Replace(',', '.')) - offset_x), (float.Parse(line[20].Replace(',', '.')) - offset_y), (float.Parse(line[21].Replace(',', '.')) - offset_z)),
            right_upper_arm.transform);
        right_upper_arm.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(right_upper_arm, myTransform.position, myTransform.rotation);

        // CALCULATE RIGHT_SHOULDER POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[19].Replace(',', '.')) - offset_x), (float.Parse(line[20].Replace(',', '.')) - offset_y), (float.Parse(line[21].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[22].Replace(',', '.')) - offset_x), (float.Parse(line[23].Replace(',', '.')) - offset_y), (float.Parse(line[24].Replace(',', '.')) - offset_z)),
            right_shoulder.transform);
        right_shoulder.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(right_shoulder, myTransform.position, myTransform.rotation);

        // SPINE_SHOULDER
        spine_shoulder.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(spine_shoulder, new Vector3((float.Parse(line[22].Replace(',', '.')) - offset_x), (float.Parse(line[23].Replace(',', '.')) - offset_y), (float.Parse(line[24].Replace(',', '.')) - offset_z)), Quaternion.identity);

        // NECK
        neck.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(neck, new Vector3((float.Parse(line[25].Replace(',', '.')) - offset_x), (float.Parse(line[26].Replace(',', '.')) - offset_y), (float.Parse(line[27].Replace(',', '.')) - offset_z)), Quaternion.identity);

        // CALCULATE LEFT_SHOULDER POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[22].Replace(',', '.')) - offset_x), (float.Parse(line[23].Replace(',', '.')) - offset_y), (float.Parse(line[24].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[28].Replace(',', '.')) - offset_x), (float.Parse(line[29].Replace(',', '.')) - offset_y), (float.Parse(line[30].Replace(',', '.')) - offset_z)),
            left_shoulder.transform);
        left_shoulder.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(left_shoulder, myTransform.position, myTransform.rotation);

        // CALCULATE LEFT_UPPER_ARM POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[28].Replace(',', '.')) - offset_x), (float.Parse(line[29].Replace(',', '.')) - offset_y), (float.Parse(line[30].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[31].Replace(',', '.')) - offset_x), (float.Parse(line[32].Replace(',', '.')) - offset_y), (float.Parse(line[33].Replace(',', '.')) - offset_z)),
            left_upper_arm.transform);
        left_upper_arm.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(left_upper_arm, myTransform.position, myTransform.rotation);

        // CALCULATE LEFT_LOWER_ARM POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[31].Replace(',', '.')) - offset_x), (float.Parse(line[32].Replace(',', '.')) - offset_y), (float.Parse(line[33].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[34].Replace(',', '.')) - offset_x), (float.Parse(line[35].Replace(',', '.')) - offset_y), (float.Parse(line[36].Replace(',', '.')) - offset_z)),
            left_lower_arm.transform);
        left_lower_arm.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(left_lower_arm, myTransform.position, myTransform.rotation);

        // LEFT HAND
        left_hand.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(left_hand, new Vector3((float.Parse(line[37].Replace(',', '.')) - offset_x), (float.Parse(line[38].Replace(',', '.')) - offset_y), (float.Parse(line[39].Replace(',', '.')) - offset_z)), Quaternion.identity);

        // SPINE_MID
        spine_mid.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(spine_mid, new Vector3((float.Parse(line[46].Replace(',', '.')) - offset_x), (float.Parse(line[47].Replace(',', '.')) - offset_y), (float.Parse(line[48].Replace(',', '.')) - offset_z)), Quaternion.identity);

        // SPINE_BASE
        spine_base.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(spine_base, new Vector3((float.Parse(line[49].Replace(',', '.')) - offset_x), (float.Parse(line[50].Replace(',', '.')) - offset_y), (float.Parse(line[51].Replace(',', '.')) - offset_z)), Quaternion.identity);

        // HIP_RIGHT
        right_hip.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(right_hip, new Vector3((float.Parse(line[52].Replace(',', '.')) - offset_x), (float.Parse(line[53].Replace(',', '.')) - offset_y), (float.Parse(line[54].Replace(',', '.')) - offset_z)), Quaternion.identity);

        // HIP_LEFT
        left_hip.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(left_hip, new Vector3((float.Parse(line[55].Replace(',', '.')) - offset_x), (float.Parse(line[56].Replace(',', '.')) - offset_y), (float.Parse(line[57].Replace(',', '.')) - offset_z)), Quaternion.identity);

        // CALCULATE RIGHT_THIGH POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[52].Replace(',', '.')) - offset_x), (float.Parse(line[53].Replace(',', '.')) - offset_y), (float.Parse(line[54].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[58].Replace(',', '.')) - offset_x), (float.Parse(line[59].Replace(',', '.')) - offset_y), (float.Parse(line[60].Replace(',', '.')) - offset_z)),
            right_thigh.transform);
        right_thigh.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(right_thigh, myTransform.position, myTransform.rotation);

        // CALCULATE LEFT_THIGH POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[55].Replace(',', '.')) - offset_x), (float.Parse(line[56].Replace(',', '.')) - offset_y), (float.Parse(line[57].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[61].Replace(',', '.')) - offset_x), (float.Parse(line[62].Replace(',', '.')) - offset_y), (float.Parse(line[63].Replace(',', '.')) - offset_z)),
            left_thigh.transform);
        left_thigh.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(left_thigh, myTransform.position, myTransform.rotation);

        // CALCULATE RIGHT_LOWER_LEG POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[58].Replace(',', '.')) - offset_x), (float.Parse(line[59].Replace(',', '.')) - offset_y), (float.Parse(line[60].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[64].Replace(',', '.')) - offset_x), (float.Parse(line[65].Replace(',', '.')) - offset_y), (float.Parse(line[66].Replace(',', '.')) - offset_z)),
            right_lower_leg.transform);
        right_lower_leg.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(right_lower_leg, myTransform.position, myTransform.rotation);

        // CALCULATE LEFT_LOWER_LEG POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[61].Replace(',', '.')) - offset_x), (float.Parse(line[62].Replace(',', '.')) - offset_y), (float.Parse(line[63].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[67].Replace(',', '.')) - offset_x), (float.Parse(line[68].Replace(',', '.')) - offset_y), (float.Parse(line[69].Replace(',', '.')) - offset_z)),
            left_lower_leg.transform);
        left_lower_leg.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(left_lower_leg, myTransform.position, myTransform.rotation);

        // RIGH_FOOT
        right_foot.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(right_foot, new Vector3((float.Parse(line[70].Replace(',', '.')) - offset_x), (float.Parse(line[71].Replace(',', '.')) - offset_y), (float.Parse(line[72].Replace(',', '.')) - offset_z)), Quaternion.identity);

        // LEFT_FOOT
        left_foot.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(left_foot, new Vector3((float.Parse(line[73].Replace(',', '.')) - offset_x), (float.Parse(line[74].Replace(',', '.')) - offset_y), (float.Parse(line[75].Replace(',', '.')) - offset_z)), Quaternion.identity);

        Debug.Log(float.Parse(line[73].Replace(',', '.')));
        Debug.Log(float.Parse(line[74].Replace(',', '.')));
        Debug.Log(float.Parse(line[75].Replace(',', '.')));

        currentLine = 1;
    }


    // Update is called once per frame
    void Update()
    {
        // Get elapsed milisec
        line = lines[currentLine].Split(';');
        milisec_next = float.Parse(line[0].Replace(',', '.'));
        float waitTime = (milisec_next - milisec_now);
        milisec_now = milisec_next;
        
        // AZ IF JÓ ITT
        if (!(currentLine >= lines.Length-1))
        {
            StartCoroutine(GetNextLineData(waitTime));
        }
             
    }

    private IEnumerator GetNextLineData(float waitTime)
    {       
        for (int i = 1; i < line.Length-3; i += 3)
        {
            for (int j = i; j < i+3; j++)
            {
                //Debug.Log(line[j]);
            }
        }



        // ------------------------------------------------ ITT FOLYTASD ------------------------------------------------
        // Move human to coordinates

        // --------------------------------- IDŐZÍTÉS ---------------------------------
        //Elapsed time = 5, 6 sec
        //Needed elapsed time = 11 sec
        //if milisec_next == Stopwatch.now
        //  start coroutine
        // Talán ez a megoldás jó lesz...
        currentLine += 1; ;
        //---------------IDK mért pontatlan
        yield return new WaitForSeconds(waitTime);
    }

    public Transform CalculateTransform(Vector3 startPos, Vector3 endPos, Transform transform)
    {
        Vector3 v3a = startPos;
        Vector3 v3b = endPos;

        var v3pos = (v3b - v3a) / 2.0f + v3a;  // position
        transform.position = v3pos;

        var v3 = v3b - v3a;    // rotation
        transform.rotation = Quaternion.FromToRotation(Vector3.right, v3);

        transform.localScale = new Vector3(v3.magnitude, 0.1f, v3.magnitude);  // scale 
        //transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        return transform;
    }
    

    


}
