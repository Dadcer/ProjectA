using Godot;
using System;

public partial class InventoryUI : Control
{
	public void _on_exit_button_pressed() {
		QueueFree();
	}
}
