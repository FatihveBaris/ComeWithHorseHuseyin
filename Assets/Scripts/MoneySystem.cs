using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneySystem : MonoBehaviour
{
    public int money = 20;
    public Button button4Times;
    public Button button12Times;
    public Button button24Times;
    public Button continueButton;
    public TextMeshProUGUI moneyText;
    private int selectedMultiplier = 1;

    void Start()
    {
        button4Times.onClick.AddListener(() => SelectMultiplier(4));
        button12Times.onClick.AddListener(() => SelectMultiplier(12));
        button24Times.onClick.AddListener(() => SelectMultiplier(24));
        continueButton.onClick.AddListener(() => Continue());
    }

    void Update()
    {
        if (money > 9999)
        {
            Debug.Log("Kazaniyoruuuzz");
        }
        moneyText.text = "Your money: " + money;
    }

    void SelectMultiplier(int multiplier)
    {
        selectedMultiplier = multiplier;
    }

    void Continue()
    {
        money *= selectedMultiplier;
        Debug.Log("Continuing. Your money: " + money);
    }
}
