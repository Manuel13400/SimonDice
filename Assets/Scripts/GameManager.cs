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

    public GameObject textCanvas;
    public TextMeshProUGUI TextoResultados;
    public TextMeshProUGUI TextoPulsado;
    public TextMeshProUGUI texto_extra_1;
    public TextMeshProUGUI texto_extra_2;
    public TextMeshProUGUI texto_extra_3;

    int azul_mem = 0, rojo_mem = 0, amarillo_mem = 0, verde_mem = 0;

    bool ocupado = false;

    public void Start()
    {
        buttonList = GameObject.FindGameObjectsWithTag("Button");

        textCanvas = GameObject.Find("Resultados");
        TextoResultados = textCanvas.GetComponent<TextMeshProUGUI>();

        textCanvas = GameObject.Find("Pulsado");
        TextoPulsado = textCanvas.GetComponent<TextMeshProUGUI>();

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
            verde_mem++;
            if (ocupado) { StopCoroutine("mostrarUltimoPulsado"); }
            StartCoroutine("mostrarUltimoPulsado");
        }
        else { avisoVeinte(); }
    }
    public void botonRojo()
    {
        if(contadorBotonesPulsados < 20) {
            //Debug.Log("Botón rojo pulsado");
            arrayBotonesPulsados[contadorBotonesPulsados] = "ROJO";
            contadorBotonesPulsados++;
            rojo_mem++;
            if (ocupado) { StopCoroutine("mostrarUltimoPulsado"); }
            StartCoroutine("mostrarUltimoPulsado");
        }
        else { avisoVeinte(); }

    }
    public void botonAmarillo()
    {
        if (contadorBotonesPulsados < 20) {
            //Debug.Log("Botón amarillo pulsado");
            arrayBotonesPulsados[contadorBotonesPulsados] = "AMARILLO";
            contadorBotonesPulsados++;
            amarillo_mem++;
            if (ocupado) { StopCoroutine("mostrarUltimoPulsado"); }
            StartCoroutine("mostrarUltimoPulsado");
        }
        else { avisoVeinte(); }
    }
    public void botonAzul()
    {
        if (contadorBotonesPulsados < 20) {
            //Debug.Log("Botón azul pulsado");
            arrayBotonesPulsados[contadorBotonesPulsados] = "AZUL";
            contadorBotonesPulsados++;
            azul_mem++;
            if (ocupado) { StopCoroutine("mostrarUltimoPulsado"); }
            StartCoroutine("mostrarUltimoPulsado");
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

    // MOSTRAR COLORES PULSADOS (DESACTIVA LOS BOTONES TEMPORALMENTE PARA EVITAR ERRORES DE FUNCIONAMIENTO)
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
        azul_mem = 0; rojo_mem = 0; amarillo_mem = 0; verde_mem = 0;
        TextoPulsado.text = "";

    }

    // MOSTRAR ULTIMO PULSADO
    private IEnumerator mostrarUltimoPulsado()
    {
        Debug.Log("empezado");
        TextoPulsado.text = arrayBotonesPulsados[contadorBotonesPulsados - 1].ToString();
        ocupado = true;
        yield return new WaitForSeconds(3f);
        Debug.Log("terminado");
        TextoPulsado.text = "";
        texto_extra_1.text = "";
        texto_extra_2.text = "";
        texto_extra_3.text = "";
        ocupado = false;
    }

    // MOSTRAR PRIMERO DE LA LISTA
    public void botonPrimero()
    {
        if (arrayBotonesPulsados[0] != null)
        {
            texto_extra_1.text = arrayBotonesPulsados[0].ToString();
        }
    }

    // MOSTRAR ULTIMO DE LA LISTA
    public void botonUltimo()
    {
        if (contadorBotonesPulsados != 0)
        {
            texto_extra_2.text = arrayBotonesPulsados[contadorBotonesPulsados - 1].ToString();
        }
    }

    // MOSTRAR PULSACIONES DE CADA COLOR (RECORRIENDO ARRAY)
    public void botonContadorUno()
    {
        int azul = 0, rojo = 0, amarillo = 0, verde = 0;
        for (int i = 0; i < contadorBotonesPulsados; i++)
        {
            switch (arrayBotonesPulsados[i]) 
            {
                case "VERDE":
                    verde++;
                    break;
                case "ROJO":
                    rojo++;
                    break;
                case "AMARILLO":
                    amarillo++;
                    break;
                case "AZUL":
                    azul++;
                    break;
            }
        }

        texto_extra_3.text =    "Verde: " + verde +
                                "\nRojo: " + rojo +
                                "\nAmarillo: " + amarillo+
                                "\nAzul: " + azul;
    }

    // MOSTRAR PULSACIONES DE CADA COLOR (ALMACENANDO COLORES)
    // Esta solucion me parece mas eficiente, ya que no necesita tener que recorrer toda la lista, simplemente buscar los parametros guardados
    public void botonContadorDos()
    {
        texto_extra_3.text =    "Verde: " + verde_mem + 
                                "\nRojo: " + rojo_mem +
                                "\nAmarillo: " + amarillo_mem +
                                "\nAzul: " + azul_mem;
    }

    // Respecto a la manera para hacer estas cuentas escalables, se me ocurre usar un diccionario, que guarde el nombre del color con un string y
    // la cuenta de veces pulsadas en un int y cada vez que se pulse un boton la cuenta aumente
}
