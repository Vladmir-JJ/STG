using UnityEngine.SceneManagement;
namespace JJ.STG.Main
{
    public static class SceneLoader
    {
        public static void LoadScene(int sceneId)
        {
            SceneManager.LoadScene(sceneId);            
        }
    }
}

