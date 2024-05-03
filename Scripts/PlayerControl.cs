using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float speed = 1.0f;
    public Text scoreText;

    private int score;
    private int remainingEnemies;
    private CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        remainingEnemies = 10;
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mov2d = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 mov3d = new Vector3(mov2d.x * Time.deltaTime * speed, 0f, mov2d.y * Time.deltaTime * speed);
    }

    public void ScoreUp(int scoreIncrease) 
    {
        score += scoreIncrease;
        remainingEnemies--;

        UpdateScoreText();

        if (remainingEnemies <= 0)
        {
            StartCoroutine(ShowClearText());
            StartCoroutine(RestartGame());
        }
    }


    void UpdateScoreText()
    {
        scoreText.text = "처치한 적: " + score + "\n남은 적: " + remainingEnemies;

    }

    IEnumerator ShowClearText()
    {
        yield return new WaitForSeconds(1.0f);
        scoreText.text = "CLEAR!";
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2.0f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
