using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JsonRecieverMyAttempt
{
    public Pokemon[] myPokemon;
}

[System.Serializable]
public class Pokemon
{
    public int id;
    public string num;
    public string name;
    public string img;
    public string[] type;
    public string height;
    public string weight;
    public string candy;
    public int candy_count;
    public string egg;
    public float spawn_chance;
    public int avg_spawns;
    public string spawn_time;
    public float[] multipliers;
    public string[] weaknesses;
}

/*
 * Pokemon": [{
    "id": 1,
    "num": "001",
    "name": "Bulbasaur",
    "img": "http://www.serebii.net/pokemongo/pokemon/001.png",
    "type": [
      "Grass",
      "Poison"
    ],
    "height": "0.71 m",
    "weight": "6.9 kg",
    "candy": "Bulbasaur Candy",
    "candy_count": 25,
    "egg": "2 km",
    "spawn_chance": 0.69,
    "avg_spawns": 69,
    "spawn_time": "20:00",
    "multipliers": [1.58],
    "weaknesses": [
      "Fire",
      "Ice",
      "Flying",
      "Psychic"*/
