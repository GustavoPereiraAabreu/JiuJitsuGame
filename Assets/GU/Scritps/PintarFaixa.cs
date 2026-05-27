using UnityEngine;

public class PintarFaixa : MonoBehaviour
{
    // Arraste o seu objeto FlexibleColorPicker para cá no Inspector
    public FlexibleColorPicker seletor;
    // Arraste o seu objeto Faixa para cá no Inspector
    public Renderer faixaRenderer;

    void Update()
    {
        // Se clicar com o mouse na tela
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Atira o raio. Se colidir com a faixa (ela precisa de um Mesh Collider!)
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == faixaRenderer.gameObject && seletor != null)
                {
                    // Pinta usando a propriedade ".color" do script que você enviou
                    faixaRenderer.material.color = seletor.color;
                }
            }
        }
    }
}