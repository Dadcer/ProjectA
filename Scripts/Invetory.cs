using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Dynamic;
using Godot;
using Godot.Collections;
public partial class Inventory : Resource
{
	public InventoryItem item;
	List<InventoryItem> inventoryList=new List<InventoryItem>();
	public void inventoryAddItem(InventoryItem item) {
		inventoryList.Add(item);
		GD.Print(inventoryList[0].name);
	}
	
}

	 

