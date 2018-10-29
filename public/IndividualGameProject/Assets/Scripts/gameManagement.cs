using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManagement : MonoBehaviour {

    public GameObject player;

    public Button resetButton;

	// Use this for initialization
	void Start () {
        resetButton.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.y < -12) {
            resetButton.gameObject.SetActive(true);
        }
	}

    public void ResetGame() {
        SceneManager.LoadScene("SampleLevel");
    }
}
