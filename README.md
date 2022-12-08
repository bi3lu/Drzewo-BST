# Drzewo-BST
Program jest implementacją struktury danych jaką jest drzewo BST (Binary Search Tree).
Możemy wykonywać na nim proste operacje takie jak wstawianie nowych elementów, usuwanie ich itp.

-metoda Insert odpowiedzialna jest za wstawienie w odpowiednim miejscu drzewa liczby całkowitej podanej przez użytkownika

-metoda DeleteLeaf wywołuje metodę Delete przekazując jej odpowiedni parametr int, wykonując przy tym operację usunięcia danej wartości i jeśli trzeba "przesunięcia poszczególnych liści drzewa"

-metoda InOrder wypisuje w oknie konsoli wartości całkowite drzewa w kolejności rosnącej

-metoda Member sprawdza czy dana wartość zawiera się w drzewie, jeżeli tak zwraca referencję do danej wartości (obiektu)

-metoda Min zwraca referencje do wartości (obiektu) posiadającego najmniejszy klucz

-metoda Max robi to samo co Min tylko dla warości maksymalnej

-metoda Successor zwraca referencje do wartości (obiektu), która jest bezpośrednim następcą podanej wartości zawierającej się w drzewie

klasa Leaf:
-Left jest to lewy syn danego liścia
-Right jest to prawy syn danego liścia
-Key jest to wartość całkowita danego liścia

program nie posiada obsługi wyjątków
