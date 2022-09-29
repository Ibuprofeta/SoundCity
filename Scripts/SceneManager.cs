using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MidiJack;

public class SceneManager : MonoBehaviour
{

    [Header("Variables")]
    private int row;
    private int movementSpeed;
    private float bias;
    private float timeStep;
    private float timeBeat;
    private float restTime;
    private int spawn;
    private float scale;

    [Header("Initial Variables")]
    private float s_bias;
    private float s_timeStep;
    private float s_timeBeat;
    private float s_restTime;
    private float s_scale;
    private Color s_color;


    [Header("Color")]
    private Color color;
    private float rFloat;
    private float gFloat;
    private float bFloat;

    private Color bgColor;
    private float BGrFloat;
    private float BGgFloat;
    private float BGbFloat;    


    [Header("Midi inputs")]
    private float slider1;
    private float slider2;
    private float slider3;
    private float slider4;
    private float slider5;
    private float slider6;
    private float slider7;
    private float slider8;

    private float knob1;
    private float knob2;
    private float knob3;
    private float knob4;
    private float knob5;
    private float knob6;
    private float knob7;
    private float knob8;


    [Header("Button Buildings")]
    //Rectangles
    private float sbutton1;
    private float sbutton2;
    private float sbutton3;
    private float sbutton4;
    private float sbutton5;

    //Triangles
    private float mbutton1;
    private float mbutton2;
    private float mbutton3;
    private float mbutton4;
    //Rectangle
    private float mbutton5;

    //Circles
    private float rbutton1;
    private float rbutton2;
    private float rbutton3;

    //Mixes
    private float sbutton6;
    private float sbutton7;
    private float sbutton8;
    private float mbutton6;
    private float mbutton7;
    private float mbutton8;


    //Spawns buildings
    private float button9;
    private float button10;
    private float button11;

    [Header ("Initial MIDI values")]

    private float slider1S;
    private float slider2S;
    private float slider3S;
    private float slider4S;
    private float slider5S;
    private float slider6S;
    private float slider7S;
    private float slider8S;

    private float knob1S;
    private float knob2S;
    private float knob3S;
    private float knob4S;
    private float knob5S;
    private float knob6S;
    private float knob7S;
    private float knob8S;


    void Start()
    {
        row = 3;
        movementSpeed = 10;
        spawn = 2;

        InitializeVariables();

    }


    void Update()
    {
        MidiInput();


        CheckRows();
        CheckColors();
        CheckScale();

        //Detected audio range
        CheckBias();
        //Delay betweeen ticks
        CheckTimeStep();
        //
        CheckTimeBeat();
        //Delay to rest
        CheckRestTime();
        //Spawn timers
        CheckSpawn();
    }

    private void InitializeVariables()
    {
        s_bias = Random.Range(1f, 6f);
        s_timeBeat = Random.Range(0.05f, 0.3f);
        s_timeStep = Random.Range(0.15f, 1f);
        s_restTime = Random.Range(0.2f, 1f);
        s_scale = 30;


        //Colors
        s_color = new Color(1, 1, 1, 1);
        rFloat = 1f;
        gFloat = 1f;
        bFloat = 1f;

        slider1S = slider1;
        slider2S = slider2;
        slider3S = slider3; 
        slider4S = slider4;
        slider5S = slider5;
        slider6S = slider6;
        slider7S = slider7;
        slider8S = slider8;

        knob1S = knob1;
        knob2S = knob2;
        knob3S = knob3;
        knob4S = knob4;
        knob5S = knob5;
        knob6S = knob6;
        knob7S = knob7;
        knob8S = knob8;
    }

