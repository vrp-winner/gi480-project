using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName; // ชื่อ Scene ที่จะโหลด

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}