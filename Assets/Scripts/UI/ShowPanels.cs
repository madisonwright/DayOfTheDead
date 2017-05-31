using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowPanels : MonoBehaviour {

	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 


	//Call this function to activate and display the main menu panel during the main menu
	public void ShowMenu()
	{
		menuPanel.SetActive (true);
	}

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu()
	{
		menuPanel.SetActive (false);
	}

    public void StartTutorial() {
        SceneManager.LoadScene("Tutorial");
        HideMenu();
    }

}
