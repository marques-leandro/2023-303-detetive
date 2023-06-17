using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeLevelDoJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private TMP_Dropdown filtros;
    [SerializeField] private Toggle legenda;


    public void Jogar(){
        SceneManager.LoadScene(nomeLevelDoJogo); 
    }

    public void AbrirOpcoes(){
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes(){
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    /*public void SairDoJogo(){
        Debug.Log("Sair do jogo");
        Application.Quit();
    }*/

    public void SairDoJogo(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void guardaFiltro(){
        ComponentStorage.filtro=filtros.options[filtros.value].text;
        Debug.Log(ComponentStorage.filtro);
    }

    public void guardaLegenda(){
        ComponentStorage.legendas=legenda.isOn;
    }

}
