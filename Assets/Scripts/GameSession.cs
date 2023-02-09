using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 2f)] [SerializeField] float gameSpeed;
    [SerializeField] int PointsPerBlockDestroyed, currentScore = 0;
    [SerializeField] TextMeshProUGUI points;
    [SerializeField] bool isAutoPlayEnable;

    // Start is called before the first frame update
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount > 1)
        {
           gameObject.SetActive(false);
           Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        points.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void updatePoint()
    {
        currentScore += PointsPerBlockDestroyed;
        points.text = currentScore.ToString();
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    public bool isAutoPlayEnabled()
    {
        return isAutoPlayEnable;
    }
}
