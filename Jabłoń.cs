using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ta klasa odpowiada za poruszanie się drzewa, oraz generowanie jabłek
public class Jabłoń : MonoBehaviour
{
    [Header("Definiowanie ręczne w panelu Inspector")]
    // Start is called before the first frame update
    public GameObject[] applePrefabs; // prefabrykanty upuszczanego jabłka

    public float[] appleTreeSpeeds;//szybkość jabłka w zalezności od poziomu trudności
    public float[] secondsBetweenDrop;//określa częstotliwość upuszczania jabłek w zależności od poziomu
    public float leftAndRightEdge = 10f; // maksymalne wychylenie drzewa na osi Y
    public float chanceToChangeDirection; //szansa na losową zmianę kierunku

    void Start()
    {
        appleTreeSpeeds = new float[5] { 7.5f, 10f, 17.5f, 22.5f, 30f };
        secondsBetweenDrop = new float[5] {1f, 0.9f, 0.75f, 0.6f, 0.5f};
        Invoke("DropApple", 2f);
    }
    void DropApple()
    {
        int rand = Random.Range(0, 10);
        GameObject apple = Instantiate<GameObject>(applePrefabs[rand]);//funkcja tworzy jedno jabłko losowego 
        //koloru
        apple.transform.position = transform.position;     
        Invoke("DropApple", secondsBetweenDrop[ApplePicker.diffLvl -1]);

    }
    // Update is called once per frame
    void Update()
    {
        //ruch w każdej klatce
        Vector3 pos = transform.position;
        pos.x += appleTreeSpeeds[ApplePicker.diffLvl - 1] * Time.deltaTime;
        transform.position = pos;
        //zmiana kierunku gdy drzewo osiągnie graniczną wartość wychylenia na osi Y
        if(pos.x < -leftAndRightEdge)
        {
            appleTreeSpeeds[ApplePicker.diffLvl -1] = Mathf.Abs(appleTreeSpeeds[ApplePicker.diffLvl - 1]);
        }
        else if (pos.x>leftAndRightEdge)
        {
            appleTreeSpeeds[ApplePicker.diffLvl - 1] = -Mathf.Abs(appleTreeSpeeds[ApplePicker.diffLvl - 1]);
        }

    }
    //losowa zmiana kierunku // wykorzystano funkcję FixedUpdate() aby szanse na zmianę kierunku 
    //były zawsze takie same, niezależnie od liczby klatek obrazu na sekundę
    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirection)
        {
            appleTreeSpeeds[ApplePicker.diffLvl - 1] *= -1;
        }
    }
}
