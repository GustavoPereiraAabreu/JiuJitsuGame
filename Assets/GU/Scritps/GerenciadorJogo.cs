using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class GerenciadorJogo : MonoBehaviour
{
    [Header("Configuração Visual")]
    public Renderer faixaRenderer; // Arraste o objeto da faixa 3D aqui
    public TextMeshProUGUI textoDica; // Arraste o texto da dica aqui

    [Header("Telas")]
    public GameObject telaDerrota;
    public GameObject telaVitoria;

    // Classe para organizar os dados de cada faixa
    [System.Serializable]
    public class DadosFaixa
    {
        public string nome;
        public Color cor;
        public string dica;
    }

    public List<DadosFaixa> todasAsFaixas; // Preencha no Inspector do Unity
    private int indiceSorteado;
    private List<int> indicesRestantes = new List<int>();

    void Start()
    {
        ReiniciarJogo();
    }

    public void ReiniciarJogo()
    {
        telaDerrota.SetActive(false);
        telaVitoria.SetActive(false);

        // Resetar a lista de índices para garantir aleatoriedade sem repetir
        indicesRestantes.Clear();
        for (int i = 0; i < todasAsFaixas.Count; i++)
        {
            indicesRestantes.Add(i);
        }

        SortearProximaFase();
    }

    void SortearProximaFase()
    {
        if (indicesRestantes.Count <= 0)
        {
            telaVitoria.SetActive(true);
            return;
        }

        // Sorteia um índice da lista de restantes
        int r = UnityEngine.Random.Range(0, indicesRestantes.Count);
        indiceSorteado = indicesRestantes[r];
        indicesRestantes.RemoveAt(r); // Remove para não repetir a mesma cor

        // Atualiza a UI e reseta a cor da faixa para branco (estado neutro)
        textoDica.text = "Dica: " + todasAsFaixas[indiceSorteado].dica;
        faixaRenderer.material.color = Color.white;
    }

    // Função chamada pelos botões
    public void VerificarResposta(string nomeDoBotao)
    {
        if (nomeDoBotao == todasAsFaixas[indiceSorteado].nome)
        {
            // Se acertou, pinta a faixa com a cor correta e sorteia a próxima após 1 segundo
            faixaRenderer.material.color = todasAsFaixas[indiceSorteado].cor;
            Invoke("SortearProximaFase", 1.2f);
        }
        else
        {
            // Se errou, Game Over
            telaDerrota.SetActive(true);
        }
    }
}
