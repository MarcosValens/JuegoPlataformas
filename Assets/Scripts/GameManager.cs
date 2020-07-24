using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text lifes_txt;
    public Text coin_txt;
    public Text record_txt;
    public Text actualRecord_txt;

    public GameObject gameoverPanel;

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifes_txt.text = "X " + player.getLifes.ToString();
        coin_txt.text = "X " + player.getCoins.ToString();

        if (player.getLifes <= 0 && gameoverPanel.activeSelf == false) {
            gameoverPanel.SetActive(true);
            record_txt.text = PlayerPrefs.GetInt("Coins").ToString();
            actualRecord_txt.text = player.getCoins.ToString();
        }
    }

    public void Restart() {
        SceneManager.LoadScene("Game");
    }
}
