using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class levels : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI  museumInvasionBestScoreText;

    public void Start()
    {
        var museumInvasionScore = PlayerPrefs.GetInt("MuseumInvasion").ToString();
        setBestScoreText(museumInvasionScore);
    }

    public void handleStartLevel1Button()
    {
        SceneManager.LoadScene("MuseumInvasion");
    }

    public void handleBackBtn(String value)
    {
        SceneManager.LoadScene("Menu");
    }
    private void setBestScoreText(String value)
    {
        museumInvasionBestScoreText.text = String.Format(museumInvasionBestScoreText.text, value);
    }
}
