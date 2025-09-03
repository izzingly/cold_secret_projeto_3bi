using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;

    [SerializeField] private GameObject PainelTutorial;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }
    
    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void AbrirTutorial()
    {
        painelMenuInicial.SetActive(false);
        PainelTutorial.SetActive(true);
    }

    public void FecharTutorial()
    {
        PainelTutorial.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

}
