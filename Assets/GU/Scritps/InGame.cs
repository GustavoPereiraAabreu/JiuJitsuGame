using UnityEngine;
using UnityEngine.SceneManagement;

public class ModoPintarLivre : MonoBehaviour
{

    // Função chamada quando o botão é clicado
    public void StartGame()
    {
        // Carrega a cena do jogo (certifique-se de que a cena "Game" está adicionada nas configurações do build)
        SceneManager.LoadScene("Game");
            Time.timeScale = 1f; // Garante que o tempo volte ao normal caso tenha sido pausado 
    }
}
