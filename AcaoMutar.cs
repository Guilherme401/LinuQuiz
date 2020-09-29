using UnityEngine;
using System.Collections;

public class AcaoMutar : MonoBehaviour {

	private bool isMuted;
	void Start () {
		isMuted = PlayerPrefs.GetInt ("MUTED") == 1;
		AudioListener.pause = isMuted;
	}
	
	public void MutePressed(){

		isMuted = !isMuted;
		AudioListener.pause = isMuted;
		PlayerPrefs.SetInt ("MUTED", isMuted ? 1 : 0);
	}

}
