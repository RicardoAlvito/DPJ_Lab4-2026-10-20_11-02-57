using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Questuinary : MonoBehaviour
{
    [SerializeField] private QuestionSO questionSO;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private int respostacerta;
    [SerializeField] private Button[] respostas_botoes = new Button[4];//Gosto mais como button do que GameObjects, mais fixe

    /*estou no No script “Questionaire”, crie a variável bool HasAnsweredEarly;
    o No script “Timer”, altere o nível de proteção do bool isAnsweringQuestion
para public;
 Agora, no método Upda*/
    [SerializeField] private Timer timer;
    [SerializeField] private Image timerImage;
    private bool hasAnsweredEarly;

    private int correctAnswerdddd;
    public void OnAnswerSelected(int index) {
        hasAnsweredEarly = true;
        correctAnswerdddd = index;
        string correctAnswer = questionSO.GetAnswer(questionSO.GetCorrectAnswerIndex());
        if (questionSO.GetCorrectAnswerIndex() == index) {
            //resposta correta
            textMeshProUGUI.text = "Correto!";
        }
        else
        {
            //resposta errada
            textMeshProUGUI.text = "Desculpa, mas a \n resposta correta é:"+ correctAnswer;
        }
        SetButtonState(false);
        timer.CancelTimer();
    }

    void DisplayQuestion()
    {
        textMeshProUGUI.text = questionSO.GetQuestion();
        //for loop
        for (int i = 0; i < respostas_botoes.Length; i++)
        {
            respostas_botoes[i].GetComponentInChildren<TextMeshProUGUI>().text = questionSO.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < respostas_botoes.Length; i++)
        {
            respostas_botoes[i].interactable = state;
        }
    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        DisplayQuestion();
    }

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        GetNextQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (hasAnsweredEarly && timer.isAnsweringQuestion) { 
            DisplayAnswer(correctAnswerdddd);
            hasAnsweredEarly = false;
            SetButtonState(false);
        }

    }

    void DisplayAnswer(int index)
    {
        string correctAnswer = questionSO.GetAnswer(questionSO.GetCorrectAnswerIndex());
        if (questionSO.GetCorrectAnswerIndex() == index)
        {
            //resposta correta
            textMeshProUGUI.text = "Correto!";
        }
        else
        {
            //resposta errada
            textMeshProUGUI.text = "Desculpa, mas a \n resposta correta é:" + correctAnswer;
        }
        SetButtonState(false);
        timer.CancelTimer();
    }
}
