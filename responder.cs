using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class responder : MonoBehaviour {

	private int idTema;
	
	public Text  pergunta;
	public Text  respostaA;
	public Text  respostaB;
	public Text  respostaC;
	public Text  respostaD;
	public Text  respostaE;
	public Text  InfoRespostas;

	public string[] perguntas;          // armazena todas as perguntas 
	public string[] alternativaA;       // armazena todas as alternativas A
	public string[] alternativaB;       // armazena todas as alternativas B
	public string[] alternativaC;       // armazena todas as alternativas C
	public string[] alternativaD;       // armazena todas as alternativas D
	public string[] alternativaE;       // armazena todas as alternativas E
	public string[] corretas;           // armazena as alternativas corretas 

	private int idPergunta;

	public float acertos;
	public float questoes;
	public float media;
	private int  notaFinal;

	// Use this for initialization
	void Start () {
		idTema = PlayerPrefs.GetInt("idTema"); 
		idPergunta = 0;
		questoes = perguntas.Length;

		pergunta.text = perguntas[idPergunta];
		respostaA.text = alternativaA[idPergunta];
		respostaB.text = alternativaB[idPergunta];
		respostaC.text = alternativaC[idPergunta];
		respostaD.text = alternativaD[idPergunta];
		respostaE.text = alternativaE[idPergunta];

		InfoRespostas.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString () + " perguntas.";

	}
	
	public void resposta(string alternativa)
	{
        if (alternativa == "A") 
		{
			if(alternativaA[idPergunta] == corretas[idPergunta])
			{
				acertos += 1;
			}
		} 
		else if (alternativa == "B") 
		{
			if(alternativaB[idPergunta] == corretas[idPergunta])
			{
				acertos += 1;
			}
		} 
		else if (alternativa == "C") 
		{
			if(alternativaC[idPergunta] == corretas[idPergunta])
			{
				acertos += 1;
			}
		} 
		else if (alternativa == "D") 
		{
			if(alternativaD[idPergunta] == corretas[idPergunta])
			{
				acertos += 1;
			}
		} 
		else if (alternativa == "E") 
		{
			if(alternativaE[idPergunta] == corretas[idPergunta])
			{
				acertos += 1;
			}
		}

		proximaPergunta();

	}

	void proximaPergunta()
	{
		idPergunta += 1;

		if (idPergunta <= (questoes - 1)) 
		{
	        pergunta.text = perguntas [idPergunta];
			respostaA.text = alternativaA [idPergunta];
			respostaB.text = alternativaB [idPergunta];
			respostaC.text = alternativaC [idPergunta];
			respostaD.text = alternativaD [idPergunta];
			respostaE.text = alternativaE [idPergunta];
		
			InfoRespostas.text = "Respondendo " + (idPergunta + 1).ToString () + " de " + questoes.ToString () + " perguntas.";
		} 
		else 
		{

			// o que fazer se terminar as perguntas
			media = 10 * (acertos / questoes);      // calcula a media com base no percentual de acerto
			notaFinal = Mathf.RoundToInt(media);    // arrendonda a nota para o proximo inteiro, segundo a regra da matematica. 

			if(notaFinal > PlayerPrefs.GetInt("notaFinal"+idTema.ToString()))
			{
				PlayerPrefs.SetInt("notaFinal"+idTema.ToString(), notaFinal);
				PlayerPrefs.SetInt("acertos"+idTema.ToString(), (int) acertos);
			}

			PlayerPrefs.SetInt("notaFinalTemp"+idTema.ToString(), notaFinal);
			PlayerPrefs.SetInt("acertosTemp"+idTema.ToString(), (int) acertos);
			PlayerPrefs.SetFloat("questoesTemp"+idTema.ToString(), (float)questoes);

			Application.LoadLevel("notaFinal");  


		}

	}






}
