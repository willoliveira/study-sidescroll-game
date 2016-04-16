using UnityEngine;
using System.Collections;

/*Enums*/
//Raidade do item
public enum Rarity { 
	Common, Uncommon, Rare, Legendary
};

//Tipo de item
public enum ItemType { 
	ConsumeType, EquipType
};
//Tipo de consumaçao
public enum ConsumeType { 
	HPRestore, MPRestore, IncreasedStrength, IncreasedDefense,
	RayForce, FireForce
};
//Tipo de equipe
public enum EquipType { 
	Armor, Weapon, Acessories
};
	public enum ArmorType {
		Body, Leg, Arm, Glove, Helmet
	}
	public enum WeaponType {
		ShortDistance,  LongDistance
	}
		public enum WeaponShortDistanceType {
			Sword,  Axe, Dagger
		}
		public enum WeaponLongDistanceType {
			Gun,  Shotgun, Bow
		}
	public enum Acessories {
		Ring, Necklace
	}


public abstract class Item : MonoBehaviour {
	//Nome
	public string Name;
	//Descriçao
	public string Description;
	//Raidade do item
	public Rarity rarity;
	//Preço do item
	public int Price;
	//Peso
	public int Weight;
	//Level requerido
	public int LevelRequired;	
	//tipo do item
	public ItemType itemType;
}
