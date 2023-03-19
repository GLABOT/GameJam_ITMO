using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{

	public float fadeSpeed = 1.5f;
	private Image _image;
	private bool _needToFadeIn;
	private bool _needToFadeOut;
	private bool _readyToChangeScene = false;

	private void TEST()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{
			LoadScene("SeaBattle");
		}
	}

	void Awake()
	{
		_image = GetComponentInChildren<Image>();
		_image.enabled = true;
		Cursor.visible = false;
	}

	void Update()
	{
		//if (_needToFadeOut) FadeOut();
		//if (_needToFadeIn) FadeIn();
		//TEST();
	}

	void FadeOut()
	{
		_image.color = Color.Lerp(_image.color, Color.clear, fadeSpeed * Time.deltaTime);

		if (_image.color.a <= 0.01f)
		{
			_image.color = Color.clear;
			_image.enabled = false;
			_needToFadeOut = false;
			Cursor.visible = true;
		}
	}

	void FadeIn()
	{
		_image.enabled = true;
		_image.color = Color.Lerp(_image.color, Color.black, fadeSpeed * Time.deltaTime);

		if (_image.color.a >= 0.95f)
		{
			Cursor.visible = false;
			_image.color = Color.black;
			_needToFadeIn = false;
			_readyToChangeScene = true;
		}
	}

	public void LoadScene(string sceneName)
	{
		//_readyToChangeScene = false;

        //_needToFadeIn = true;
		//if (_readyToChangeScene) 
			SceneManager.LoadScene(sceneName);

		//_needToFadeOut = true;
	}
}
