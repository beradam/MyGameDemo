using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.IO;
using UnityEngine;

public class ReadData : MonoBehaviour
{
    private string path = @"D:\Projektek\Szakdolgozat\BA_1_K2_2017_10_20 12_19_09.csv";
    private const int Kinect_V2_Lines_Length = 77;
    private const int Kinect_V1_Lines_Length = 60; /*IDK LE KELL CSEKKOLNI*/

    float milisec_now = 0f;
    float milisec_next = 0f;

    string[] lines;
    string[] line;
    int szamlalo = 0;
    int currentLine;
    float offset_x, offset_y, offset_z;
    bool V2;

     GameObject a;
     GameObject b;
     GameObject c;

    //TOP
     GameObject d;
     GameObject e;
     GameObject f;
     GameObject g;

    //LEFT ARM
     GameObject h;
     GameObject i;
     GameObject j;

    //SPINE
     GameObject k;
     GameObject l;
     GameObject m;

    //LEFT LEG
     GameObject n;
     GameObject o;
     GameObject p;
     GameObject q;

    //RIGHT LEG
     GameObject r;
     GameObject s;
     GameObject t;
     GameObject v;

    public GameObject posObj;

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

    // Needs some work but kinda OK
    private void InstantiateHumanV2(string[] line)
    {

        // Insatantiate POINTS for TEST
        for (int i = 10; i < line.Length - 3; i += 3)
        {
            InstantiateThePoints(new Vector3(float.Parse(line[i].Replace(',', '.')) - offset_x, float.Parse(line[i + 1].Replace(',', '.')) - offset_y, float.Parse(line[i + 2].Replace(',', '.')) - offset_z));
        }

        // HEAD
        a = Instantiate(head, new Vector3(float.Parse(line[1].Replace(',', '.')) - offset_x,
            float.Parse(line[2].Replace(',', '.')) - offset_y,
            float.Parse(line[3].Replace(',', '.')) - offset_z), Quaternion.identity);

        // RIGHT HAND
        Transform myTransform = CalculateTransform(new Vector3((float.Parse(line[13].Replace(',', '.')) - offset_x), (float.Parse(line[14].Replace(',', '.')) - offset_y), (float.Parse(line[15].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[4].Replace(',', '.')) - offset_x), (float.Parse(line[5].Replace(',', '.')) - offset_y), (float.Parse(line[6].Replace(',', '.')) - offset_z)),
           right_hand.transform);
        b = Instantiate(right_hand, myTransform.position, myTransform.rotation);

        // CALCULATE RIGHT_LOWER_ARM POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[13].Replace(',', '.')) - offset_x), (float.Parse(line[14].Replace(',', '.')) - offset_y), (float.Parse(line[15].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[16].Replace(',', '.')) - offset_x), (float.Parse(line[17].Replace(',', '.')) - offset_y), (float.Parse(line[18].Replace(',', '.')) - offset_z)),
            right_lower_arm.transform);
        c = Instantiate(right_lower_arm, myTransform.position, myTransform.rotation);

