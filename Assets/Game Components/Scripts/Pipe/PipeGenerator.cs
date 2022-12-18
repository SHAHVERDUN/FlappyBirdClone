using UnityEngine;

public class PipeGenerator : GameObjectPool
{
    [SerializeField] private Bird _bird;
    [SerializeField] private GameObject _pipeTemplate;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionByY;
    [SerializeField] private float _minSpawnPositionByY;

    private float _elapsedTime;

    private void OnEnable()
    {
        _bird.Lived += SetClearContainer;
    }

    private void OnDisable()
    {
        _bird.Lived -= SetClearContainer;
    }

    private void Start()
    {
        Initialize(_pipeTemplate);
        _elapsedTime = 0;
    }

    private void Update()
    {
        if (_bird.IsLife == true)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _timeBetweenSpawn)
            {
                DisableObjectBehindScreen();

                if (TryGetObject(out GameObject pipe) == true)
                {
                    _elapsedTime = 0;

                    float spawnPositionByY = Random.Range(_minSpawnPositionByY, _maxSpawnPositionByY);
                    Vector3 spawnPoint = new Vector3(transform.position.x,
                                                        spawnPositionByY, Container.transform.position.z);

                    pipe.transform.position = spawnPoint;
                    pipe.SetActive(true);
                }
            }
        }
    }

    private void SetClearContainer(bool active)
    {
        if (active == true)
        {
            if (Container.childCount > 0)
            {
                for (int i = 0; i < Container.childCount - 1; i++)
                {
                    Container.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }
}