using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static void GameOver()
    {
        SceneManager.LoadScene("GameOverScene"); // ou use o índice ex: LoadScene(1)
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene("SampleScene"); // troque para o nome da sua cena principal
    }
}
