using UnityEngine;
using UnityEngine.SceneManagement;

public class PintarLivrementeTrocar : MonoBehaviour
{
    public void StartNewMode()
    {
        // Carrega a cena do jogo (certifique-se de que a cena "Game" está adicionada nas configurações do build)
        SceneManager.LoadScene("GamePintarLivre");
        Time.timeScale = 1f; // Garante que o tempo volte ao normal caso tenha sido pausado
    }

}
