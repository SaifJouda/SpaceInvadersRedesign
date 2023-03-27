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

    public TextMeshProUGUI creditLabel;

    //private int credits = PlayerPrefs.GetInt("Credit");
    private int credits = 4000;

    // Start is called before the first frame update
    void Start()
    {
        // Update player's credit amount
        creditLabel.text = credits.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Turn ship cards grey if not enough credits to purchase
        if (credits < 3000)
            premiumCard.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);
        if (credits < 15000)
            limitedCard.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);
        if (credits < 20000)
            specialCard.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);

        // Turn ship cards white and change label to "Owned" if owned
        string ownPremium = PlayerPrefs.GetString("OwnPremium");
        string ownLimited = PlayerPrefs.GetString("OwnLimited");
        string ownSpecial = PlayerPrefs.GetString("OwnSpecial");
        if (!string.IsNullOrEmpty(ownPremium))
        {
            premiumCost.GetComponent<TextMeshProUGUI>().text = "Owned";
            premiumCard.GetComponent<Image>().color = new Color(1, 1, 1);
        }
        else if (!string.IsNullOrEmpty(ownLimited))
        {
            limitedCost.GetComponent<TextMeshProUGUI>().text = "Owned";
            limitedCard.GetComponent<Image>().color = new Color(1, 1, 1);
        }
        else if (!string.IsNullOrEmpty(ownSpecial))
        {
            specialCost.GetComponent<TextMeshProUGUI>().text = "Owned";
            specialCard.GetComponent<Image>().color = new Color(1, 1, 1);
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
        else if (ship == "PremiumRed")
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
    }

    public void PurchaseShip(string ship)
    {
        if (ship == "PremiumWhite")
        {
            string ownPremium = PlayerPrefs.GetString("OwnPremium");
            if (credits < 3000)
            {
                AddCredits();
            }
            if (string.IsNullOrEmpty(ownPremium))   // Confirm purchase
            {

            }
            else
            {
                ChangeShip(ship);
            }
        }
        if (ship == "Limited")
        {
            string ownLimited = PlayerPrefs.GetString("OwnLimited");
            if (credits < 15000)
            {
                AddCredits();
            }
            if (string.IsNullOrEmpty(ownLimited))   // Confirm purchase
            {

            }
            else
            {
                ChangeShip(ship);
            }

        }
        if (ship == "Special")
        {
            string ownSpecial = PlayerPrefs.GetString("OwnSpecial");
            if (credits < 20000)
            {
                AddCredits();
            }
            if (string.IsNullOrEmpty(ownSpecial))   // Confirm purchase
            {

            }
            else
            {
                ChangeShip(ship);
            }

        }
    }
    public void ChangeShip(string ship)
    {
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

        string ownPremium = PlayerPrefs.GetString("OwnPremium");
        if (!string.IsNullOrEmpty(ownPremium))
        {
            if (ship == "PremiumWhite")
            {
                PlayerPrefs.SetString("EquippedShip", "PremiumWhite");
                premiumShip.sprite = premiumShipArray[0];
            }
            else if (ship == "PremiumRed")
            {
                PlayerPrefs.SetString("EquippedShip", "PremiumRed");
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
            ReloadScene();
        }
    }

    void AddCredits()
    {
        title.GetComponent<TextMeshProUGUI>().text = "Add Credits";
        overlay.SetActive(false);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // Reload scene once a ship is changed
    }
}
