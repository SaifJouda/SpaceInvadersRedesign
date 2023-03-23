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
                pathName= "DefaultShips.png";
                Debug.Log("basic");
                break;
            case shipType.green:
                pathName= "GreenDefaultShip.png";
                break;
            case shipType.yellow:
                pathName= "YellowDefaultShip.png";
                break;
            case shipType.purple:
                pathName= "PurpleDefaultShip.png";
                break;
            case shipType.pWhite:
                pathName= "PremiumShipWhite.png";
                break;
            case shipType.pRed:
                pathName= "PremiumShipRed.png";
                break;
            case shipType.pPurple:
                pathName= "PremiumShipPurple.png";
                break;
            case shipType.pYellow:
                pathName= "PremiumShipYellow.png";
                break;
            case shipType.special:
                pathName= "SpecialShip2.png";
                break;
            case shipType.limited:
                pathName= "LimitedGPTEdition.png";
                break;
       
        }
        texture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/ArtAsset/Players/"+pathName, typeof(Texture2D));
        if(texture!=null)
        {
            Debug.Log(texture);
            Debug.Log("texture");
            spriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f),450); 
        }
    }
}
