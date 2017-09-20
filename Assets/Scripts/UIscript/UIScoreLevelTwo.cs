using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScoreLevelTwo : MonoBehaviour {

    Text _scoreText;

    // Use this for initialization
    void Start()
    {
        _scoreText = this.gameObject.GetComponent<Text>();
        _scoreText.text = GameParam.ScoresStorageForGame.LevelTwoScore.ToString();
    }
}
