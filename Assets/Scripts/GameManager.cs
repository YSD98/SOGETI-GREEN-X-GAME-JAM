using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager mInstance;


    /// <summary>
    /// text element which will be used to show score
    /// </summary>
    [SerializeField] Text scoreText, informationText;
    [SerializeField] Text itemName;
    [SerializeField] Image itemImage;
    [SerializeField] List<Sprite> itemSprite;
    int score = 0;


    PlayerMovement movement;

    private void Awake()
    {
        if(mInstance == null)
        {
            mInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        movement = FindObjectOfType<PlayerMovement>();
    }


    /// <summary>
    /// it is called when the player is ready to play the game 
    /// and move into the world
    /// </summary>
    /// <param name="_state"></param>
    public void ReadyToPlay(bool _state)
    {
        movement.SetPlayStatus(_state);
    }


    /// <summary>
    /// it updates the score in game screen
    /// </summary>
    /// <param name="_score"></param>
    /// <param name="operation"></param>
    public void ChangeScore(int _score, string operation)
    {
        if (operation.Equals("Add"))
        {
            score += _score;
        }
        else
        {
            score -= _score;
        }

        scoreText.text = "Score : "+score + "";
        Debug.Log(score);

    }


    public void PauseGame()
    {
        ReadyToPlay(false);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        ReadyToPlay(true);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        ReadyToPlay(false);
    }

    public void SetGameInformation(string _info)
    {
        informationText.text = _info;
    }

    public void SetItemInfo(string _itemname)
    { 
        foreach(Sprite sprite in itemSprite)
        {
            if (sprite.name.Equals(_itemname))
            {
                itemImage.sprite = sprite;
                break;
            }
        }
    }
}
