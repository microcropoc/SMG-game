using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using UnityEngine;


public class StackBulletS
{

    #region SingletonePattern

    public static StackBulletS GetInstance()
    {
        if (instance == null)
            instance = new StackBulletS();
        return instance;
    }

    private static StackBulletS instance;

    private StackBulletS()
    {

    }

    #endregion

    GameObject[] _masBullet;
    int size = 0;

    public void init(int col)
    {
        size = 0;
        _masBullet = new GameObject[col];

    }


    public void Pop(GameObject Bullet, Vector3 position, Quaternion rotation)
    {
        if (size == 0)
        {
            MonoBehaviour.Instantiate(Bullet, position, rotation);
            return;
        }
        GameObject temp = _masBullet[--size];
        temp.SetActive(true);
        temp.transform.position = position;
        temp.transform.rotation = rotation;
    }

    public void Push(UnityEngine.GameObject newElement)
    {
        if (_masBullet.Length < size)
        {
            newElement.SetActive(false);
            _masBullet[size++] = newElement;
        }
        else
        {
            MonoBehaviour.Destroy(newElement);
        }
    }

}

public class StackPanzerTrackS
{
    #region SingletonePattern

    public static StackPanzerTrackS GetInstance()
    {
        if (instance == null)
            instance = new StackPanzerTrackS();
        return instance;
    }

    private static StackPanzerTrackS instance;

    private StackPanzerTrackS()
    {

    }

    #endregion


    GameObject[] _masPanzerTrack;
    int size = 0;

    public void init(int col)
    {
        size = 0;
        _masPanzerTrack = new GameObject[col];

    }


    public void Pop(GameObject Track, Vector3 position, Quaternion rotation)
    {
        if (size == 0)
        {
            MonoBehaviour.Instantiate(Track, position, rotation);
            return;
        }
        GameObject temp = _masPanzerTrack[--size];
        temp.SetActive(true);
        temp.transform.position = position;
        temp.transform.rotation = rotation;
    }



    public void Push(UnityEngine.GameObject newElement)
    {
        if (_masPanzerTrack.Length < size)
        {
            newElement.SetActive(false);
            _masPanzerTrack[size++] = newElement;
        }
        else
        {
            MonoBehaviour.Destroy(newElement);
        }
    }

    #region UnUsed
    public bool isEmpty()
    {
        return size == 0;
    }

    public UnityEngine.GameObject Peek()
    {
        if (size == 0)
        {
            throw new InvalidOperationException();
        }

        return _masPanzerTrack[size - 1];
    }
    #endregion
}


public static class GameParam
{

    #region GunPosition


    public static Vector2 GunPosition
    {
        get { return _gunPosition; }
        set { _gunPosition = value; }
    }

    static Vector2 _gunPosition;

    #endregion

    //объекты одиночки по умолчанию
    #region SingletoneObject

    //ссылка на объект одиночку для работы с счётом
    public static ScoresStorageS ScoresStorageForGame { get; set; }

    //ссылка на объект одиночку для стека с пулями
    public static StackBulletS StackBulletForGun { get; set; }

    //ссылка на объект одиночку для стека с треками танков
    public static StackPanzerTrackS StackPanzerTrackForTanks { get; set; }
    
    #endregion
   

    //Состояние паузы
    #region Paused
           
    public static bool IsPaused{get;set;}

    #endregion

    //звук в игре
    #region SongOnOff

    public static bool IsSongActive
    {
        get
        {
            return _isSongActive;
        } 
        set
        {
            _isSongActive = value;
        }
    }

    static bool _isSongActive = true;

    #endregion

    //режим игры и метод завершения игры
    #region GameModeAndGameOver


    public static byte SelectGameMode { get { return _SelectGameMode; } set { _SelectGameMode = value; } }
    static byte _SelectGameMode = 0;

