using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//skrypt odpowiadający za pojedyncze jabłko, które ulega autozniszczeniu gdy jego pozycja na osi Y spadnie
//poniżej pewnej wartości;
//skrypt nie jest przypisany do jabłek wypadających z koszyka - za ich wygenerowanie oraz zniszczenie 
//odpowiada klasa Basket
public class Jabłko : MonoBehaviour
{
    public static float bottomY = -20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {//niszczenie sie
       if (transform.position.y<bottomY)
        {
            if (this.tag == "Jabłko")
            {
                ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
                apScript.DestroyBasket();
            }
            Destroy(this.gameObject);
        }
    }
}
