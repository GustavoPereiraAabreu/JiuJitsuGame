using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [Header("Painéis de Interface")]
    [SerializeField] private GameObject _canvas; // O painel principal com os botões
    [SerializeField] private GameObject PanelGraduacao; // O painel que explica os controles

    // Chame esta função no botão "Buttons and Tutorial"
    public void OpenTutorial()
    {
        if (_canvas != null && PanelGraduacao != null)
        {
            _canvas.SetActive(false); // Esconde o menu
            PanelGraduacao.SetActive(true);  // Mostra o tutorial
        }
    }

    // Chame esta função no botão de "Voltar" dentro do tutorial
    public void CloseTutorial()
    {
        if (_canvas != null && PanelGraduacao != null)
        {
            PanelGraduacao.SetActive(false); // Esconde o tutorial
            _canvas.SetActive(true);  // Volta para o menu
        }
    }
}