using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scr_Menu : MonoBehaviour {


    CanvasGroup fadeGroup;
    float fadeSpeed = 0.3f;

    public RectTransform menuContainer;
    public Transform levelPanel;

    [SerializeField] string gameplayScene;

    private Vector3 desiredMenuPosition;
    
    // Use this for initialization
	void Start () {

        fadeGroup = FindObjectOfType<CanvasGroup>();

        fadeGroup.alpha = 1;

        InitLevel();

	}
	
	// Update is called once per frame
	void Update () {

        fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeSpeed;

        menuContainer.anchoredPosition3D = Vector3.Lerp(menuContainer.anchoredPosition3D, desiredMenuPosition, 0.1f);
	}

    private void InitLevel()
    {
        if (levelPanel == null)
            Debug.Log("pene");

        int i = 0;
        foreach (Transform t in levelPanel)
        {
            int currentIndex = i;

            Button b = t.GetComponent<Button>();
           // b.onclik
        }

        
    }

    private void NavigateTo(int menuIndex)
    {
        switch (menuIndex)
        {
            default:
            case 0:
                desiredMenuPosition = Vector3.zero;
                    break;
            case 1:
                desiredMenuPosition = Vector3.right * 1920;
                break;

            case 2:
                desiredMenuPosition = Vector3.left * 1920;
                break;
        }


    }

    public void OnPlayClick(string name)
    {

        SceneManager.LoadScene(name);

    }

    public void OnCreditsClick()
    {
        NavigateTo(2);

    }

    public void OnExitClick()
    {


    }

    public void onBackClick()
    {

        NavigateTo(0);

    }

    //public void OnShopClick()
    //{


    //}


    private void OnLelveSelect(int currentIndex)
    {

        Debug.Log("Level : " + currentIndex);

    }


}
