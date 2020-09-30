using UnityEngine;

public class EndTrigger : MonoBehaviour {

	public GameManager gameManager;

    public delegate void twitchLink();
    public static event twitchLink onTwitch;

    void OnTriggerEnter ()
	{
        onTwitch?.Invoke();
		gameManager.CompleteLevel();
	}

}
