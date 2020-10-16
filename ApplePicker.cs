using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//skrypt zarządzający grą // odpowiada za liczbę koszyków na ekranie, oraz za generowanie i niszczenie 
//jabłek upuszczonych podczas zniszczenia koszyka
public class ApplePicker : MonoBehaviour
{
    [Header("Definiowanie ręczne w panelu inspektor")]
    public GameObject basketPrefab; //prefabrykant pojedynczego koszyka
    public int numBaskets = 3;
    public float basketBottomY = -10f; //położenie najniższego koszyka
    public float basketSpacingY = 1f; // rozłożenie w przestrzeni Y
    public List<GameObject> basketList;
    public GameObject[] lostApplePrefabs; //tablica prefabrykantów jabłek upuszczanych w funkcji DestroyBasket()

    public static int diffLvl = 1; // aktualny poziom trudności (maks 5)
    // Start is called before the first frame update
    void Start()
    {
        //stworzenie trzech koszyków
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }
    public void DestroyBasket()
    {
        //metoda uruchamiana, gdy zostanie przechwycone zgniłe jabłko, lub gdy nie zostanie przechwycone zdrowe jabłko

        //zniszczenie wszystkich jabłek w scenie
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Jabłko");
        GameObject[] rApps = GameObject.FindGameObjectsWithTag("RotApple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy (tGO);
        }
        foreach(GameObject rGO in rApps)
        {
            Destroy(rGO);
        }
        //usuwanie jednego kosza,
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
        //upuszczenie 5 jabłek z koszyka // nie ma wpływu na punktację (tylko charakter wizualny)
        for (int i=0; i < 5; i++)
        {
            int rand = Random.Range(0, 2);
            GameObject appledropped = Instantiate<GameObject>(lostApplePrefabs[rand]);
            appledropped.transform.position = tBasketGO.transform.position;
            Rigidbody applerigid = appledropped.GetComponent<Rigidbody>();
            // jabłka mogą polecieć w prawo lub w lewo, zawsze delikatnie w górę
            Vector3 vel = new Vector3(Random.Range(-10,10), Random.Range(2, 5), 0);
            applerigid.velocity = vel;

            //zniszczenie jabłek po 2 sekundach (gdy znikną z ekranu)
            Invoke("DestroyDropApples", 2f);
        }
        if (basketList.Count == 0)
            //restart gry, gdy skończyły się koszyki
        {
            SceneManager.LoadScene("PickTheApple");
            diffLvl = 1;
        }
    }
    void DestroyDropApples()
    {
        GameObject[] rApplesArray = GameObject.FindGameObjectsWithTag("DropApple");
        foreach (GameObject app in rApplesArray)
        {
            Destroy(app);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