        // CALCULATE RIGHT_UPPER_ARM POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[19].Replace(',', '.')) - offset_x), (float.Parse(line[20].Replace(',', '.')) - offset_y), (float.Parse(line[21].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[16].Replace(',', '.')) - offset_x), (float.Parse(line[17].Replace(',', '.')) - offset_y), (float.Parse(line[18].Replace(',', '.')) - offset_z)),
            right_upper_arm.transform);
        d = Instantiate(right_upper_arm, myTransform.position, myTransform.rotation);

        // CALCULATE RIGHT_SHOULDER POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[19].Replace(',', '.')) - offset_x), (float.Parse(line[20].Replace(',', '.')) - offset_y), (float.Parse(line[21].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[22].Replace(',', '.')) - offset_x), (float.Parse(line[23].Replace(',', '.')) - offset_y), (float.Parse(line[24].Replace(',', '.')) - offset_z)),
            right_shoulder.transform);
        e = Instantiate(right_shoulder, myTransform.position, myTransform.rotation);

        // SPINE_SHOULDER
        myTransform = CalculateTransform(new Vector3((float.Parse(line[25].Replace(',', '.')) - offset_x), (float.Parse(line[26].Replace(',', '.')) - offset_y), (float.Parse(line[27].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[22].Replace(',', '.')) - offset_x), (float.Parse(line[23].Replace(',', '.')) - offset_y), (float.Parse(line[24].Replace(',', '.')) - offset_z)),
            spine_shoulder.transform);
        f = Instantiate(spine_shoulder, myTransform.position, myTransform.rotation);

        // NECK
        myTransform = CalculateTransform(new Vector3((float.Parse(line[22].Replace(',', '.')) - offset_x), (float.Parse(line[23].Replace(',', '.')) - offset_y), (float.Parse(line[24].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[1].Replace(',', '.')) - offset_x), (float.Parse(line[2].Replace(',', '.')) - offset_y), (float.Parse(line[3].Replace(',', '.')) - offset_z)),
            neck.transform);
        g = Instantiate(neck, myTransform.position, myTransform.rotation);

        // CALCULATE LEFT_SHOULDER POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[22].Replace(',', '.')) - offset_x), (float.Parse(line[23].Replace(',', '.')) - offset_y), (float.Parse(line[24].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[28].Replace(',', '.')) - offset_x), (float.Parse(line[29].Replace(',', '.')) - offset_y), (float.Parse(line[30].Replace(',', '.')) - offset_z)),
            left_shoulder.transform);
        h = Instantiate(left_shoulder, myTransform.position, myTransform.rotation);

        // CALCULATE LEFT_UPPER_ARM POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[28].Replace(',', '.')) - offset_x), (float.Parse(line[29].Replace(',', '.')) - offset_y), (float.Parse(line[30].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[31].Replace(',', '.')) - offset_x), (float.Parse(line[32].Replace(',', '.')) - offset_y), (float.Parse(line[33].Replace(',', '.')) - offset_z)),
            left_upper_arm.transform);
        i = Instantiate(left_upper_arm, myTransform.position, myTransform.rotation);

        // CALCULATE LEFT_LOWER_ARM POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[31].Replace(',', '.')) - offset_x), (float.Parse(line[32].Replace(',', '.')) - offset_y), (float.Parse(line[33].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[34].Replace(',', '.')) - offset_x), (float.Parse(line[35].Replace(',', '.')) - offset_y), (float.Parse(line[36].Replace(',', '.')) - offset_z)),
            left_lower_arm.transform);
        j = Instantiate(left_lower_arm, myTransform.position, myTransform.rotation);

        // LEFT HAND
        myTransform = CalculateTransform(new Vector3((float.Parse(line[40].Replace(',', '.')) - offset_x), (float.Parse(line[41].Replace(',', '.')) - offset_y), (float.Parse(line[42].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[34].Replace(',', '.')) - offset_x), (float.Parse(line[35].Replace(',', '.')) - offset_y), (float.Parse(line[36].Replace(',', '.')) - offset_z)),
            left_hand.transform);
        k = Instantiate(left_hand, myTransform.position, myTransform.rotation);

        // SPINE_MID
        myTransform = CalculateTransform(new Vector3((float.Parse(line[22].Replace(',', '.')) - offset_x), (float.Parse(line[23].Replace(',', '.')) - offset_y), (float.Parse(line[24].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[46].Replace(',', '.')) - offset_x), (float.Parse(line[47].Replace(',', '.')) - offset_y), (float.Parse(line[48].Replace(',', '.')) - offset_z)),
            spine_mid.transform);
        l = Instantiate(spine_mid, myTransform.position, myTransform.rotation);

        // SPINE_BASE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[46].Replace(',', '.')) - offset_x), (float.Parse(line[47].Replace(',', '.')) - offset_y), (float.Parse(line[48].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[49].Replace(',', '.')) - offset_x), (float.Parse(line[50].Replace(',', '.')) - offset_y), (float.Parse(line[51].Replace(',', '.')) - offset_z)),
            spine_base.transform);
        m = Instantiate(spine_base, myTransform.position, myTransform.rotation);

        // HIP_RIGHT
        myTransform = CalculateTransform(new Vector3((float.Parse(line[49].Replace(',', '.')) - offset_x), (float.Parse(line[50].Replace(',', '.')) - offset_y), (float.Parse(line[51].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[52].Replace(',', '.')) - offset_x), (float.Parse(line[53].Replace(',', '.')) - offset_y), (float.Parse(line[54].Replace(',', '.')) - offset_z)),
            right_hip.transform);
        n = Instantiate(right_hip, myTransform.position, myTransform.rotation);

        // HIP_LEFT
        myTransform = CalculateTransform(new Vector3((float.Parse(line[49].Replace(',', '.')) - offset_x), (float.Parse(line[50].Replace(',', '.')) - offset_y), (float.Parse(line[51].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[55].Replace(',', '.')) - offset_x), (float.Parse(line[56].Replace(',', '.')) - offset_y), (float.Parse(line[57].Replace(',', '.')) - offset_z)),
            left_hip.transform);
        o = Instantiate(left_hip, myTransform.position, myTransform.rotation);

        // CALCULATE RIGHT_THIGH POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[52].Replace(',', '.')) - offset_x), (float.Parse(line[53].Replace(',', '.')) - offset_y), (float.Parse(line[54].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[58].Replace(',', '.')) - offset_x), (float.Parse(line[59].Replace(',', '.')) - offset_y), (float.Parse(line[60].Replace(',', '.')) - offset_z)),
            right_thigh.transform);
        p = Instantiate(right_thigh, myTransform.position, myTransform.rotation);

        // CALCULATE LEFT_THIGH POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[55].Replace(',', '.')) - offset_x), (float.Parse(line[56].Replace(',', '.')) - offset_y), (float.Parse(line[57].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[61].Replace(',', '.')) - offset_x), (float.Parse(line[62].Replace(',', '.')) - offset_y), (float.Parse(line[63].Replace(',', '.')) - offset_z)),
            left_thigh.transform);
        q = Instantiate(left_thigh, myTransform.position, myTransform.rotation);

        // CALCULATE RIGHT_LOWER_LEG POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[58].Replace(',', '.')) - offset_x), (float.Parse(line[59].Replace(',', '.')) - offset_y), (float.Parse(line[60].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[64].Replace(',', '.')) - offset_x), (float.Parse(line[65].Replace(',', '.')) - offset_y), (float.Parse(line[66].Replace(',', '.')) - offset_z)),
            right_lower_leg.transform);
        r = Instantiate(right_lower_leg, myTransform.position, myTransform.rotation);

        // CALCULATE LEFT_LOWER_LEG POS AND ROTATION AND INSTANTIATE
        myTransform = CalculateTransform(new Vector3((float.Parse(line[61].Replace(',', '.')) - offset_x), (float.Parse(line[62].Replace(',', '.')) - offset_y), (float.Parse(line[63].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[67].Replace(',', '.')) - offset_x), (float.Parse(line[68].Replace(',', '.')) - offset_y), (float.Parse(line[69].Replace(',', '.')) - offset_z)),
            left_lower_leg.transform);
        s = Instantiate(left_lower_leg, myTransform.position, myTransform.rotation);

        // RIGH_FOOT
        t = Instantiate(right_foot, new Vector3((float.Parse(line[70].Replace(',', '.')) - offset_x), (float.Parse(line[71].Replace(',', '.')) - offset_y), (float.Parse(line[72].Replace(',', '.')) - offset_z)), Quaternion.identity);

        // LEFT_FOOT
        v = Instantiate(left_foot, new Vector3((float.Parse(line[73].Replace(',', '.')) - offset_x), (float.Parse(line[74].Replace(',', '.')) - offset_y), (float.Parse(line[75].Replace(',', '.')) - offset_z)), Quaternion.identity);

        Debug.Log("Instantiate DONE!");
        currentLine = 1;
    }

    // TO DO
    private void MoveHumanFigureV2(string[] line)
    {

        // HEAD
        Destroy(a);
        a = Instantiate(head, new Vector3(float.Parse(line[1].Replace(',', '.')) - offset_x,
            float.Parse(line[2].Replace(',', '.')) - offset_y,
            float.Parse(line[3].Replace(',', '.')) - offset_z), Quaternion.identity);

        // RIGHT HAND
        Destroy(b);
        Transform myTransform = CalculateTransform(new Vector3((float.Parse(line[13].Replace(',', '.')) - offset_x), (float.Parse(line[14].Replace(',', '.')) - offset_y), (float.Parse(line[15].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[4].Replace(',', '.')) - offset_x), (float.Parse(line[5].Replace(',', '.')) - offset_y), (float.Parse(line[6].Replace(',', '.')) - offset_z)),
           right_hand.transform);
        b = Instantiate(right_hand, myTransform.position, myTransform.rotation);

        // CALCULATE RIGHT_LOWER_ARM POS AND ROTATION AND INSTANTIATE
        Destroy(c);
        myTransform = CalculateTransform(new Vector3((float.Parse(line[13].Replace(',', '.')) - offset_x), (float.Parse(line[14].Replace(',', '.')) - offset_y), (float.Parse(line[15].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[16].Replace(',', '.')) - offset_x), (float.Parse(line[17].Replace(',', '.')) - offset_y), (float.Parse(line[18].Replace(',', '.')) - offset_z)),
            right_lower_arm.transform);
        c = Instantiate(right_lower_arm, myTransform.position, myTransform.rotation);

        // CALCULATE RIGHT_UPPER_ARM POS AND ROTATION AND INSTANTIATE
        Destroy(d);
        myTransform = CalculateTransform(new Vector3((float.Parse(line[19].Replace(',', '.')) - offset_x), (float.Parse(line[20].Replace(',', '.')) - offset_y), (float.Parse(line[21].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[16].Replace(',', '.')) - offset_x), (float.Parse(line[17].Replace(',', '.')) - offset_y), (float.Parse(line[18].Replace(',', '.')) - offset_z)),
            right_upper_arm.transform);
        d = Instantiate(right_upper_arm, myTransform.position, myTransform.rotation);

        // CALCULATE RIGHT_SHOULDER POS AND ROTATION AND INSTANTIATE
        Destroy(e);
        myTransform = CalculateTransform(new Vector3((float.Parse(line[19].Replace(',', '.')) - offset_x), (float.Parse(line[20].Replace(',', '.')) - offset_y), (float.Parse(line[21].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[22].Replace(',', '.')) - offset_x), (float.Parse(line[23].Replace(',', '.')) - offset_y), (float.Parse(line[24].Replace(',', '.')) - offset_z)),
            right_shoulder.transform);
        e = Instantiate(right_shoulder, myTransform.position, myTransform.rotation);

        // SPINE_SHOULDER
        Destroy(f);
        myTransform = CalculateTransform(new Vector3((float.Parse(line[25].Replace(',', '.')) - offset_x), (float.Parse(line[26].Replace(',', '.')) - offset_y), (float.Parse(line[27].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[22].Replace(',', '.')) - offset_x), (float.Parse(line[23].Replace(',', '.')) - offset_y), (float.Parse(line[24].Replace(',', '.')) - offset_z)),
            spine_shoulder.transform);
        f = Instantiate(spine_shoulder, myTransform.position, myTransform.rotation);

        // NECK
        Destroy(g);
        myTransform = CalculateTransform(new Vector3((float.Parse(line[22].Replace(',', '.')) - offset_x), (float.Parse(line[23].Replace(',', '.')) - offset_y), (float.Parse(line[24].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[1].Replace(',', '.')) - offset_x), (float.Parse(line[2].Replace(',', '.')) - offset_y), (float.Parse(line[3].Replace(',', '.')) - offset_z)),
            neck.transform);
        g = Instantiate(neck, myTransform.position, myTransform.rotation);

        // CALCULATE LEFT_SHOULDER POS AND ROTATION AND INSTANTIATE
        Destroy(h);
        myTransform = CalculateTransform(new Vector3((float.Parse(line[22].Replace(',', '.')) - offset_x), (float.Parse(line[23].Replace(',', '.')) - offset_y), (float.Parse(line[24].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[28].Replace(',', '.')) - offset_x), (float.Parse(line[29].Replace(',', '.')) - offset_y), (float.Parse(line[30].Replace(',', '.')) - offset_z)),
            left_shoulder.transform);
        h = Instantiate(left_shoulder, myTransform.position, myTransform.rotation);

        // CALCULATE LEFT_UPPER_ARM POS AND ROTATION AND INSTANTIATE
        Destroy(i);
        myTransform = CalculateTransform(new Vector3((float.Parse(line[28].Replace(',', '.')) - offset_x), (float.Parse(line[29].Replace(',', '.')) - offset_y), (float.Parse(line[30].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[31].Replace(',', '.')) - offset_x), (float.Parse(line[32].Replace(',', '.')) - offset_y), (float.Parse(line[33].Replace(',', '.')) - offset_z)),
            left_upper_arm.transform);
        i = Instantiate(left_upper_arm, myTransform.position, myTransform.rotation);

        // CALCULATE LEFT_LOWER_ARM POS AND ROTATION AND INSTANTIATE
        Destroy(j);
        myTransform = CalculateTransform(new Vector3((float.Parse(line[31].Replace(',', '.')) - offset_x), (float.Parse(line[32].Replace(',', '.')) - offset_y), (float.Parse(line[33].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[34].Replace(',', '.')) - offset_x), (float.Parse(line[35].Replace(',', '.')) - offset_y), (float.Parse(line[36].Replace(',', '.')) - offset_z)),
            left_lower_arm.transform);
        j = Instantiate(left_lower_arm, myTransform.position, myTransform.rotation);

        // LEFT HAND
        Destroy(k);
        myTransform = CalculateTransform(new Vector3((float.Parse(line[40].Replace(',', '.')) - offset_x), (float.Parse(line[41].Replace(',', '.')) - offset_y), (float.Parse(line[42].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[34].Replace(',', '.')) - offset_x), (float.Parse(line[35].Replace(',', '.')) - offset_y), (float.Parse(line[36].Replace(',', '.')) - offset_z)),
            left_hand.transform);
        k = Instantiate(left_hand, myTransform.position, myTransform.rotation);

        // SPINE_MID
        Destroy(l);
        myTransform = CalculateTransform(new Vector3((float.Parse(line[22].Replace(',', '.')) - offset_x), (float.Parse(line[23].Replace(',', '.')) - offset_y), (float.Parse(line[24].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[46].Replace(',', '.')) - offset_x), (float.Parse(line[47].Replace(',', '.')) - offset_y), (float.Parse(line[48].Replace(',', '.')) - offset_z)),
            spine_mid.transform);
        l = Instantiate(spine_mid, myTransform.position, myTransform.rotation);

        // SPINE_BASE
        Destroy(m);
        myTransform = CalculateTransform(new Vector3((float.Parse(line[46].Replace(',', '.')) - offset_x), (float.Parse(line[47].Replace(',', '.')) - offset_y), (float.Parse(line[48].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[49].Replace(',', '.')) - offset_x), (float.Parse(line[50].Replace(',', '.')) - offset_y), (float.Parse(line[51].Replace(',', '.')) - offset_z)),
            spine_base.transform);
        m = Instantiate(spine_base, myTransform.position, myTransform.rotation);

        // HIP_RIGHT
        Destroy(n);
        myTransform = CalculateTransform(new Vector3((float.Parse(line[49].Replace(',', '.')) - offset_x), (float.Parse(line[50].Replace(',', '.')) - offset_y), (float.Parse(line[51].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[52].Replace(',', '.')) - offset_x), (float.Parse(line[53].Replace(',', '.')) - offset_y), (float.Parse(line[54].Replace(',', '.')) - offset_z)),
            right_hip.transform);
        n = Instantiate(right_hip, myTransform.position, myTransform.rotation);

        // HIP_LEFT
        Destroy(o);
        myTransform = CalculateTransform(new Vector3((float.Parse(line[49].Replace(',', '.')) - offset_x), (float.Parse(line[50].Replace(',', '.')) - offset_y), (float.Parse(line[51].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[55].Replace(',', '.')) - offset_x), (float.Parse(line[56].Replace(',', '.')) - offset_y), (float.Parse(line[57].Replace(',', '.')) - offset_z)),
            left_hip.transform);
        o = Instantiate(left_hip, myTransform.position, myTransform.rotation);

        // CALCULATE RIGHT_THIGH POS AND ROTATION AND INSTANTIATE
        Destroy(p);
        myTransform = CalculateTransform(new Vector3((float.Parse(line[52].Replace(',', '.')) - offset_x), (float.Parse(line[53].Replace(',', '.')) - offset_y), (float.Parse(line[54].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[58].Replace(',', '.')) - offset_x), (float.Parse(line[59].Replace(',', '.')) - offset_y), (float.Parse(line[60].Replace(',', '.')) - offset_z)),
            right_thigh.transform);
        p = Instantiate(right_thigh, myTransform.position, myTransform.rotation);

        // CALCULATE LEFT_THIGH POS AND ROTATION AND INSTANTIATE
        Destroy(q);
        myTransform = CalculateTransform(new Vector3((float.Parse(line[55].Replace(',', '.')) - offset_x), (float.Parse(line[56].Replace(',', '.')) - offset_y), (float.Parse(line[57].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[61].Replace(',', '.')) - offset_x), (float.Parse(line[62].Replace(',', '.')) - offset_y), (float.Parse(line[63].Replace(',', '.')) - offset_z)),
            left_thigh.transform);
        q = Instantiate(left_thigh, myTransform.position, myTransform.rotation);

        // CALCULATE RIGHT_LOWER_LEG POS AND ROTATION AND INSTANTIATE
        Destroy(r);
        myTransform = CalculateTransform(new Vector3((float.Parse(line[58].Replace(',', '.')) - offset_x), (float.Parse(line[59].Replace(',', '.')) - offset_y), (float.Parse(line[60].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[64].Replace(',', '.')) - offset_x), (float.Parse(line[65].Replace(',', '.')) - offset_y), (float.Parse(line[66].Replace(',', '.')) - offset_z)),
            right_lower_leg.transform);
        r = Instantiate(right_lower_leg, myTransform.position, myTransform.rotation);

        // CALCULATE LEFT_LOWER_LEG POS AND ROTATION AND INSTANTIATE
        Destroy(s);
        myTransform = CalculateTransform(new Vector3((float.Parse(line[61].Replace(',', '.')) - offset_x), (float.Parse(line[62].Replace(',', '.')) - offset_y), (float.Parse(line[63].Replace(',', '.')) - offset_z)),
            new Vector3((float.Parse(line[67].Replace(',', '.')) - offset_x), (float.Parse(line[68].Replace(',', '.')) - offset_y), (float.Parse(line[69].Replace(',', '.')) - offset_z)),
            left_lower_leg.transform);
        s = Instantiate(left_lower_leg, myTransform.position, myTransform.rotation);

        // RIGH_FOOT
        Destroy(t);
        t = Instantiate(right_foot, new Vector3((float.Parse(line[70].Replace(',', '.')) - offset_x), (float.Parse(line[71].Replace(',', '.')) - offset_y), (float.Parse(line[72].Replace(',', '.')) - offset_z)), Quaternion.identity);

        // LEFT_FOOT
        Destroy(v);
        v = Instantiate(left_foot, new Vector3((float.Parse(line[73].Replace(',', '.')) - offset_x), (float.Parse(line[74].Replace(',', '.')) - offset_y), (float.Parse(line[75].Replace(',', '.')) - offset_z)), Quaternion.identity);        
    }

    private void MoveHumanFigureV1(string[] line)
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        // Get first line
        lines = File.ReadAllLines(path);
        line = lines[1].Split(';');

        // Calculate offset
        offset_x = float.Parse(line[1].Replace(',', '.')) - 0;
        offset_y = float.Parse(line[2].Replace(',', '.')) - 4;
        offset_z = float.Parse(line[3].Replace(',', '.')) - 2;

        if (line.Length == Kinect_V2_Lines_Length)
        {
            /*ITT LEGYEN AZ INSTANTIATE + GET KINECT V1 OR V2*/
            InstantiateHumanV2(line);
            V2 = true;
        }
        else if (line.Length == Kinect_V1_Lines_Length)
        {
            /*ITT LEGYEN AZ INSTANTIATE + GET KINECT V1 OR V2*/
            V2 = false;
        }
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
        if (!(currentLine >= lines.Length - 1))
        {
            StartCoroutine(GetNextLineData(waitTime, line));
        }

    }
    

    

    private IEnumerator GetNextLineData(float waitTime, string[] line)
    {
        //for (int i = 1; i < line.Length-3; i += 3)
        //{
        //    for (int j = i; j < i+3; j++)
        //    {
        //        //Debug.Log(line[j]);
        //    }
        //}
        // ------------------------------------------------ ITT FOLYTASD ------------------------------------------------
        // Move human to coordinates
        Debug.Log(waitTime);
        yield return new WaitForSeconds(waitTime);

        if (V2)
        {
            MoveHumanFigureV2(line);
        }
        else
        {
            MoveHumanFigureV1(line);
        }

        // --------------------------------- IDŐZÍTÉS ---------------------------------
        //Elapsed time = 5, 6 sec
        //Needed elapsed time = 11 sec
        //if milisec_next == Stopwatch.now
        //  start coroutine
        // Talán ez a megoldás jó lesz...
        if (!(currentLine >= lines.Length - 1))
            currentLine += 1;
        //---------------IDK mért pontatlan

        
    }


    // EZ MÁR JÓ
    public Transform CalculateTransform(Vector3 startPos, Vector3 endPos, Transform transform)
    {
        Vector3 v3a = startPos;
        Vector3 v3b = endPos;

        var v3pos = (v3b - v3a) / 2.0f + v3a;  // position
        transform.position = v3pos;

        var v3 = v3b - v3a;    // rotation

        v3.x = -v3.x;
        v3.z = -v3.z;

        var rot = Quaternion.FromToRotation(v3, Vector3.up);
        transform.rotation = rot;

        //var v3s = v3b/2.0f - v3a/2.0f;
        transform.localScale = new Vector3(0.1f, v3.magnitude/2.0f, 0.1f);  // scale 

        return transform;
    }

    public void InstantiateThePoints(Vector3 pos)
    {
        Instantiate(posObj, pos, Quaternion.identity);
    }
    

    


}
