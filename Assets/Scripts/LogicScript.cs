using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogicScript : MonoBehaviour {

    public Text movementText;

    public void UpdateMovementText(int moveCounter) {
        movementText.text = moveCounter.ToString();
    }

    public void restartButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void nextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}