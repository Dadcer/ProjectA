using Godot;
using System;

public partial class InventoryItem : Resource
{
 [Export]
 public string name;
 [Export]
 public float damage;
 [Export]
 public float speed;
 [Export]
 public Texture2D texture;
}
