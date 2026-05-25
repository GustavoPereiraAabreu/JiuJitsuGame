using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Função chamada quando o botão é clicado
    public void ResetGame()
    {
        // Carrega a cena do jogo (certifique-se de que a cena "Game" está adicionada nas configurações do build)
        SceneManager.LoadScene("Game");
    }
}
