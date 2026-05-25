using UnityEngine;

public class ModoLivre : MonoBehaviour
{
    [Header("Cor Selecionada Atualmente")]
    private Color corEscolhida = Color.white; // Começa com branco por padrão

    void Update()
    {
        // Detecta o clique do mouse (ou toque na tela do celular)
        if (Input.GetMouseButtonDown(0))
        {
            ColorirElemento3D();
        }
    }

    // 1. FUNÇÃO PARA OS BOTÕES DA PALETA DE CORES
    // Coloque essa função nos botões coloridos da direita passando o código Hex (ex: #FF0000)
    public void SelecionarCorDaPaleta(string codigoHex)
    {
        Color novaCor;
        if (ColorUtility.TryParseHtmlString(codigoHex, out novaCor))
        {
            corEscolhida = novaCor;
            Debug.Log("Cor selecionada na paleta: " + codigoHex);
        }
    }

    // 2. LOGICA DE PINTAR CLICANDO DIRETAMENTE NO OBJETO
    void ColorirElemento3D()
    {
        // Transforma a posição do clique do mouse em um raio 3D a partir da câmera
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Se o raio atingir qualquer objeto 3D que tenha um Collider
        if (Physics.Raycast(raio, out hit))
        {
            // Pega o componente Renderer do objeto clicado
            Renderer rendererObjeto = hit.collider.GetComponent<Renderer>();

            if (rendererObjeto != null)
            {
                // Pinta o material do objeto que o jogador acabou de clicar!
                rendererObjeto.material.color = corEscolhida;
                Debug.Log("Pintou o objeto: " + hit.collider.name);
            }
        }
    }
}