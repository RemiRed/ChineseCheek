using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class MenuSceneManager : MonoBehaviour {

    [SerializeField]
    GameObject newGameMenu;

    public void StartGame(int players)              // Startar nytt game med antal x spelare.
    {
        StreamWriter newGame = File.CreateText(Application.persistentDataPath + "/ammountOfPlayers.dat");
        newGame.WriteLine(players);
        newGame.Close();
        SceneManager.LoadScene(1);
        
    }
    public void ToggleNewGame()
    {
        newGameMenu.SetActive(!newGameMenu.activeSelf);
    }
    public void LoadGame()
    {
        if (!File.Exists(Application.persistentDataPath + "/savedGame.dat")) {
            return;
        }
        SceneManager.LoadScene(1);
    }
    public void DeleteGame()
    {
        File.Delete(Application.persistentDataPath + "/savedGame.dat");
    }

    public void Quit()
    {
        Application.Quit();
    }

	
	
}

