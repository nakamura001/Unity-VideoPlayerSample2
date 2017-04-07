using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaVal : MonoBehaviour {
	public Text alphaText;

	public void ChangeVal(float val) {
		alphaText.text = val.ToString ("F2");
	}
}
