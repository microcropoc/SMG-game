using System;
using System.IO;
using System.Text;
using System.Xml;
using UnityEngine;

public sealed class ScoresStorageS
{
    #region SingletonePattern

    public static ScoresStorageS GetInstance()
    {
        if (instance == null)
            instance = new ScoresStorageS();
        return instance;
    }

    private static ScoresStorageS instance;

    private ScoresStorageS()
    {
        LoadScores();
    }

    #endregion

    #region PropertyAndVariable

    #region LevelScore

    #region OneLevel
    public int LevelOneScore
    {
        get { return _levelOneScore; }
        set
        {
            if (value > _levelOneScore)
            {
                _levelOneScore = value;
                SaveScores();
            }
        }
    }

    int _levelOneScore;

    #endregion

    #region TwoLevel
    public int LevelTwoScore
    {
        get { return _levelTwoScore; }
        set
        {
            if (value > _levelTwoScore)
            {
                _levelTwoScore = value;
                SaveScores();
            }
        }
    }

    int _levelTwoScore;

    #endregion

    #region ThreeLevel
    public int LevelThreeScore
    {
        get { return _levelThreeScore; }
        set
        {
            if (value > _levelThreeScore)
            {
                _levelThreeScore = value;
                SaveScores();
            }
        }
    }

    int _levelThreeScore;

    #endregion

    #region FourLevel
    public int LevelFourScore
    {
        get { return _levelFourScore; }
        set
        {
            if (value > _levelFourScore)
            {
                _levelFourScore = value;
                SaveScores();
            }
        }
    }

    int _levelFourScore;

    #endregion

    #endregion

    #endregion

    #region Method

    bool SaveScores()
    {
        string path = Application.persistentDataPath + "/SaveFile.smg";
        //    Debug.Log("SaveScores--------------------");
        try
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (XmlTextWriter xmlOut = new XmlTextWriter(fs, Encoding.Unicode))
                {
                    #region XML
                    xmlOut.Formatting = Formatting.Indented;

                    //начало документа
                    xmlOut.WriteStartDocument();
                    xmlOut.WriteStartElement("GameScores");
                    xmlOut.WriteAttributeString("Data", DateTime.Now.ToString());

                    //список уровней
                    //  Debug.Log("SaveScores.level--------------------");
                    //level1----
                    xmlOut.WriteStartElement("level1");
                    xmlOut.WriteAttributeString("Score", LevelOneScore.ToString());
                    xmlOut.WriteEndElement();
                    //  Debug.Log("level1 " + LevelOneScore.ToString());
                    //----------

                    //level2----
                    xmlOut.WriteStartElement("level2");
                    xmlOut.WriteAttributeString("Score", LevelTwoScore.ToString());
                    xmlOut.WriteEndElement();
                    //   Debug.Log("level2 " + LevelTwoScore.ToString());
                    //----------

                    //level3----
                    xmlOut.WriteStartElement("level3");
                    xmlOut.WriteAttributeString("Score", LevelThreeScore.ToString());
                    xmlOut.WriteEndElement();
                    //   Debug.Log("level3 " + LevelThreeScore.ToString());
                    //----------

                    //level4----
                    xmlOut.WriteStartElement("level4");
                    xmlOut.WriteAttributeString("Score", LevelFourScore.ToString());
                    xmlOut.WriteEndElement();
                    //    Debug.Log("level4 " + LevelFourScore.ToString());
                    //----------

                    //-----------------------------
                    //     Debug.Log("/SaveScores.level--------------------");
                    xmlOut.WriteEndElement();
                    xmlOut.WriteEndDocument();
                    #endregion
                }
            }
        }
        catch
        {
            return false;
        }
        //    Debug.Log("SaveScores TRUE)");
        return true;
    }

    bool LoadScores()
    {
        string path = Application.persistentDataPath + "/SaveFile.smg";
        //   Debug.Log("LoadScores----------------");
        if (File.Exists(path))
        {

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (XmlTextReader xmlIn = new XmlTextReader(fs))
                {
                    try
                    {
                        #region XML

                        //setting xmlIn
                        xmlIn.WhitespaceHandling = WhitespaceHandling.None;
                        xmlIn.MoveToContent();
                        if (xmlIn.Name != "GameScores")
                            throw new ArgumentException("Incorrect File Format.");


                        //цикл для чтения тегов элементов проекта
                        #region ReadElementTag

                        do
                        {
                            if (!xmlIn.Read())
                                break;
                            if (xmlIn.NodeType == XmlNodeType.EndElement)
                                continue;

                            switch (xmlIn.Name)
                            {
                                case "level1":
                                    //        Debug.Log("LoadScores.level----------------");
                                    //        Debug.Log("Level1 "+ xmlIn.GetAttribute("Score"));
                                    _levelOneScore = int.Parse(xmlIn.GetAttribute("Score"));
                                    break;
                                case "level2":
                                    //    Debug.Log("Level2 " + xmlIn.GetAttribute("Score"));
                                    _levelTwoScore = int.Parse(xmlIn.GetAttribute("Score"));
                                    break;
                                case "level3":
                                    //   Debug.Log("Level3 " + xmlIn.GetAttribute("Score"));
                                    _levelThreeScore = int.Parse(xmlIn.GetAttribute("Score"));
                                    break;
                                case "level4":
                                    //      Debug.Log("Level4 " + xmlIn.GetAttribute("Score"));
                                    _levelFourScore = int.Parse(xmlIn.GetAttribute("Score"));
                                    //    Debug.Log("/LoadScores.level----------------");
                                    break;


                            }
                        } while (!xmlIn.EOF);

                        #endregion

                        //--------------

                        #endregion
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            // Debug.Log("LoadScores TRUE)");
            return true;
        }
        return false;
    }

    #endregion

}
