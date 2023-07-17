using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0.0f;
    public Text scoreText;

    private bool isDead = false;

    public DeathMenu deathMenu;

    void Update()
    {
        if (isDead)
            return;

        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();
    }

    public void OnDeath()
    {
        isDead = true;

        if (PlayerPrefs.GetFloat("HighScore") < score)
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }

        deathMenu.ToggleEndMenu(score);
    }
}
