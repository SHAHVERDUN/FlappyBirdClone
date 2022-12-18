using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [SerializeField] protected Transform Container;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private Camera _mainCamera;

    private List<GameObject> _pool;

    protected void Initialize(GameObject prefab)
    {
        _pool = new List<GameObject>(_poolCapacity);

        for (int i = 0; i < _poolCapacity; i++)
        {
            GameObject spawned = Instantiate(prefab, Container);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject gameObject)
    {
        gameObject = _pool.FirstOrDefault(predicate => predicate.activeSelf == false);

        return gameObject != null;
    }

    protected void DisableObjectBehindScreen()
    {
        Vector2 disablePoint = _mainCamera.ViewportToWorldPoint(Vector2.zero);

        foreach (GameObject gameObject in _pool)
        {
            if (gameObject.activeSelf == true && gameObject.transform.position.x < disablePoint.x)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ResetPool()
    {
        foreach (GameObject gameObject in _pool)
        {
            gameObject.SetActive(false);
        }
    }
}