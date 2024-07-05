using Godot;
using System;

public partial class InventoryItem : Resource
{
 [Export]
 public string type;
 [Export]
 public string name;
 [Export]
 public Texture2D texture;

}
