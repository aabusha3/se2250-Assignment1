using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    
    private int num;

    void Start()
    {
        score = GetComponent<Text>();
        num = 0;
        score.text = num.ToString("0");
    }

    public void Scored(int pointsValue)
    {
        num = Int32.Parse(score.text) + pointsValue;
        score.text = num.ToString("0");
    }
}
