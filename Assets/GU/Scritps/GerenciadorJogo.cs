using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GerenciadorJogo : MonoBehaviour
{
    [Header("Configuração Visual")]
    [SerializeField] public SpriteRenderer faixaVisual; // O objeto da faixa no centro da tela
    [SerializeField] public Text textoDica;             // Um componente de texto para as dicas

    [Header("Telas de Status")]
    [SerializeField] private GameObject telaVitoria;
    [SerializeField] private GameObject telaDerrota;

    // Lista da ordem correta dos nomes dos botões (conforme sua imagem)
    private string[] ordemInfantil = {
        "Faixa Branca", "Faixa Cinza Com Branco", "Faixa Cinza", "Faixa Cinza Com Preto",
        "Faixa Amarela Com Branco", "Faixa Amarela", "Faixa Amarela Com Preto",
        "Faixa Laranja Com Branco", "Faixa Laranja", "Faixa Laranja Com Preto",
        "Faixa Verde Com Branco", "Faixa Verde", "Faixa Verde Com Preto"
    };

    // Dicas correspondentes a cada faixa
    private string[] dicas = {
        "Dica: É a cor da paz e de quem está começando hoje!",
        "Dica: Mistura de branco com a cor das nuvens de chuva!",
        "Dica: A cor do elefante, sem nenhuma outra mistura.",
        "Dica: A cor cinza, mas agora chegando perto da faixa amarela!",
        "Dica: A cor do sol misturada com a cor do começo!",
        "Dica: A cor do sol brilhante!",
        "Dica: O sol está ficando forte, quase laranja!",
        "Dica: Cor de laranja misturada com o branco!",
        "Dica: A cor da fruta laranja!",
        "Dica: Laranja forte, quase chegando na cor da floresta!",
        "Dica: A cor das árvores misturada com branco!",
        "Dica: A cor das matas e das folhas!",
        "Dica: O nível máximo das crianças! Verde escuro!"
    };

    private int nivelAtual = 0;

    void Start()
    {
        telaVitoria.SetActive(false);
        telaDerrota.SetActive(false);
        AtualizarDica();
    }

    // Chame esta função nos seus botões do Unity passando o nome da cor
    public void SelecionarFaixa(string nomeBotao)
    {
        if (nomeBotao == ordemInfantil[nivelAtual])
        {
            Acertou();
        }
        else
        {
            Errado();
        }
    }

    void Acertou()
    {
        // Aqui você pode mudar a cor da faixa visual se desejar
        // faixaVisual.color = corDoBotao; 

        nivelAtual++;

        if (nivelAtual >= ordemInfantil.Length)
        {
            telaVitoria.SetActive(true);
        }
        else
        {
            AtualizarDica();
        }
    }

    void Errado()
    {
        telaDerrota.SetActive(true);
    }

    void AtualizarDica()
    {
        textoDica.text = dicas[nivelAtual];
    }

    public void ReiniciarJogo()
    {
        nivelAtual = 0;
        telaVitoria.SetActive(false);
        telaDerrota.SetActive(false);
        AtualizarDica();
    }
}
