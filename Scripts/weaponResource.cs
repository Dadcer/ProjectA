using Godot;

public partial class WeaponResource: Resource {
    [Export]
   public string name;
   [Export]
   public float damage;
   [Export]
   public float timeLimit;
   [Export]
   public PackedScene scene; 
}