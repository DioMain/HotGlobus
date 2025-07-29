using HotGlobus.Core.DI;
using HotGlobus.Core.Kernel;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HotGlobus.Core
{
    public class GameManager : HotGlobusBehaviour, IKernel
    {
        public static GameManager Instance;

        public const string LocalTag = "SceneController";

        public bool GlobalIsReady { get; private set; }

        public DependencyInjectionKernel DependencyInjection { get; private set; }

        [SerializeField]
        private GlobalManagerCore global;
        [SerializeField]
        private LocalManagerCore local;

        private Coroutine delayedLocalInitializeCoroutine = null;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                DontDestroyOnLoad(gameObject);

                SceneManager.activeSceneChanged += OnSceneChanged;

                Initialize();
            }
            else
                Destroy(gameObject);
        }

        private void Initialize()
        {
            DependencyInjection = new DependencyInjectionKernel();

            GlobalIsReady = false;

            global.Initialize();

            GlobalIsReady = true;
        }

        private void OnSceneChanged(Scene old, Scene scene)
        {
            if (!scene.isLoaded)
                return;

            if (delayedLocalInitializeCoroutine != null)
                StopCoroutine(delayedLocalInitializeCoroutine);

            delayedLocalInitializeCoroutine = StartCoroutine(DelayedLocalInitialize());
        }

        private IEnumerator DelayedLocalInitialize()
        {
            yield return new WaitWhile(() => !GlobalIsReady);

            local = GameObject.FindWithTag(LocalTag).GetComponent<LocalManagerCore>();

            local.Initialize();
        }
    }
}
