using UnityEngine;

public class ModoLivre : MonoBehaviour
{
    [Header("Referências dos Modelos 3D")]
    [SerializeField] private Renderer kimonoRenderer; // Arraste o MeshRenderer do Kimono aqui
    [SerializeField] private Renderer faixaRenderer;  // Arraste o MeshRenderer da Faixa aqui

    // Enumerador para sabermos o que a criança selecionou para pintar
    private enum AlvoPintura { Kimono, Faixa }
    private AlvoPintura alvoAtual = AlvoPintura.Faixa; // Começa na faixa por padrão

    [Header("Painéis de UI (Opcional)")]
    public GameObject painelModoLivreUI; // O painel que segura os botões deste modo

    // 1. FUNÇÕES PARA OS BOTÕES DE SELEÇÃO (O que pintar?)
    public void EscolherKimono()
    {
        alvoAtual = AlvoPintura.Kimono;
        Debug.Log("Alvo alterado: Agora pintando o Kimono!");
    }

    public void EscolherFaixa()
    {
        alvoAtual = AlvoPintura.Faixa;
        Debug.Log("Alvo alterado: Agora pintando a Faixa!");
    }

    // 2. FUNÇÃO PARA OS BOTÕES DE CORES
    // Você vai passar a cor usando o formato Hexadecimal (ex: #FF0000) pelo próprio botão
    public void AplicarCor(string codigoHex)
    {
        Color corResultante;

        // Converte o texto Hexadecimal em uma cor real do Unity
        if (ColorUtility.TryParseHtmlString(codigoHex, out corResultante))
        {
            if (alvoAtual == AlvoPintura.Kimono && kimonoRenderer != null)
            {
                kimonoRenderer.material.color = corResultante;
            }
            else if (alvoAtual == AlvoPintura.Faixa && faixaRenderer != null)
            {
                faixaRenderer.material.color = corResultante;
            }
        }
        else
        {
            Debug.LogError("Código Hexadecimal inválido enviado pelo botão: " + codigoHex);
        }
    }
}