using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyTypeController : MonoBehaviour
{
    public enum enemyType {enemy1,enemy2,enemy3,enemy4}
    public enemyType typeOfEnemy;
    public Color enemyColor;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   
        changeEnemy();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)) changeEnemy();
    }

    public void setRandomType(int num)
    {
        switch(num)
        {
            case 1:
                typeOfEnemy= enemyType.enemy1;
                break;
            case 2:
                typeOfEnemy= enemyType.enemy2;
                break;
            case 3:
                typeOfEnemy= enemyType.enemy3;
                break;
            case 4:
                typeOfEnemy= enemyType.enemy4;
                break;
        }

    }

    public void changeEnemy()
    {
        Texture2D texture = null;//Resources.Load<Texture2D>("ArtAsset/Players/DefaultShips.png");
        string pathName="";
        switch(typeOfEnemy)
        {
            case enemyType.enemy1:
                pathName= "EnemyType1";
                break;
            case enemyType.enemy2:
                pathName= "EnemyType2";
                break;
            case enemyType.enemy3:
                pathName= "EnemyType3";
                break;
            case enemyType.enemy4:
                pathName= "EnemyType4";
                break;
        }
        //texture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/ArtAsset/Enemies/"+pathName, typeof(Texture2D));
        texture = Resources.Load<Texture2D>("ArtAsset/Enemies/" + pathName);
        if (texture!=null)
        {
            Debug.Log(texture);
            spriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f),800); 
            spriteRenderer.color = enemyColor;
        }

    }
}
