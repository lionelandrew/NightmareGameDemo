using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public GameObject startGameButton;
    public GameObject storeButton;
    public GameObject title;

    public GameObject storePanel;

    public DisplayStoreItems displayStore;

    void Awake()
    {
        SP.OnRegisteredUserToSession += SP_OnRegisteredUserToSession;
    }

    void SP_OnRegisteredUserToSession(string obj)
    {
        startGameButton.SetActive(true);
        storeButton.SetActive(true);
        title.SetActive(true);
    }

    public void StartGame()
    {
        Application.LoadLevel("Level 01");
    }

    public void OpenStore()
    {
        storePanel.SetActive(true);
        startGameButton.SetActive(false);
        storeButton.SetActive(false);
        title.SetActive(false);

        displayStore.DisplayItems();

        SP.GetFreeCurrencyBalance(0, null);
        SP.GetPaidCurrencyBalance(null);
    }

    public void CloseStore()
    {
        storePanel.SetActive(false);
        startGameButton.SetActive(true);
        storeButton.SetActive(true);
        title.SetActive(true);
    }
}
