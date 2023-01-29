using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bullettMaxLife = 1f;

    private void OnEnable()
    {
        Invoke("Hide", bullettMaxLife);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}
