using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ShipTypeController : MonoBehaviour
{
    public enum shipType {basic,green,yellow,purple,pWhite,pRed,pPurple,pYellow,limited,special};
    private GameObject player;
    private SpriteRenderer spriteRenderer;
    //AssetBundle assetBundle = AssetBundle.LoadFromFile(Application.dataPath + "/AssetBundles/players");
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("Player");
        spriteRenderer = player.GetComponent<SpriteRenderer>();   
        changeShip();
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)) changeShip();
    }

    public void changeShip()
    {
        Texture2D texture = null;//Resources.Load<Texture2D>("ArtAsset/Players/DefaultShips.png");
        string pathName="";
        string ship = PlayerPrefs.GetString("EquippedShip");
        if (ship == "DefaultWhite")
        {
            pathName = "DefaultShips";
        }
        else if (ship == "DefaultGreen")
        {
            pathName = "GreenDefaultShip";
        }
        else if (ship == "DefaultYellow")
        {
            pathName = "YellowDefaultShip";
        }
        else if (ship == "DefaultPurple")
        {
            pathName = "PurpleDefaultShip";
        }
        else if (ship == "PremiumWhite")
        {
            pathName = "PremiumShipWhite";
        }
        else if (ship == "PremiumOrange")
        {
            pathName = "PremiumShipRed";
        }
        else if (ship == "PremiumYellow")
        {
            pathName = "PremiumShipPurple";
        }
        else if (ship == "PremiumPurple")
        {
            pathName = "PremiumShipYellow";
        }
        else if (ship == "Limited")
        {
            pathName = "LimitedGPTEdition";
        }
        else if (ship == "Special")
        {
            pathName = "SpecialShip2";
        }

        //texture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/ArtAsset/Players/"+pathName, typeof(Texture2D));
        texture = Resources.Load<Texture2D>("ArtAsset/Players/" + pathName);
        if (texture!=null)
        {
            spriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f),450); 
        }
    }
}
