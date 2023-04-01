using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public Image defaultShip;
    public Image premiumShip;
    public Sprite[] defaultShipArray;
    public Sprite[] premiumShipArray;

    public GameObject title;
    public GameObject overlay;

    public GameObject defaultCard;
    public GameObject premiumCard;
    public GameObject limitedCard;
    public GameObject specialCard;
    public GameObject premiumCost;
    public GameObject limitedCost;
    public GameObject specialCost;
    public GameObject premiumPurchasePopup;
    public GameObject limitedPurchasePopup;
    public GameObject specialPurchasePopup;
    public GameObject paymentPopup;
    public GameObject paymentPopupCost;

    public GameObject HPCard;
    public GameObject MSCard;
    public GameObject TFCard;
    public GameObject HPcount;
    public GameObject MScount;
    public GameObject TFcount;

    public GameObject creditScreen;
    public TextMeshProUGUI creditLabel;


    // Start is called before the first frame update
    void Start()
    {
        // Update player's credit amount
        int credits = PlayerPrefs.GetInt("Credits");

        creditLabel.text = credits.ToString();

        // Set all cards as white
        defaultCard.GetComponent<Image>().color = new Color(1, 1, 1);
        premiumCard.GetComponent<Image>().color = new Color(1, 1, 1);
        limitedCard.GetComponent<Image>().color = new Color(1, 1, 1);
        specialCard.GetComponent<Image>().color = new Color(1, 1, 1);

        // Turn ship cards grey if not enough credits to purchase and unowned
        string ownPremium = PlayerPrefs.GetString("OwnPremium");
        string ownLimited = PlayerPrefs.GetString("OwnLimited");
        string ownSpecial = PlayerPrefs.GetString("OwnSpecial");
        if (credits < 3000 && string.IsNullOrEmpty(ownPremium))
            premiumCard.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);
        if (credits < 15000 && string.IsNullOrEmpty(ownLimited))
            limitedCard.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);
        if (credits < 20000 && string.IsNullOrEmpty(ownSpecial))
            specialCard.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);

        // Change label to "Owned" if owned
        if (!string.IsNullOrEmpty(ownPremium))
        {
            premiumCost.GetComponent<TextMeshProUGUI>().text = "Owned";
        }
        if (!string.IsNullOrEmpty(ownLimited))
        {
            limitedCost.GetComponent<TextMeshProUGUI>().text = "Owned";
        }
        if (!string.IsNullOrEmpty(ownSpecial))
        {
            specialCost.GetComponent<TextMeshProUGUI>().text = "Owned";
        }

        // Turn ship cards green if equipped
        string ship = PlayerPrefs.GetString("EquippedShip");
        if (string.IsNullOrEmpty(ship) || ship == "DefaultWhite")
        {
            PlayerPrefs.SetString("EquippedShip", "DefaultWhite");
            defaultShip.sprite = defaultShipArray[0];
            defaultCard.GetComponent<Image>().color = new Color(0, 1, 0);
        }
        else if (ship == "DefaultGreen")
        {
            defaultShip.sprite = defaultShipArray[1];
            defaultCard.GetComponent<Image>().color = new Color(0, 1, 0);
        }
        else if (ship == "DefaultYellow")
        {
            defaultShip.sprite = defaultShipArray[2];
            defaultCard.GetComponent<Image>().color = new Color(0, 1, 0);
        }
        else if (ship == "DefaultPurple")
        {
            defaultShip.sprite = defaultShipArray[3];
            defaultCard.GetComponent<Image>().color = new Color(0, 1, 0);
        }
        else if (ship == "PremiumWhite")
        {
            premiumShip.sprite = premiumShipArray[0];
            premiumCard.GetComponent<Image>().color = new Color(0, 1, 0);
        }
        else if (ship == "PremiumOrange")
        {
            premiumShip.sprite = premiumShipArray[1];
            premiumCard.GetComponent<Image>().color = new Color(0, 1, 0);
        }
        else if (ship == "PremiumYellow")
        {
            premiumShip.sprite = premiumShipArray[2];
            premiumCard.GetComponent<Image>().color = new Color(0, 1, 0);
        }
        else if (ship == "PremiumPurple")
        {
            premiumShip.sprite = premiumShipArray[3];
            premiumCard.GetComponent<Image>().color = new Color(0, 1, 0);
        }
        else if (ship == "Limited")
        {
            limitedCard.GetComponent<Image>().color = new Color(0, 1, 0);
        }
        else if (ship == "Special")
        {
            specialCard.GetComponent<Image>().color = new Color(0, 1, 0);
        }

        // Update amount of powerups in inventory
        HPcount.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HP_Powerup").ToString();
        MScount.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("MS_Powerup").ToString();
        TFcount.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("TF_Powerup").ToString();

        // Turn powerup cards grey if not enough credits to purchase
        if (credits < 100)
            HPCard.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);
        if (credits < 500)
            MSCard.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);
        if (credits < 1000)
            TFCard.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);
    }

    public void PurchaseShip(string ship)
    {
        int credits = PlayerPrefs.GetInt("Credits");
        if (ship == "PremiumWhite" || ship == "PremiumOrange" || ship == "PremiumYellow" || ship == "PremiumPurple")
        {
            string ownPremium = PlayerPrefs.GetString("OwnPremium");
            if (string.IsNullOrEmpty(ownPremium))   // If ship is not owned
            {
                if (credits < 3000)                 // Go to credit screen if not enough credits
                {
                    CreditScreen();
                }
                else                                // Go to purchase screen if enough credits
                {
                    premiumPurchasePopup.SetActive(true);
                }
            }
            else                                    // Change to ship if owned
            {
                ChangeShip(ship);
            }
        }
        else if (ship == "Limited")
        {
            string ownLimited = PlayerPrefs.GetString("OwnLimited");
            if (string.IsNullOrEmpty(ownLimited))   // If ship is not owned
            {
                if (credits < 15000)                // Go to credit screen if not enough credits
                {
                    CreditScreen();
                }
                else                                // Go to purchase screen if enough credits
                {
                    limitedPurchasePopup.SetActive(true);
                }
            }
            else                                    // Change to ship if owned                                     
            {
                ChangeShip(ship);
            }
        }
        else if (ship == "Special")
        {
            string ownSpecial = PlayerPrefs.GetString("OwnSpecial");
            if (string.IsNullOrEmpty(ownSpecial))   // If ship is not owned
            {
                if (credits < 20000)                // Go to credit screen if not enough credits
                {
                    CreditScreen();
                }
                else                                // Go to purchase screen if enough credits    
                {
                    specialPurchasePopup.SetActive(true);
                }
            }
            else                                    // Change to ship if owned  
            {
                ChangeShip(ship);
            }
        }
    }

    public void ConfirmPurchase(string ship)
    {
        int credits = PlayerPrefs.GetInt("Credits");
        if (ship == "Premium")
        {
            PlayerPrefs.SetInt("Credits", credits - 3000);
            PlayerPrefs.SetString("OwnPremium", "Own");
            premiumPurchasePopup.SetActive(false);
        }
        else if (ship == "Limited")
        {
            PlayerPrefs.SetInt("Credits", credits - 15000);
            PlayerPrefs.SetString("OwnLimited", "Own");
            premiumPurchasePopup.SetActive(false);
        }
        else if (ship == "Special")
        {
            PlayerPrefs.SetInt("Credits", credits - 20000);
            PlayerPrefs.SetString("OwnSpecial", "Own");
            premiumPurchasePopup.SetActive(false);
        }
        ReloadScene();
    }
    public void ChangeShip(string ship)
    {
        string ownPremium = PlayerPrefs.GetString("OwnPremium");
        string ownLimited = PlayerPrefs.GetString("OwnLimited");
        string ownSpecial = PlayerPrefs.GetString("OwnSpecial");

        if (ship == "DefaultWhite")
        {
            PlayerPrefs.SetString("EquippedShip", "DefaultWhite");
            defaultShip.sprite = defaultShipArray[0];
        }
        else if (ship == "DefaultGreen")
        {
            PlayerPrefs.SetString("EquippedShip", "DefaultGreen");
            defaultShip.sprite = defaultShipArray[1];
        }
        else if (ship == "DefaultYellow")
        {
            PlayerPrefs.SetString("EquippedShip", "DefaultYellow");
            defaultShip.sprite = defaultShipArray[2];
        }
        else if (ship == "DefaultPurple")
        {
            PlayerPrefs.SetString("EquippedShip", "DefaultPurple");
            defaultShip.sprite = defaultShipArray[3];
        }

        if (!string.IsNullOrEmpty(ownPremium))
        {
            if (ship == "PremiumWhite")
            {
                PlayerPrefs.SetString("EquippedShip", "PremiumWhite");
                premiumShip.sprite = premiumShipArray[0];
            }
            else if (ship == "PremiumOrange")
            {
                PlayerPrefs.SetString("EquippedShip", "PremiumOrange");
                premiumShip.sprite = premiumShipArray[1];
            }
            else if (ship == "PremiumYellow")
            {
                PlayerPrefs.SetString("EquippedShip", "PremiumYellow");
                premiumShip.sprite = premiumShipArray[2];
            }
            else if (ship == "PremiumPurple")
            {
                PlayerPrefs.SetString("EquippedShip", "PremiumPurple");
                premiumShip.sprite = premiumShipArray[3];
            }
        }

        if (!string.IsNullOrEmpty(ownLimited) && ship == "Limited")
        {
            PlayerPrefs.SetString("EquippedShip", "Limited");
        }
        if (!string.IsNullOrEmpty(ownSpecial) && ship == "Special")
        {
            PlayerPrefs.SetString("EquippedShip", "Special");
        }
        ReloadScene();
    }

    public void CreditScreen()
    {
        title.GetComponent<TextMeshProUGUI>().text = "Add Credits";
        overlay.SetActive(false);
        creditScreen.SetActive(true);
    }
    public void AddCredits(string amount)
    {
        paymentPopup.SetActive(true);
        paymentPopupCost.GetComponent<TextMeshProUGUI>().text = amount.ToString();
    }

    public void ConfirmCreditPurchase(GameObject paymentPopupCost)
    {
        int credits = PlayerPrefs.GetInt("Credits");
        string cost = paymentPopupCost.GetComponent<TextMeshProUGUI>().text;
        if (cost == "9.99")
        {
            PlayerPrefs.SetInt("Credits", credits + 1000);
        }
        else if (cost == "19.99")
        {
            PlayerPrefs.SetInt("Credits", credits + 3000);
        }
        else if (cost == "39.99")
        {
            PlayerPrefs.SetInt("Credits", credits + 10000);
        }
        else if (cost == "74.99")
        {
            PlayerPrefs.SetInt("Credits", credits + 20000);
        }
        ReloadScene();
    }

    public void PurchaseHP()
    {
        int credits = PlayerPrefs.GetInt("Credits");
        if (credits >= 100)          // Purchase HP powerup
        {
            PlayerPrefs.SetInt("HP_Powerup", PlayerPrefs.GetInt("HP_Powerup") + 1);
            PlayerPrefs.SetInt("Credits", credits - 100);
            ReloadScene();
        }
    }
    public void PurchaseMS()
    {
        int credits = PlayerPrefs.GetInt("Credits");
        if (credits >= 500)          // Purchase HP powerup
        {
            PlayerPrefs.SetInt("MS_Powerup", PlayerPrefs.GetInt("MS_Powerup") + 1);
            PlayerPrefs.SetInt("Credits", credits - 500);
            ReloadScene();
        }
    }
    public void PurchaseTF()
    {
        int credits = PlayerPrefs.GetInt("Credits");
        if (credits >= 1000)          // Purchase HP powerup
        {
            PlayerPrefs.SetInt("TF_Powerup", PlayerPrefs.GetInt("TF_Powerup") + 1);
            PlayerPrefs.SetInt("Credits", credits - 1000);
            ReloadScene();
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // Reload scene once a ship is changed
    }
}
