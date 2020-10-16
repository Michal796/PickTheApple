# PickTheApple
Optymalny stosunek wymiarów ekranu dla gry PickTheApple wynosi 16:9.

Założenia gry:
Celem gry jest zebranie jak największej liczby jabłek czerwonych oraz zielonych, upuszczanych przez drzewo. 
Drzewo upuszcza jabłka zielone, czerwone oraz zgniłe (kolor ciemnobrunatny). Nie złapanie jabłka czerwonego/zielonego, lub złapanie jabłka zgniłego spowoduje usunięcie jednego z trzech koszy. Gra skończy się w momencie zniszczenia ostatniego kosza. Przechwycenie jabłka czerwonego lub zielonego skutkuje dodaniem 1000 punktów do licznika. Najwyższa wartość zdobytych punktów w rundzie jest zapisywana, i wyświetla się po ponownym uruchomieniu gry.

Sterowanie: sterowanie odbywa się wyłącznie przy pomocy myszki. Aby poruszać koszem należy poruszać myszką.

Skrypty:
- ApplePicker - klasa zarządzająca grą. Odpowiada za kontrolowanie liczby koszyków wyświetlanych na ekranie, oraz jabłka generowane podczas niszczenia jednego z koszyków.
- Basket - klasa odpowiada za sterowanie koszami oraz zliczanie punktów. Zapisuje najwyższą wartość punktową
w statycznym polu klasy HighScore.
- HighScore - odczytuje oraz zapisuje najwyższą wartość punktową, osiągniętą w pojedynczej rundzie. Wykorzystuje słownik zmiennych PlayerPrefs.
- Jabłko - dołączany do jabłek, odpowiada za ich samozniszczenie przy spadku wartości położenia na osi Y poniżej zadanej wartości.
- Jabłoń - skyryp odpowiedzialny za poruszanie się drzewa oraz upuszczanie jabłek.
