using System.Collections.Generic;
using System.Threading;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private float gravity;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private TMP_Text scoreText;
    private int score;

    public float timer;
    private List<GameObject> appleList = new List<GameObject>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: 0";
        timer = 0f;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2f)
        {
            //Se ha completado el timer
            //Reset
            timer = 0f;
            //Creamos una manzana
            GameObject newApple = Instantiate(applePrefab);
            //Manzana en parte superior
            newApple.transform.position = new Vector3(Random.Range(-3.5f, 3.5f), 5.5f);
            //Añadimos manzana en nueva lista
            appleList.Add(newApple);
        }
        //Mover todas las manzanas
        foreach (GameObject apple in appleList)
        {
            apple.transform.position += Vector3.down * gravity * Time.deltaTime;
        }
        List<GameObject> appleListToRemove = new List<GameObject>();
        foreach (GameObject apple in appleList)
        {
            float distance = Vector3.Distance(apple.transform.position, playerTransform.transform.position);
            if (distance < 0.5f)
            {
                Debug.Log("Colisiono con una manzana");
                score++;
                scoreText.text = "Score: " + score.ToString();
                Debug.Log("Score: " + score);
                appleListToRemove.Add(apple);
            }
        }
        foreach (GameObject apple in appleListToRemove)
        {
            appleList.Remove(apple);
            Destroy(apple);
        }

        appleListToRemove.Clear();
    }
}
//Hay que cambiar información