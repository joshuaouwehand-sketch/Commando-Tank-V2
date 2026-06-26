using TMPro;
using UnityEngine;

public class ShopButtons : MonoBehaviour
{
    public TankHealth playerHealth;
    public AudioManager audioManager;
    public TankMovement playerMovement;
    public AudioClip buysound;
    public AudioClip declinesound;

    // Starting prices
    public int healthPackPrice = 3;
    public int damageUpgradePrice = 5;
    public int speedUpgradePrice = 5;
    public int livesPrice = 10;

    public TMP_Text healthPriceText;    
    public TMP_Text speedPriceText;
    public TMP_Text livesPriceText;
    public TMP_Text DamagePricerText;
    void UpdatePrices()
    {
        healthPriceText.text = "X " + healthPackPrice;
        speedPriceText.text = "X " + speedUpgradePrice;
        livesPriceText.text = "X " + livesPrice;
        DamagePricerText.text = "X " + damageUpgradePrice;
    }
    public void BuyHealthPack()
    {
        if (GameManager.coins >= healthPackPrice)
        {

            TankHealth tankHealth =
            GameObject.FindGameObjectWithTag("Player")
            .GetComponent<TankHealth>();

            GameManager.coins -= healthPackPrice;
            tankHealth.GetHealth(30);

            

            audioManager.PlaySound(buysound);
            Debug.Log("Bought Health Pack. New price: " + healthPackPrice);
        }
        else
        {
            audioManager.PlaySound(declinesound);
            Debug.Log("Not enough coins!");
        }
    }

    public void BuyDamageUpgrade()
    {
        if (GameManager.coins >= damageUpgradePrice)
        {
            GameManager.coins -= damageUpgradePrice;
            GameManager.playerdamage += 2;

            damageUpgradePrice += 2;
            UpdatePrices() ;
            audioManager.PlaySound(buysound);
            Debug.Log("Damage upgraded! New price: " + damageUpgradePrice);
        }
        else
        {
            audioManager.PlaySound(declinesound);
        }
    }

    public void BuySpeedUpgrade()
    {
        if (GameManager.coins >= speedUpgradePrice)
        {
            GameManager.coins -= speedUpgradePrice;
            playerMovement.moveSpeed += 0.5f;

            speedUpgradePrice += 2;
            UpdatePrices();
            audioManager.PlaySound(buysound);
        }
        else
        {
            audioManager.PlaySound(declinesound);
        }
    }

    public void BuyLives()
    {
        if (GameManager.coins >= livesPrice)
        {
            TankHealth tankHealth =
            GameObject.FindGameObjectWithTag("Player")
            .GetComponent<TankHealth>();
            GameManager.coins -= livesPrice;
            tankHealth.Lives += 1;

            livesPrice += 5;
            UpdatePrices();
            audioManager.PlaySound(buysound);
        }
        else
        {
            audioManager.PlaySound(declinesound);
        }
    }
}