    private void MidiInput()
    {
        slider1 = MidiMaster.GetKnob(00);
        slider2 = MidiMaster.GetKnob(01);
        slider3 = MidiMaster.GetKnob(02);
        slider4 = MidiMaster.GetKnob(03); 
        slider5 = MidiMaster.GetKnob(04);
        slider6 = MidiMaster.GetKnob(05);
        slider7 = MidiMaster.GetKnob(06);
        slider8 = MidiMaster.GetKnob(07);


        knob1 = MidiMaster.GetKnob(16);
        knob2 = MidiMaster.GetKnob(17);
        knob3 = MidiMaster.GetKnob(18);
        knob4 = MidiMaster.GetKnob(19);
        knob5 = MidiMaster.GetKnob(20);
        knob6 = MidiMaster.GetKnob(21);
        knob7 = MidiMaster.GetKnob(22);
        knob8 = MidiMaster.GetKnob(23);

        //Rectangles
        sbutton1 = MidiMaster.GetKnob(32);
        sbutton2 = MidiMaster.GetKnob(33);
        sbutton3 = MidiMaster.GetKnob(34);
        sbutton4 = MidiMaster.GetKnob(35);
        sbutton5 = MidiMaster.GetKnob(36);

        //Triangles
        mbutton1 = MidiMaster.GetKnob(48);
        mbutton2 = MidiMaster.GetKnob(49);
        mbutton3 = MidiMaster.GetKnob(50);
        mbutton4 = MidiMaster.GetKnob(51);
        //Rectangñe
        mbutton5 = MidiMaster.GetKnob(52);
        
        //Circles
        rbutton1 = MidiMaster.GetKnob(64);
        rbutton2 = MidiMaster.GetKnob(65);
        rbutton3 = MidiMaster.GetKnob(66);

        //Mixes
        sbutton6 = MidiMaster.GetKnob(37);
        sbutton7 = MidiMaster.GetKnob(38);
        sbutton8 = MidiMaster.GetKnob(39);
        mbutton6 = MidiMaster.GetKnob(53);
        mbutton7 = MidiMaster.GetKnob(54);
        mbutton8 = MidiMaster.GetKnob(55);

        //Spawns
        button9 = MidiMaster.GetKnob(69);
        button10 = MidiMaster.GetKnob(70);
        button11 = MidiMaster.GetKnob(71);
    }

   
    private void CheckBias()
    {
        if (knob1 == knob1S)
        {
            SetBias(s_bias);
            
        }else
        {
            SetBias(map(0, 1, 1, 10, knob1));
            knob1S = -1;
        }
    }

    public void SetBias(float bias)
    {
        this.bias = bias;
    }

    public float GetBias()
    {
        float bias2 = this.bias + Random.Range(this.bias - this.bias * 10 / 100,
            this.bias + this.bias * 10 / 100);
        return bias2;
    }

   
    private void CheckTimeStep()
    {
        if (knob2 == knob2S)
        {
            SetTimeStep(s_timeStep);
        }
        else
        {
            SetTimeStep(knob2);
            knob2S = -1;
        } 
            
    }

    public void SetTimeStep(float ts)
    {
        this.timeStep = ts;
    }

    public float GetTimeStep()
    {
        float timeStep2 = this.timeStep + Random.Range(this.timeStep - this.timeStep * 10 / 100,
            this.timeStep + this.timeStep * 10 / 100);
        return timeStep2;
    }

    private void CheckTimeBeat()
    {
        if (knob3 == knob3S)
        {
            SetTimeBeat(s_timeBeat);
            
        }
        else
        {
            SetTimeBeat(map(0, 1, 0.01f, 0.5f, knob3));
            knob3S = -1;
        } 
    }

    public void SetTimeBeat(float tb)
    {
        this.timeBeat = tb;
    }

    public float GetTimeBeat()
    {
        float timeBeat2 = this.timeBeat + Random.Range(this.timeBeat - this.timeBeat * 10 / 100,
            this.timeBeat + this.timeBeat * 10 / 100);
        return timeBeat2;
    }

    private void CheckRestTime()
    {
        if (knob4 == knob4S)
        {
            SetRestTime(s_restTime);

        }
        else
        {
            SetRestTime(map(0, 1, 0.2f, 3, knob4));
            knob4S = -1;
        } 
    }

    public void SetRestTime(float rt)
    {
        this.restTime = rt;
    }

    public float GetRestTime()
    {
        float restTime2 = this.restTime + Random.Range(this.restTime - this.restTime * 10 / 100,
            this.restTime + this.restTime * 10 / 100);
        return restTime2;
    }

