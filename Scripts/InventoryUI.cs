using Godot;
using System;

public partial class InventoryUI : Control
{
	[Export]
	public Godot.Collections.Array<TextureButton> weaponCells = new Godot.Collections.Array<TextureButton>();
	[Export]
	public Godot.Collections.Array<TextureButton> armorCells = new Godot.Collections.Array<TextureButton>();
	[Export]
	public Godot.Collections.Array<TextureButton> itemCells = new Godot.Collections.Array<TextureButton>();

    public override void _Ready()
    {
        base._Ready();
		player.Instance.inventory.OnInventoryChanged += RenderContent;
    }
    public override void _ExitTree()
    {
        player.Instance.inventory.OnInventoryChanged -= RenderContent;
    }

    public void RenderContent(){
		var inventory = player.Instance.inventory;
		for (int i=0; i<inventory.itemsList.Count; i++){
			var item = inventory.itemsList[i];
			if(i<itemCells.Count){
				var cell = itemCells[i];
				cell.TextureNormal = item.texture;
			}
		}
	}

    public void _on_exit_button_pressed() {
		this.Visible=false;
	}
}
