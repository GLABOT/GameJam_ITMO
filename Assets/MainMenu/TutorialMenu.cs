
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _images;
    [SerializeField] private int _currentImageIndex = 0;

    private void Start()
    {
        ShowImage();
    }

    private void ShowImage()
    {
        for (int i = 0; i < _images.Length; i++)
        {
            if (i != _currentImageIndex)
            {
                _images[i].SetActive(false);
            }
            else
            {
                _images[i].SetActive(true);
            }
        }
    }

    public void ToNextSlide()
    {
        if (_currentImageIndex == _images.Length-1) return;

        _currentImageIndex++;
        ShowImage();
    }

    public void ToPreviousSlide() 
    {
        if (_currentImageIndex == 0) return;

        _currentImageIndex--;
        ShowImage();
    }
    
    public void ExitTutorialMenu()
    {
        gameObject.SetActive(false);
    }
}
