using UnityEngine;
using System.Collections;

public class comandosBasicos : MonoBehaviour {

	public void carregandoCena(string nomeCena)
	{
		Application.LoadLevel (nomeCena);
	}

	public void resetarPontuacoes()
	{
		PlayerPrefs.DeleteAll(); 
	}


}
