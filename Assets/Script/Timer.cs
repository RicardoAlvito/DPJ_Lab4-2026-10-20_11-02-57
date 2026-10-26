using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private float timeToCompleteQuestion;
    [SerializeField] private float timeToShowCorrectAnswer;

    private float timerValue;
    public float fillFraction;
    public bool isAnsweringQuestion  = false;
    public bool loadNextQuestion = false;

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

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }
}
