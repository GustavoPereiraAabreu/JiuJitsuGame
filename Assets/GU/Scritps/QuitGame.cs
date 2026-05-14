using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    // Função chamada quando o botão é clicado
    public void QuitTheGame()
    {
        // Carrega a cena do jogo (certifique-se de que a cena "Game" está adicionada nas configurações do build)
        SceneManager.LoadScene("Menu");
    }
}


