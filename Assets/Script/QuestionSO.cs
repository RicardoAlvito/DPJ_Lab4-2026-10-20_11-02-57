using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "SQ/Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 5)]
    [SerializeField] private string question;
    [SerializeField] private string[] questionArray = new string[4]; 
    [SerializeField] private int resposta;

    public string GetQuestion()
    {
        return question;
    }
    public int GetCorrectAnswerIndex()
    {
        return resposta;
    }
    public string GetAnswer()
    {
        return questionArray[resposta];
    }

    public string[] GetQuestionArray()
    {
        return questionArray;
    }
}