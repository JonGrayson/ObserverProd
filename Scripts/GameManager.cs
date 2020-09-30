using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool gameHasEnded = false;

	public float restartDelay = 1f;

	public GameObject completeLevelUI;

    public GameObject player;
    public GameObject playerHat;
    
    public void Start()
    {
        playerHat.SetActive(false);
    }
    

    public void CompleteLevel ()
	{
		completeLevelUI.SetActive(true);
	}

	public void EndGame ()
	{
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
			Debug.Log("GAME OVER");
			Invoke("Restart", restartDelay);
		}
	}

	void Restart ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    //alarm recieved
    private void OnEnable()
    {
        PlayerMovement.onColorChange += ColorChange;
        PlayerMovement.onGrowHat += GrowHat;
        EndTrigger.onTwitch += Twitch;
    }

    private void OnDisable()
    {
        PlayerMovement.onColorChange -= ColorChange;
        PlayerMovement.onGrowHat -= GrowHat;
        EndTrigger.onTwitch -= Twitch;
    }

    void ColorChange()
    {
        //player.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
        player.GetComponent<Renderer>().material.color = Color.cyan;
    }

    void GrowHat()
    {
        playerHat.SetActive(true);
    }

    void Twitch()
    {
        EndTrigger.onTwitch -= Twitch;
        Application.OpenURL("https://www.twitch.tv/mafiaelf");
    }

}
