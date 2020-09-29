﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class temaJogo : MonoBehaviour {

	public Button       btnVoltar;
	public Text         txtNomeTema;

	public GameObject   infoTema;
	public Text         txtInfoTema;
	public GameObject   estrela1;
	public GameObject   estrela2;
	public GameObject   estrela3;

	public string[]     nomeTema;

	private int         idTema;

	// Use this for initialization
	void Start () {
		idTema = 0;
		txtNomeTema.text = nomeTema [idTema];
		txtInfoTema.text = "Voçê acertou x de x questões!";
		infoTema.SetActive (false);
		estrela1.SetActive (false);
		estrela2.SetActive (false);
		estrela3.SetActive (false);
		btnVoltar.interactable = false;
	}
	
	public void selecioneTema(int i)
	{
		idTema = i;
		PlayerPrefs.SetInt("idTema", idTema); 
		txtNomeTema.text = nomeTema[i];

		int notaFinal = PlayerPrefs.GetInt("notaFinal"+idTema.ToString()); 
		int acertos = PlayerPrefs.GetInt("acertos"+idTema.ToString()); 

		estrela1.SetActive (false);
		estrela2.SetActive (false);
		estrela3.SetActive (false);

		if (notaFinal == 10) 
		{
			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (true); 
		}
		else if(notaFinal >= 7)
		{
			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (false); 
		}   
		else if(notaFinal >= 5)
		{
			estrela1.SetActive (true);
			estrela2.SetActive (false);
			estrela3.SetActive (false); 
		}
		



		if (i == 1){
		txtInfoTema.text = "Você acertou "+acertos.ToString()+" de "+"10"+" questões!";
		}
		else if(i == 2){
		txtInfoTema.text = "Você acertou "+acertos.ToString()+" de "+"15"+" questões!";
		}
		else if(i == 3){
		txtInfoTema.text = "Você acertou "+acertos.ToString()+" de "+"20"+" questões!";
		}
		else { txtInfoTema.text = "Você acertou "+acertos.ToString()+" de "+"10"+" questões!"; }

		infoTema.SetActive (true);
		btnVoltar.interactable = true;
	}

	public void jogar() 
	{
		Application.LoadLevel("T"+idTema.ToString());
	}


}