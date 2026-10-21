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
        if (questionSO.GetAnswer() == respostas_botoes[index].GetComponentInChildren<TextMeshProUGUI>().text) {
            //resposta correta
            respostas_botoes[index].GetComponentInChildren<TextMeshProUGUI>().text = "Correto!";
        }
        else
        {
            //resposta errada
            respostas_botoes[index].GetComponentInChildren<TextMeshProUGUI>().text = "ERRADO!";
        }
        SetButtonState(false);
    }

    void DisplayQuestion()
    {
        textMeshProUGUI.text = questionSO.GetQuestion();

        string[] vcvcvc = new string[4];
        vcvcvc = questionSO.GetQuestionArray();
        //for loop
        for (int i = 0; i < respostas_botoes.Length; i++)
        {
            respostas_botoes[i].GetComponentInChildren<TextMeshProUGUI>().text = vcvcvc[i];
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < respostas_botoes.Length; i++)
        {
            respostas_botoes[i].interactable = state;
        }
    }
    void Start()
    {
        DisplayQuestion();
        SetButtonState(true);//gogogog
    }

    // Update is called once per frame
    void Update()
    {

    }
}
