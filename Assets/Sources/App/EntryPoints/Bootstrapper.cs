using UnityEngine;

namespace Game.App.EntryPoints
{
    [DefaultExecutionOrder(-1)]
    public class Bootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            if (Application.isEditor)
            {
                if (FindObjectOfType<App>() == null)
                    new AppFactory().Create();
            }
            else
            {
                new AppFactory().Create();
            }
        }
    }
}