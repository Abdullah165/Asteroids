using UnityEngine.SceneManagement;
using UnityEngine;

public class RePlay : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
