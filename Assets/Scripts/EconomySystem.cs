using UnityEngine;

public class EconomySystem : MonoBehaviour
{
    public int playerMoney = 1000;
    public int communityFund = 0;

    public void Donate(int amount)
    {
        if (playerMoney >= amount)
        {
            playerMoney -= amount;
            communityFund += amount;
            Debug.Log("Spende erfolgreich! Gemeinschaftsfonds: " + communityFund);
        }
        else
        {
            Debug.Log("Nicht genug Geld zum Spenden.");
        }
    }

    public void ReceiveBonus()
    {
        int bonus = communityFund / 10;
        playerMoney += bonus;
        Debug.Log("Bonus erhalten: " + bonus);
    }
}