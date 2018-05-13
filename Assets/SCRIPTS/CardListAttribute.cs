using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardListAttribute : MonoBehaviour 
{
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
}

// public struct CardList{
// 	public GameObject[] cards;
// 	public int[] cantidades;
// 	private List<int> baraja;

// 	public void Shuffle(){
// 		baraja.Clear();
// 		for(int i = 0; i<cantidades.Length; i++){
// 			for (int e = 0; e<cantidades[i]; e++){
// 				baraja.Add(i);
// 			}
// 		}
// 	}

// 	public GameObject GetCard(){
// 		int rand = Random.Range(0,baraja.Count);
// 		baraja.RemoveAt(rand);
// 		return cards[rand];
// 	}
// }