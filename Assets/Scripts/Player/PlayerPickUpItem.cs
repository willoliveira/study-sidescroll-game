using UnityEngine;
using System.Collections;

public class PlayerPickUpItem : MonoBehaviour {

	private GameObject collObject;
	private ItemConsume itemCache = null;
	private Inventory inventoryInstance;

	// Use this for initialization
	void Start () {
		inventoryInstance = GameObject.Find("Inventory").GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		//Testa se posso pegar o item quando estou em colisao
		if (itemCache && Input.GetButtonDown("Action")) {
			//Add
			inventoryInstance.Add(itemCache);
			//Destroi o item
			//Destroy(itemCache.gameObject);
			Destroy(itemCache.gameObject);
			//Debug.Log ("Action Item");
		}
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="coll">Coll.</param>
	void OnTriggerEnter2D(Collider2D coll) {
		ItemConsume item;
		//Debug.Log ("entrou" + coll.gameObject.tag);
		//todo: Ativar o UI mostrando qual botao apertar
		//Verifica se e um item a colisao
		if (coll.gameObject.tag == "Item") {
			//Pega o script do item
			item = coll.gameObject.GetComponent<ItemConsume>();


			//Se for consumivel
			if (item.itemType == ItemType.ConsumeType) {
				//Se for auto consumivel
				if (item.AutoConsumable) {
					//Consumir
					item.ConsumirItem(gameObject);
					//Quebra a funcao
					return;
				} else {
					//Adiciona no cache
					itemCache = item;
					//Debug.Log ("item nao auto-consumivel");
				}
			}
			//Adiciona no cache
			itemCache = item;
		}
	}

	//void OnTriggerStay2D(Collider2D coll) {
	//	//Testa se posso pegar o item quando estou em colisao
	//	if (item && Input.GetButtonDown("Action")) {
	//		Debug.Log ("Action Item");
	//	}
	//}

	void OnTriggerExit2D(Collider2D coll) {
		//Se saiu da colisao com o item, seta null nele
		itemCache = null;
		//todo: Desativar o UI mostrando qual botao apertar
		//Debug.Log ("Saiu" + coll.gameObject.tag);
	}
}
