using UnityEngine;

public class PintarFaixaDesign : MonoBehaviour
{
    [Header("Configuração da Faixa")]
    public Renderer faixaRenderer;

    [Header("Referência do Seletor")]
    public FlexibleColorPicker seletorDeCor;

    public void PintarFaixaComCorDoSeletor()
    {
        if (faixaRenderer != null && seletorDeCor != null)
        {
            faixaRenderer.material.color = seletorDeCor.color;
            Debug.Log("Faixa pintada com a cor do seu design!");
        }
    }
}