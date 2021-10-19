using UnityEngine;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverCanvasController : MonoBehaviour
{
    [SerializeField] private FloatReference currentTime = default(FloatReference);
    [SerializeField] private StringCollection currentLeaderboard = default(StringCollection);
    [SerializeField] private TextMeshProUGUI currentTimeLabel = default(TextMeshProUGUI);
    [SerializeField] private TextMeshProUGUI leaderboardText = default(TextMeshProUGUI);
    //[SerializeField] private AudioClipGameEvent sfxToPlay = default(AudioClipGameEvent);
    //[SerializeField] private AudioClip uIConfirmAudio = default(AudioClip);

    public void ShowGameOver()
    {
        currentTimeLabel.text = $"{(int)currentTime.Value} seconds";
        leaderboardText.text = "Loading Leaderboard...";
    }

    public void ShowLeaderboard()
    {
        leaderboardText.text = string.Empty;
        foreach (var currentPosition in currentLeaderboard)
        {
            leaderboardText.text += currentPosition;
            leaderboardText.text += "\n";
        }
    }

    public void RestartLevel()
    {
        //sfxToPlay.Raise(uIConfirmAudio);
        SceneManager.LoadScene(0);
    }
}