    //при завершении игры
//сначало выполнить
    public static bool RecordScoreBeforeGameOver()
    {
        bool isNewScore=false;

        switch (_currentLevel)
        {
            case "Level1":
                isNewScore = GameParam.ScoresStorageForGame.LevelOneScore < GameParam.ScoredSMG;
                ScoresStorageForGame.LevelOneScore = ScoredSMG;
                break;
            case "Level2":
                isNewScore = GameParam.ScoresStorageForGame.LevelTwoScore < GameParam.ScoredSMG;
                ScoresStorageForGame.LevelTwoScore = ScoredSMG;
                break;
            case "Level3":
                isNewScore = GameParam.ScoresStorageForGame.LevelThreeScore < GameParam.ScoredSMG;
                ScoresStorageForGame.LevelThreeScore = ScoredSMG;
                break;
            case "Level4":
                isNewScore = GameParam.ScoresStorageForGame.LevelFourScore < GameParam.ScoredSMG;
                ScoresStorageForGame.LevelFourScore = ScoredSMG;
                break;
        }

        return isNewScore;
    }
//потом выполнить
    public static void GameOver()
    {
        switch (_SelectGameMode)
        {
            case 1:
                _SelectGameMode = 2;
                Application.LoadLevel("Level2");
                break;
            case 2:
                _SelectGameMode = 3;
                Application.LoadLevel("Level3");
                break;
            case 3:
                _SelectGameMode = 0;
                Application.LoadLevel("Level4");
                break;

            default:
                Application.LoadLevel("Menu");
                break;
        }
    }

    #endregion

    //Точка конца игры
    #region GamePointEnd
    public static float PointEnd { get { return _pointEnd; } set { _pointEnd = value; } }
    static float _pointEnd;

    #endregion


    //жизни игрока
    #region Life

    public static int LifeSMG { get { return _LifeSMG; } set { _LifeSMG = value; } }
    static int _LifeSMG = 5;
    public const int _constLifeSMG = 5;

    #endregion


    //очки
    #region CurrentScore

    public static int ScoredSMG{ get {return _ScoredSMG;} set {_ScoredSMG=value;} }
    static int _ScoredSMG = 0;
    public const int _constScoredSMG = 0;

    #endregion

    //название текущего уровня
    #region CurrentLevel

    public static string CurrentLevel { get { return _currentLevel; } set { _currentLevel = value; } }
    static string _currentLevel = string.Empty;

    #endregion


    //задержка между выстрелами
    #region delayBetWeenShots

    public static float SleepFire
    {
        get
        {
            return _SleepFire;
        }
        set
        {
            if (value > _constSleepFire)
            {
                _SleepFire = _constSleepFire;
            }
            else
            {
                _SleepFire = value;
            }
        }
    }
    static float _SleepFire = 5.55f;
    public const float _constSleepFire = 5.55f;

    #endregion


    //множитель разброса путь
    #region RazbrosFactor

    public static float RazbrosFactor { get { return _RazbrosFactor; } set { _RazbrosFactor = value; } }
    static float _RazbrosFactor = 0.025f;
    public const float _constRazbrosFactor = 0.025f;

    #endregion


    //нагрев ствола(разброс)
    #region OverHead

    public static int Razbros { get { return _Razbros > 1000 ? 1000 : _Razbros; } set { _Razbros = value; } }
    static int _Razbros = 0;
    public const int _constRazbros = 0;

    #endregion

    //импульс пули
    #region ImpulsBullet
        public static float ImpulsBulletX{get{return _X;} set{_X=value;}}
        static float _X=0;
        //const float _constX=0;
        public static float ImpulsBulletY { get { return _Y; } set { _Y = value; } }
        static float _Y=0;
        //const float _constY=0;
    #endregion

    //скорость пули
    #region BullSpeed
    public static float BulletSpeed { get { return _BulletSpeed; } set { _BulletSpeed = value; } }
    static float _BulletSpeed = 1.25f;
    public const float _constBulletSpeed = 1.25f;

    #endregion
       

    //конструктор
    static GameParam()
    {
        ScoresStorageForGame = ScoresStorageS.GetInstance();

        StackBulletForGun = StackBulletS.GetInstance();
        StackPanzerTrackForTanks = StackPanzerTrackS.GetInstance();
    }

    public static void init(string currentLevel)
    {
        _LifeSMG = _constLifeSMG;
        _ScoredSMG = _constScoredSMG;
        _RazbrosFactor = _constRazbrosFactor;
        _Razbros = _constRazbros;
        _BulletSpeed = _constBulletSpeed;
        _SleepFire = _constSleepFire;
        _X = 0;
        _Y = 0;
        CurrentLevel = currentLevel;
        IsPaused = false;
    }
}

