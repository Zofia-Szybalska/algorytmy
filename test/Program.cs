using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        HashMap<string, int> map1 = new HashMap<string, int>();
        HashMap<int, string> map2 = new HashMap<int, string>();

        int points = 0;
        points += Test(() => map1.HashCode("ABC") == Math.Abs(string.GetHashCode("ABC") % 101) && map2.HashCode(1290) == Math.Abs(1290.GetHashCode() % 101)
            ? 1
            : 0, 1);
        points += Test(() => map1.PutIfAbsent("ABC", 100) && map1.Constains("ABC") && !map1.PutIfAbsent("ABC", 100)
            ? 1
            : 0, 2);
        points += Test(() => map1.Replace("ABC", 200) && map1.Constains("ABC") && map1.Get("ABC") == 200
            ? 1
            : 0, 3);
        points += Test(() =>
        {
            return map1.Remove("ABC") && !map1.Constains("ABC") && map1.Get("ABC") == 0
                ? 1
                : 0;

        }, 4);
        points += Test(() =>
        {
            return !Equals(new Product() { Name = "ABCD", Price = 10.9m, Quantity = 3, Unit = "cm" }, (new Product() { Name = "ABCD", Price = 10.9m, Quantity = 3, Unit = "sztuka" }))
                   && new Product() { Name = "ABCD", Price = 10.9m, Quantity = 3, Unit = "cm" }.GetHashCode() != new Product() { Name = "ABCD", Price = 10.9m, Quantity = 3, Unit = "sztuka" }.GetHashCode()
                   && new Product() { Name = "ABCD", Price = 10.9m, Quantity = 3, Unit = "cm" }.GetHashCode() == new Product() { Name = "ABCD", Price = 10.9m, Quantity = 3, Unit = "cm" }.GetHashCode()
                   && Equals(new Product() { Name = "ABCD", Price = 10.9m, Quantity = 3, Unit = "cm" }, (new Product() { Name = "ABCD", Price = 10.9m, Quantity = 3, Unit = "cm" }))
                ? 1
                : 0;

        }, 5);
        Console.WriteLine($"Suma punktów: {points}");
    }

    public static int Test(Func<int> testedCode, int task)
    {
        try
        {
            int points = testedCode.Invoke();
            Console.WriteLine($"Ćwiczenie {task}: {points}");
            return points;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ćwiczenie {task}: 0");
            return 0;
        }
    }
}

public record Pair<K, V>
{
    public K Key { get; set; }
    public V Value { get; set; }
}

public class HashMap<Key, Value> : IEnumerable<Pair<Key, Value>>
{

    private static readonly int Capacity = 101;
    private ISet<Key> _keys = new HashSet<Key>();

    private List<Pair<Key, Value>>[] _values = new List<Pair<Key, Value>>[Capacity];
    //Ćwiczenie 1
    //zaimplementuj metodę, która oblicza skrót na podstawie klucza key i "dopasowuje" go do zakresu
    //od 0 do Capacity
    internal int HashCode(Key key)
    {
        return Math.Abs(key.GetHashCode() % Capacity);
    }
    //Ćwiczenie 2
    //zaimplementuj metodę, która dodaje do słownika wartość value o kluczu key
    //1. sprawdź, czy taki klucz znajduje się już w zbiorze _key, i jeśli jest to zakończ metodę zwracając false
    //2. oblicz skrót na podstawie klucza metodą HashCode
    //3. za pomocą obliczonego skrótu zaadresuj komórkę w tablicy _values, aby dostać się do listy
    //4. dodaj do listy obiekt Pair, z _value i  _key (jeśli istnieje już lista, a jeśli nie to należy ją najpierw utworzyć)
    //5. dodaj do zbioru _key klucz key
    //6. zwróć true
    public bool PutIfAbsent(Key key, Value value)
    {
        if (Constains(key))
        { return false; }
        int i = HashCode(key);
        if (_values[i] == null)
        {
            _values[i] = new List<Pair<Key, Value>>();
        }
        _values[i].Add(new Pair<Key, Value> { Key = key, Value = value });
        _keys.Add(key);
        return true;
    }
    //Ćwiczenie 3
    //Zaimplementuj metodę, która zmienia istniejącą wartość o kluczu key
    //Jeśli w strukturze nie ma takiej wartości to zwróć false
    //Jeśli w strukturze jest wpis o kluczu key to wykonaj zamianę i zwróć true
    public bool Replace(Key key, Value value)
    {
        if (!Constains(key))
        {
            return false;
        }
        int i = HashCode(key);
        foreach (var item in _values[i])
        {
            if (item.Key.Equals(key))
            {
                item.Value = value;
                return true;
            }
        }
        return false;
    }

    //Ćwiczenie 4
    //Zaimplementuje metodę, która usuwa wartość pod kluczem
    //1. sprawdź czy istnieje taki klucz w _keys
    //2. jeśli brak takiego klucza to zwróć false
    //3. jeśli jest to oblicz skrót i odwołaj się do odpowiedniej komórki _value
    //4. przeszukaj listę znajdującą się zaadresowanej komórce, jeśli znalazłeś parę z kluczem to:
    //      a. usuń z listy parę
    //      b. usuń klucz z _keys
    //      c. zwróć true 
    //5. jeśli nie ma takiej pary to zwróć false
    public bool Remove(Key key)
    {
        if (!Constains(key))
        {
            return false;
        }
        int i = HashCode(key);
        foreach (var item in _values[i])
        {
            if (item.Key.Equals(key))
            {
                _values[i].Remove(item);
                _keys.Remove(key);
                return true;
            }
        }
        return false;
    }

    public bool Constains(Key key)
    {
        return _keys.Contains(key);
    }

    public Value? Get(Key key)
    {
        if (_keys.Contains(key))
        {
            return _values[HashCode(key)].Find(item => object.Equals(key, item.Key))!.Value;
        };
        return default;
    }

    public IEnumerator<Pair<Key, Value>> GetEnumerator()
    {
        foreach (var list in _values)
        {
            foreach (var item in list)
            {
                yield return item;
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

//Ćwiczenie 5
//Nadpisz metodę GetHahsCode i Equals w klasie Product
//w obu metodach uwzględnij wszystkie pola klasy
//wykorzystaj dostęne w C# metody, które wyznaczają HashCode, nie twórz własnych implementacji skrótów!!!
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Unit { get; set; }

    protected bool Equals(Product other)
    {
        return Name == other.Name && Price == other.Price && Quantity == other.Quantity && Unit == other.Unit;
    }
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Product)obj);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Price, Quantity, Unit);
    }
}


