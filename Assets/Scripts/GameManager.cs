using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    string[] arrayBotonesPulsados = new string[20];
    int contadorBotonesPulsados = 0;
    string lista;

    GameObject[] buttonList;

    GameObject buttonToHide;

    public GameObject textCanvas;
    public TextMeshProUGUI TextoResultados;
    public TextMeshProUGUI texto_extra_1;
    public TextMeshProUGUI texto_extra_2;
    public TextMeshProUGUI texto_extra_3;

    public void Start()
    {
        buttonList = GameObject.FindGameObjectsWithTag("Button");

        textCanvas = GameObject.Find("Resultados");
        TextoResultados = textCanvas.GetComponent<TextMeshProUGUI>();

        textCanvas = GameObject.Find("texto_extra_1");
        texto_extra_1 = textCanvas.GetComponent<TextMeshProUGUI>();

        textCanvas = GameObject.Find("texto_extra_2");
        texto_extra_2 = textCanvas.GetComponent<TextMeshProUGUI>();

        textCanvas = GameObject.Find("texto_extra_3");
        texto_extra_3 = textCanvas.GetComponent<TextMeshProUGUI>();
    }

    // BOTONES DE COLORES
    public void botonVerde()
    {
        if (contadorBotonesPulsados < 20) {
            //Debug.Log("Botón verde pulsado");
            arrayBotonesPulsados[contadorBotonesPulsados] = "VERDE";
            contadorBotonesPulsados++;
            StartCoroutine(mostrarUltimoPulsado());
        }
        else { avisoVeinte(); }
    }
    public void botonRojo()
    {
        if(contadorBotonesPulsados < 20) {
            //Debug.Log("Botón rojo pulsado");
            arrayBotonesPulsados[contadorBotonesPulsados] = "ROJO";
            contadorBotonesPulsados++;
            StartCoroutine(mostrarUltimoPulsado());
        }
        else { avisoVeinte(); }

    }
    public void botonAmarillo()
    {
        if (contadorBotonesPulsados < 20) {
            //Debug.Log("Botón amarillo pulsado");
            arrayBotonesPulsados[contadorBotonesPulsados] = "AMARILLO";
            contadorBotonesPulsados++;
            StartCoroutine(mostrarUltimoPulsado());
        }
        else { avisoVeinte(); }
    }
    public void botonAzul()
    {
        if (contadorBotonesPulsados < 20) {
            //Debug.Log("Botón azul pulsado");
            arrayBotonesPulsados[contadorBotonesPulsados] = "AZUL";
            contadorBotonesPulsados++;
            StartCoroutine(mostrarUltimoPulsado());

        }
        else { avisoVeinte(); }
    }

    // AVISO AL SUPERAR VEINTE
    void avisoVeinte()
    {
        //Debug.Log("Se ha alcanzado el numero maximo de pulsaciones, por favor, pulsa terminar.");
        TextoResultados.text = "Se ha alcanzado el numero maximo de pulsaciones, por favor, pulsa terminar.";
    }

    // BOTON FIN
    public void botonTerminarPartida()
    {
        StartCoroutine(showColors());
        for (int i = 0; i < contadorBotonesPulsados; i++)
        {
            if (i == contadorBotonesPulsados - 1) { lista += arrayBotonesPulsados[i].ToString(); }
            else { lista += arrayBotonesPulsados[i].ToString() + ", "; }
        }
        Debug.Log(lista);
    }

    // MOSTRAR COLORES PULSADOS
    private IEnumerator showColors()
    {
        hideButtons();
        for (int i = 0; i < contadorBotonesPulsados; i++)
        {
            TextoResultados.text = arrayBotonesPulsados[i].ToString();
            yield return new WaitForSeconds(0.5f);
        }
        showButtons();
        restart();
    }

    // DESACTIVAR/REACTIVAR BOTONES 
    void hideButtons() { foreach (GameObject button in buttonList) { button.GetComponent<Button>().interactable = false; } }
    void showButtons() { foreach (GameObject button in buttonList) { button.GetComponent<Button>().interactable = true; } }

    // REINICIAR ARRAY, CONTADOR Y TEXTO
    void restart()
    {
        Array.Clear(arrayBotonesPulsados, 0, arrayBotonesPulsados.Length);
        contadorBotonesPulsados = 0;
        arrayBotonesPulsados = new string[20];
        lista = "";
    }

    private IEnumerator mostrarUltimoPulsado()
    {
        texto_extra_1.text = arrayBotonesPulsados[contadorBotonesPulsados - 1].ToString();

        

        yield return new WaitForSeconds(3f);

        texto_extra_1.text = "";
    }

    public void botonPrimero()
    {
        //Debug.Log(arrayBotonesPulsados[0]);

    }

    public void botonUltimo()
    {
        //Debug.Log(arrayBotonesPulsados[contadorBotonesPulsados - 1]);
    }
}
