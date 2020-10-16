using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Klasa Basket odpowiada za sterowanie koszykiem, oraz aktualną punktację; zapisuje również najwyższą wartość
// punktową w polu score klasy HighScore
public class Basket : MonoBehaviour
{
    public Text scoreGT; //punkty

    public static int[] pointsForLvl; // progi punktowe do kolejnych poziomów
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
        pointsForLvl = new int[4] { 10000, 20000, 40000, 100000};
    }
    // Update is called once per frame
    void Update()
    {
        //sterowanie koszykiem odbywa się przy pomocy myszy
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;//-10*(-1)=10
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);//z=-10+10=0
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter (Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        int score = int.Parse(scoreGT.text); //pobranie aktualnej liczby punktów
        Text nextLVL = GameObject.Find("Level").GetComponent<Text>(); //Text odpowiadający za linijkę
        //informującą o aktualnym oraz następnym poziomie
        switch (collidedWith.tag)
        {
            case "Jabłko":
                Destroy(collidedWith);
                score += 1000;
                scoreGT.text = score.ToString();
                if (score > HighScore.score)
                {
                    HighScore.score = score;
                }
                foreach (int i in pointsForLvl) //zwiększenie poziomu trudności, gdy punkty osiągną próg
                {
                    if (score == i)
                    {
                        ApplePicker.diffLvl += 1;
                    }
                }
                if (ApplePicker.diffLvl < 5) // tekst dla poziomów 1-4
                {
                    nextLVL.text = "poziom: " + ApplePicker.diffLvl + "; następny: " + pointsForLvl[ApplePicker.diffLvl - 1];
                }
                else if (ApplePicker.diffLvl >= 5) //tekst dla poziomu 5
                {
                    nextLVL.text = "poziom " + ApplePicker.diffLvl;
                }
                break;
            case "RotApple": //zniszczenie koszyka
                ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
                apScript.DestroyBasket();
                break;
        }   
    }
}
