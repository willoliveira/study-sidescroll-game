using UnityEngine;
using System.Collections;

public class ItemConsume : Item {

	//Tipo de consumaçao
	public ConsumeType consumeType;
	//Quantidade que e restaurada
	public int RestoureAmount;
	//Se e auto consumivel
	public bool AutoConsumable;
		
	//
	private Item item;
	private PlayerHealth pHealth;
	

	public void ConsumirItem(GameObject TargetConsume) {
		//Se for item de consumo
		if (consumeType == ConsumeType.HPRestore) {
			//Pega a referencia de PlayerHealth
			pHealth = TargetConsume.GetComponent<PlayerHealth>();
			//Verifica se o life esta cheio
			if (!pHealth.HealthFull()) {
				//Consumir o item
				pHealth.RestoreLife(RestoureAmount);
				//
				Destroy (gameObject);
			}
		}
	}


}
