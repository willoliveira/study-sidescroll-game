using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Inventory : MonoBehaviour {

	private struct ItemStruct {
		private int contVal;
		public int cont {
			get  {
				return contVal;
			}
			set  {
				contVal = value;
			}
		}
		public string name;
		public Item itemInstance;
	};

	//Referencia do UI do inventario
	private Canvas InventoryCanvas;
	//Lista de itens
	private List<ItemStruct> ListItems;
	//Tamanho do slot do inventario
	private int SlotSize = 100;
	//GO publicos
	public GameObject SlotItens;
	public GameObject ContainerItens;
	//Transform
	public Transform itensColetados;

	// Use this for initialization
	void Start () {
		//Deixa invisivel o inventario
		InventoryCanvas = GetComponent<Canvas>();
		InventoryCanvas.enabled = false;
		//
		itensColetados = new GameObject("ItensColetados").transform;
		itensColetados.SetParent(ContainerItens.transform);
		//Inicia a lista
		ListItems = new List<ItemStruct>();
		//Setup Menu
		SetupInventoryItems();
	}

	
	void Update() {
		if (Input.GetKeyDown(KeyCode.I)) {
			openInventory();
		}
	}

	private void SetupInventoryItems() { }

	private void openInventory() {
		//Open
		InventoryCanvas.enabled = !InventoryCanvas.enabled;
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;

		int cont = 0;
		foreach (ItemStruct item in ListItems) {
			Debug.Log (item.name);

			
			GameObject goItem = new GameObject();
			goItem.transform.SetParent(ContainerItens.transform);
			
			goItem = Instantiate(SlotItens, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;

			goItem.transform.SetParent(ContainerItens.transform);
		}
	}


	public void Add(Item item) {
		int indexList;
		ItemStruct iStruct;
		//Procura se ha uma ocorrencia desse item no inventario
		indexList = ListItems.FindIndex(i => i.itemInstance.Name == item.Name);
		//Se o item ja existir
		if (indexList > -1) {
			//Aumenta seu contador
			iStruct = ListItems[indexList];
			iStruct.cont += 1;
			ListItems[indexList] = iStruct;
			//Printa
			Debug.Log (ListItems[indexList].name);
			Debug.Log (ListItems[indexList].cont);
		} else {
			Debug.Log ("Adiciona na lista!");
			//Cria uma struct
			//ItemStruct itemS = new ItemStruct();
			//Item cloneItem;
			//Clona o item
			//cloneItem = Instantiate(item);
			//cloneItem.transform.SetParent(itensColetados);
			//Atribui os elementos
			//itemS.name = item.Name;
			//itemS.cont = 1;
			//itemS.itemInstance = cloneItem;
			//Adiciona na lista
			//ListItems.Add(itemS); //d(item => item.name == "foo").value
		}
		//Debug.Log(findingS.cont);
	}

	public void Remove(Item item, int len = 1) {		
		int indexList;
		ItemStruct iStruct;
		//Procura se ha uma ocorrencia desse item no inventario
		indexList = ListItems.FindIndex(i => i.itemInstance.Name == item.Name);
		//Faz um cache da posiçao da lista
		iStruct = ListItems[indexList];
		//Se remover todos os itens, remove da lista
		if (iStruct.cont == len)
			ListItems.RemoveAt(indexList);
		else {
			//Se for apenas uma parte dos itens, diminui eles
			iStruct.cont -= len;
			ListItems[indexList] = iStruct;
		}
		//Atualiza
		UpdateUI();
	}

	public void UpdateUI() {

	}
}
