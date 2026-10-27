using System;
using Unity.Mathematics;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private float timeToCompleteQuestion;
    [SerializeField] private float timeToShowCorrectAnswer;

    private float timerValue;
    public float fillFraction;
    public bool isAnsweringQuestion  = false;
    public bool loadNextQuestion = false;
    [SerializeField] private Sprite[] imagens = new Sprite[4];
    [SerializeField] private Image imagen;
    private int d = 0;

    public void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (timerValue <= 0)
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }

            fillFraction = timerValue / timeToCompleteQuestion;
        }
        else
        {
            if (timerValue <= 0)
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }

            fillFraction = timerValue / timeToShowCorrectAnswer;
        }
    }
    public void CancelTimer()
    {
        timerValue = 0;
    }


    void Start()
    {
        
    }

    private int ss = 3;
    void Update()
    {
        UpdateTimer();
        if ((int)timerValue % 3 == 0 && ss != (int)timerValue)
        {
            imagen.GetComponent<Image>().sprite = imagens[d];
            d++;
            if (d >= imagens.Length) { d = 0; }
            ss = (int)timerValue;
        }
        Debug.Log(math.round(timerValue % 90));
        Debug.Log(timerValue);
    }
}
