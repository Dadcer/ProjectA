using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Dynamic;
using Godot;
using Godot.Collections;
public partial class Inventory : Resource
{
	public InventoryItem item; // зачем это?
	public List<InventoryItem> itemsList = new List<InventoryItem>();

	// событие которое сообщает что содержимое инвентаря изменено
	public event Action OnInventoryChanged;

	public void inventoryAddItem(InventoryItem item) {
		itemsList.Add(item);
		GD.Print(itemsList[0].name);

		// сообщаем что содержимое инвентаря изменено
		OnInventoryChanged?.Invoke();
	}
	
}

	 

