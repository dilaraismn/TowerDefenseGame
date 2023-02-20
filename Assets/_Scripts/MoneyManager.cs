using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public int currentMoney;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UIManager.instance.goldText.text = currentMoney.ToString();
    }

    public void GiveMoney(int amountToGive)
    {
        currentMoney += amountToGive;
        UIManager.instance.goldText.text = currentMoney.ToString();
    }

    public bool SpendMoney(int amountToSpend)
    {
        bool canSpend = false;

        if (amountToSpend <= currentMoney)
        {
            canSpend = true;
            currentMoney -= amountToSpend;
        }
        UIManager.instance.goldText.text = currentMoney.ToString();
        return canSpend;
    }
}
