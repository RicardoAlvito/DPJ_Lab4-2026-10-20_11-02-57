using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Questuinary : MonoBehaviour
{
    [SerializeField] private QuestionSO questionSO;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private int respostacerta;
    [SerializeField] private Button[] respostas_botoes = new Button[4];//Gosto mais como button do que GameObjects, mais fixe

    
    public void OnAnswerSelected(int index) {


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
        GetNextQuestion();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
