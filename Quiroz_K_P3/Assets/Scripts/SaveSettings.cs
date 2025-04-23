using UnityEngine;
using UnityEngine.UI;

public class SaveSettings : MonoBehaviour
{
    public GameObject playerCamera;
   
    public Button loadGame;
    public Button startGame;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        startGame.onClick.AddListener(OnClickStart);
        loadGame.onClick.AddListener(OnClickResume);
    }
    void OnClickStart()
    {
        Time.timeScale = 1;
        playerCamera.SetActive(true);
        
        startGame.gameObject.SetActive(false);
        loadGame.gameObject.SetActive(false);
        Camera.main.SendMessage("StartPlayerPos");
        Camera.main.SendMessage("NewGameInventory");
        gameObject.SetActive(false);
    }
    void OnClickResume()
    {
        Time.timeScale = 1;
        playerCamera.SetActive(true);
        
        startGame.gameObject.SetActive(false);
        loadGame.gameObject.SetActive(false);
        Camera.main.SendMessage("LoadPlayer");
        Camera.main.SendMessage("LoadGameInventory");
        gameObject.SetActive(false);
    }
}
