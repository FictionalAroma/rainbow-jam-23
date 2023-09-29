using CommonComponents.Interfaces;
using Management;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class PauseMenu : MonoBehaviour
    {
        private static PauseMenu _instance = null;
        [SerializeField] private GameObject pauseScreen;

        private bool isPaused;
        private GameState _cachedState;

        public static PauseMenu Instance => _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

        }

        void Start()
        {
            _instance = this;
            pauseScreen.SetActive(false);
        }

        public void OpenPauseMenu()
        {
            _cachedState = GameStateManager.Instance.CurrentState;

            GameStateManager.Instance.SetState(GameState.Paused);
            isPaused = true;
            pauseScreen.SetActive(true);

        }
        public void Resume()
        {
            GameStateManager.Instance.SetState(_cachedState);
            isPaused = false;
            pauseScreen.SetActive(false);


        }

        public void OnEnable()
        {
        }

        public void OnDisable()
        {
        }

        public void QuitApplication()
        {
            Application.Quit();
            Debug.Log("Escaping");
        }
        public void LoadMenu()
        {
            SceneManager.LoadScene("MainMenu");
            Resume();
        }


        //this is for other scripts potentially
        //i know theres probably loads of safer and simplers ways to do this but ehhhh
        public void TogglePause()
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                OpenPauseMenu();
            }
        }



    }

