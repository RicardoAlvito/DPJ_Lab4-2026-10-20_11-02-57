using TMPro;
using UnityEngine;

public class Questuinary : MonoBehaviour
{
    [SerializeField] private QuestionSO questionSO;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private int respostacerta;

    void Start()
    {
        textMeshProUGUI.text = questionSO.GetQuestion();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
