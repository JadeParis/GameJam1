
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{

    [Header("Menu Objects")]
    [SerializeField] private GameObject _mainMenuCanvas;
    //[SerializeField] private GameObject _settingsMenuCanvas;
  
    [SerializeField] private GameObject _gamePadCanvas;
    [SerializeField] private GameObject _keyboardCanvas;


    [Header("Player Scripts to deactivate on Pause")]

    //[SerializeField] private CharacterController _player;


    [Header("First Selected Options")]
    [SerializeField] private GameObject _mainMenuFirst;
  

    [SerializeField] private GameObject _gamePadMenuFirst;
    [SerializeField] private GameObject _keyboardMenuFirst;
    [SerializeField] private GameObject _creditsMenuFirst;
    

    private bool isPaused;


  

    
    private void Start()
    {
        _mainMenuCanvas.SetActive(false);
        //_settingsMenuCanvas.SetActive(false);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
            {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }

        
    }


    public void Pause()
    {
        Debug.LogWarning("Paused");

        isPaused = true;

        Time.timeScale = 0f;


        

        Cursor.lockState = CursorLockMode.Confined;

        OpenMainMenu();

      //  _player.TurnOffMovement();
    }

    public void Unpause()
    {

        Debug.LogWarning("unPaused");
        isPaused = false;

       

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        CloseAllMenus();

        //_player.Enabled();


    }

   // private void OpenSettingsMenuHandle()
   // {
      //  _settingsMenuCanvas.SetActive(true);
      //  _mainMenuCanvas.SetActive(false);

        //EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);
    //}

    //Canvas Activations / Deactivations
    private void OpenMainMenu()
    {
       
        _mainMenuCanvas.SetActive(true);
        //_settingsMenuCanvas.SetActive(false);
        //_creidtsCanvas.SetActive(false);
        _gamePadCanvas.SetActive(false);
        _keyboardCanvas.SetActive(false);
        

        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }


    private void CloseAllMenus()
    {
        _mainMenuCanvas.SetActive(false);
       // _settingsMenuCanvas.SetActive(false);
        //_creidtsCanvas.SetActive(false);
        _gamePadCanvas.SetActive(false);
        _keyboardCanvas.SetActive(false);
       


        EventSystem.current.SetSelectedGameObject(null);
    }


   // public void OnSettingsPress()
   // {
       // OpenSettingsMenuHandle();
   // }


    public void OnResumePressed()
    {
        Unpause();
    }

   // public void OnCreditsPress()
    //{
    //    OpenCreditsMenuHandle();
//
//
//}
    private IEnumerator coroutine;

   

    public void OnStartScreen()
    {
        SceneManager.LoadScene(0);
    }

  
    public void OnKeyboardPress()
    {
        OpenKeyboardHandle();
    }
    public void OnCreditsPress()
    {
        OpenCreditsHandle();
    }

    private void OpenKeyboardHandle()
    {
        //_settingsMenuCanvas.SetActive(false);
        _mainMenuCanvas.SetActive(false);
       // _creidtsCanvas.SetActive(false);
        _gamePadCanvas.SetActive(false);
        _keyboardCanvas.SetActive(true);


        EventSystem.current.SetSelectedGameObject(_keyboardMenuFirst);
    }

    private void OpenCreditsHandle()
    {
        //_settingsMenuCanvas.SetActive(false);
        _mainMenuCanvas.SetActive(false);
        // _creidtsCanvas.SetActive(false);
        _gamePadCanvas.SetActive(true);
        _keyboardCanvas.SetActive(false);


        EventSystem.current.SetSelectedGameObject(_creditsMenuFirst);
    }

    //////BackButton//////////////////

    public void OnSettingsBackPressed()
    {
        OpenMainMenu();

    }



}

