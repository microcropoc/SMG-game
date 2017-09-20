using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIrender : MonoBehaviour
{

    #region VariableAndObject

    public Text lifeText;
    int _currentLife = 0;
    public Text scoredText;
    int _currentScored = 0;
    public Slider OHslider;
    int _currentOH = 0;

    //ссылка на панель паузы
    #region Pause

    public GameObject PausePanel;

    #endregion

    //ссылка на панель завершения игры
    #region GameOver

    public GameObject GameOverPanel;
    bool gameOverStat = false;

    #endregion

    #endregion

    

    // Use this for initialization
    void Start () 
    {


        PausePanel.SetActive(GameParam.IsPaused);

        GameOverPanel.SetActive(gameOverStat);

        Debug.Log(Application.loadedLevelName);
    
    }
    
    // Update is called once per frame

   // bool isTwoEscape;

    void Update ()
    {
        //При нажати на Esc
        #region PressToEsc

        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.Menu)) && !gameOverStat)
        {
            if (GameParam.IsPaused)
            {
                Time.timeScale = 1;
                GameParam.IsPaused = false;
                PausePanel.SetActive(GameParam.IsPaused);
            }
            else
            {
                Time.timeScale = 0;
                GameParam.IsPaused = true;
                PausePanel.SetActive(GameParam.IsPaused);
            }
        }

        #endregion

        //обновление стауса жизней и (если жизней <= 0) вызываем гейм овер
        #region refreshLive

        if (_currentLife != GameParam.LifeSMG)
        {
            _currentLife = GameParam.LifeSMG;
            if (_currentLife <= 0)
            {
                if (!gameOverStat)
                {
                    Time.timeScale = 0;
                    GameParam.IsPaused = true;
                    GameOverPanel.SetActive(true);
                    Debug.Log("GameOverAction");
                    gameOverStat = true;
                }

            }
            lifeText.text = "[" + _currentLife + "]";

        }

        #endregion

        //обновление статуса счёта
        #region refreshScore

        if (_currentScored != GameParam.ScoredSMG)
        {
            _currentScored = GameParam.ScoredSMG;
            scoredText.text = "[" + _currentScored + "]";
        }

        #endregion

        //обновление статуса перегрева
        #region refreshOH

        if (_currentOH != (GameParam.Razbros / 10))
        {
            _currentOH = (GameParam.Razbros / 10);
            OHslider.value = _currentOH;
        }

        #endregion

        
    }


    //Методы событий панели паузы
    #region forPause

    public void OnClickToContinue()
    {
        Time.timeScale = 1;
        GameParam.IsPaused = false;
        PausePanel.SetActive(GameParam.IsPaused);
    }

    public void OnClickToMenu()
    {
        Application.LoadLevel("Menu");
        GameParam.Razbros = 0;
        Time.timeScale = 1;
        GameParam.IsPaused = false;
        PausePanel.SetActive(GameParam.IsPaused);
    }

    public void OnClickToExit()
    {
        Application.Quit();
    }

    #endregion

    //Методы событий панели завершения игры
    #region forGameOver

    public void OnClickToGameOver()
    {
       // GameParam.Razbros = 0;
        Time.timeScale = 1;
        GameParam.IsPaused = false;
        GameParam.GameOver();
    }

    #endregion
}
