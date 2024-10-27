using Godot;
using System;

public partial class Item : Node2D
{
	[Export]
	public InventoryItem item;
	public void playerEnteredSignal(Node2D body) 
	{
		
		if(body is player pl) {
			pl.inventoryAdd(item);
			
		}
	}
}


