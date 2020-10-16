using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Klasa przechowująca najwyższą osiagniętą wartość punktową w słowniku PlayerPrefs
public class HighScore : MonoBehaviour
{
    public static int score;

    void Awake()
    {
        //odczytanie największej wartości, jeśli istnieje
        if (PlayerPrefs.HasKey("HighScore")) 
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        //przypisanie wartości do pola HighScore
        PlayerPrefs.SetInt("HighScore", score);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>(); //aktualizacja tekstu
        gt.text = "najlepszy wynik: " + score;
        if (PlayerPrefs.GetInt("HighScore") < score) // aktualizacja wartości HighScore
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