    private void CheckScale()
    {
        if (knob8 == knob8S)
        {
            SetScale(s_scale);
        }
        else
        { 
            SetScale(map(0, 1, 1, 30, knob8));
            knob8S = -1;
        }
    }

    public void SetScale(float s)
    {
        this.scale = s;
    }

    public float GetScale()
    {   
        float scale2 = this.scale + Random.Range(this.scale - this.scale * 60 / 100,
            this.scale + this.scale * 60 / 100);
        return scale2;
    }

    private void CheckRows()
    {
        //Rectangles
        if (sbutton1 == 1)
        {
            SetRows(1);
        } else if (sbutton2 == 1)
        {
            SetRows(2);
        } else if (sbutton3 == 1)
        {
            SetRows(3);
        }else if (sbutton4 == 1)
        {
            SetRows(4);
        }else if (sbutton5 == 1)
        {
            SetRows(5);
        }
        
        //Triangles
        else if (mbutton1 == 1)
        {
            SetRows(6);
        }
        else if (mbutton2 == 1)
        {
            SetRows(7);
        }
        else if (mbutton3 == 1)
        {
            SetRows(8);
        }
        else if (mbutton4 == 1)
        {
            SetRows(9);
        }
        //Rectangle
        else if (mbutton5 == 1)
        {
            SetRows(10);
        }

        //Circles
        else if (rbutton1 == 1)
        {
            SetRows(11);
        }
        else if (rbutton2 == 1)
        {
            SetRows(12);
        }
        else if (rbutton3 == 1)
        {
            SetRows(13);
        }


        //Mixes
        else if (sbutton6 == 1)
        {
            SetRows(14);
        }
        else if (sbutton7 == 1)
        {
            SetRows(15);
        }
        else if (sbutton8 == 1)
        {
            SetRows(16);
        }
        else if (mbutton6 == 1)
        {
            SetRows(17);
        }
        else if (mbutton7 == 1)
        {
            SetRows(18);
        }
        else if (mbutton8 == 1)
        {
            SetRows(19);
        }
    }

    public void SetRows(int row)
    {
        this.row = row;
    }

    public int GetRows()
    {
        return row;
    }

    private void CheckSpawn()
    {
        if (button9 == 1)
        {
            SetSpawn(1);
        }else if (button10 == 1)
        {
            SetSpawn(2);
        } else if (button11 == 1)
        {
            SetSpawn(3);
        }
    }
    public void SetSpawn(float s)
    {
        this.spawn = (int)s;
    }

    public int GetSpawn()
    {
        return spawn;
    }

    public int GetMovementSpeed()
    {
        return movementSpeed;
    }

    public Color GetColor()
    {
        this.color = new Color(rFloat, gFloat, bFloat, 1f);
        return this.color;
    }

    public Color GetBgColor()
    {
        this.bgColor = new Color(BGrFloat, BGgFloat, BGbFloat, 1f);
        return this.bgColor;
    }

    private void CheckColors()
    {
        if (slider1 == slider1S)
        {
            SetRed(map(0, 1, 0, 1 + slider4, 1));
        }
        else
        {
            SetRed(map(0, 1, 0, 1 + slider4, slider1));

            slider1S = -1;
        }

        if (slider2 == slider2S)
        {
            SetGreen(map(0, 1, 0, 1 + slider4, 1));
        }
        else
        {
            SetGreen(map(0, 1, 0, 1 + slider4, slider2));

            slider2S = -1;
        }

        if (slider3 == slider3S)
        {
            SetBlue(map(0, 1, 0, 1 + slider4, 1));
        }
        else
        {
            SetBlue(map(0, 1, 0, 1 + slider4, slider3));
            slider3S = -1;
        }
            
        SetBgColor();
    }

    public void SetRed(float c)
    {
        this.rFloat = c;
    }

    public void SetGreen(float c)
    {
        this.gFloat = c;
    }

    public void SetBlue(float c)
    {
        this.bFloat = c;
    }

    public void SetBgColor()
    {
        this.BGrFloat = map(0, 1, 0, 1 + slider8, slider5);
        this.BGgFloat = map(0, 1, 0, 1 + slider8, slider6);
        this.BGbFloat = map(0, 1, 0, 1 + slider8, slider7);
    }

    private float map(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }

}
