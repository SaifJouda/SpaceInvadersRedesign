using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ShipTypeController : MonoBehaviour
{
    public enum shipType {basic,green,yellow,purple,pWhite,pRed,pPurple,pYellow,limited,special};
    private GameObject player;
    public shipType typeOfShip;
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
        switch(typeOfShip)
        {
            case shipType.basic:
                pathName= "DefaultShips";
                break;
            case shipType.green:
                pathName= "GreenDefaultShip";
                break;
            case shipType.yellow:
                pathName= "YellowDefaultShip";
                break;
            case shipType.purple:
                pathName= "PurpleDefaultShip";
                break;
            case shipType.pWhite:
                pathName= "PremiumShipWhite";
                break;
            case shipType.pRed:
                pathName= "PremiumShipRed";
                break;
            case shipType.pPurple:
                pathName= "PremiumShipPurple";
                break;
            case shipType.pYellow:
                pathName= "PremiumShipYellow";
                break;
            case shipType.special:
                pathName= "SpecialShip2";
                break;
            case shipType.limited:
                pathName= "LimitedGPTEdition";
                break;
       
        }
        //texture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/ArtAsset/Players/"+pathName, typeof(Texture2D));
        texture = Resources.Load<Texture2D>("ArtAsset/Players/" + pathName);
        if (texture!=null)
        {
            spriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f),450); 
        }
    }
}
