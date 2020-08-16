using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputFieldController : MonoBehaviour
{
	public InputField inputNameField;
	public Text text;

	void Start()
	{
		inputNameField = inputNameField.GetComponent<InputField>();
		text = text.GetComponent<Text>();
	}

	public void InputText()
	{
		text.text = inputNameField.text;
	}
}
