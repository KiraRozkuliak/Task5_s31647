using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

// Unity Script 10 references
public class PlayerSave : MonoBehaviour
{
    // przykładowe dane do zapisania
    public int health = 100;
    public int coins = 0;

    // Unity Message 10 references
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    // 0 reference
    public void Save()
    {
    SaveData data = new SaveData(); // Tworzenie obiektu do zapisu danych
    data.health = health; // Zapisuje zdrowie
    data.coins = coins; // Zapisuje liczbę monet
    data.position = new float[3] // Zapisuje pozycję gracza
    {
        transform.position.x,
        transform.position.y,
        transform.position.z
    };
    // Zapisuje dane za pomocą SaveSystem
    SaveSystem.Save(data);
    Debug.Log("Game Saved");
    }

    public void Load()
    {
        // Wczytuje dane za pomocą SaveSystem
        SaveData data = SaveSystem.Load();
        // Jeśli nie ma danych, wyświetla ostrzeżenie i zwraca nic
        if (data == null)
        {
            Debug.LogWarning("No save data found");
            return;
        }
        health = data.health; // Wczytuje zdrowie
        coins = data.coins; // Wczytuje liczbę monet
                            // Wczytuje pozycję gracza
        transform.position = new Vector3(
            data.position[0],
            data.position[1],
            data.position[2]
        );
        Debug.Log("Game Loaded");
    }

}