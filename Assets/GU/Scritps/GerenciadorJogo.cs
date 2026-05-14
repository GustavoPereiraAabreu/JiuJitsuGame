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
    [Header("Configuração dos Modelos")]
    public Transform pontoDeSpawn; // Arraste o objeto "Faixa" da hierarquia aqui para pegar a posição
    public GameObject[] prefabsFaixas; // Arraste seus prefabs aqui na ordem (Branca, Cinza/Branca, etc.)

    private GameObject faixaAtual;

    [Header("Interface")]
    public TextMeshProUGUI textoDica; // Arraste o seu "Dica Text (TMP)" aqui
    public GameObject telaVitoria;
    public GameObject telaDerrota;

    private int indexFase = 0;

    // Dicas para as crianças
    private string[] dicas = {
        "A cor do iniciante! (Branca)",
        "Cor de nuvem com branco! (Cinza/Branca)",
        "Cor de elefante! (Cinza)",
        "Cinza com pontinha preta!",
        "Cor do sol com branco! (Amarela/Branca)"
        // Continue a lista até a verde...
    };

    void Start()
    {
        telaVitoria.SetActive(false);
        telaDerrota.SetActive(false);
        ProximaFase();
    }

    // ESSA FUNÇÃO VOCÊ VAI COLOCAR NOS BOTÕES
    public void TentarGraduar(int botaoID)
    {
        // Se o número do botão for igual ao index da fase atual, ele acertou
        if (botaoID == indexFase)
        {
            indexFase++;
            if (indexFase >= prefabsFaixas.Length)
            {
                telaVitoria.SetActive(true);
            }
            else
            {
                ProximaFase();
            }
        }
        else
        {
            telaDerrota.SetActive(true);
        }
    }

    void ProximaFase()
    {
        // Apaga a faixa anterior
        if (faixaAtual != null) Destroy(faixaAtual);

        // Cria a nova faixa na posição certinha do seu cenário
        faixaAtual = Instantiate(prefabsFaixas[indexFase], pontoDeSpawn.position, pontoDeSpawn.rotation);

        // Ajusta a escala (vi no seu print que a escala é grande: 52, 32, 32)
        faixaAtual.transform.localScale = pontoDeSpawn.localScale;

        // Atualiza a dica
        textoDica.text = dicas[indexFase];
    }

    public void Restart()
    {
        indexFase = 0;
        telaDerrota.SetActive(false);
        telaVitoria.SetActive(false);
        ProximaFase();
    }
}