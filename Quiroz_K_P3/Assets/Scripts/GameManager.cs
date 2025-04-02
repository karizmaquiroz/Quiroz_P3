using UnityEngine;
using UnityEngine.SceneManagement;


//scene manager

public class GameManager : MonoBehaviour
{
    public GameObject GameScreen0; 
    public GameObject MainMenuUI; 
    public GameObject CreditUI;
   

    public void Awake()
    {
        MainMenuUI.SetActive(true);

    }



    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void quit() //inside gameOver when pressed application quits
    {
        SceneManager.LoadScene("Credits");

        Application.Quit();
    }


    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");

    }


    public void startGame()
    {
        SceneManager.LoadScene("Level1");


    }

    public void creditButton()
    {
        SceneManager.LoadScene("Credits");
        //Debug.Log("In the credits scene");




    }

    public void creditBackButton()
    {
        SceneManager.LoadScene("MainMenu");
        //Debug.Log("Back in MainMenu scene");

    }
}
