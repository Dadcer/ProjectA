using Godot;
using System;
using System.Text.Unicode;

public partial class player : CharacterBody2D
{
	public Marker marker;
	[Export]
	public WeaponRes weapon;
	[Export]
	public Inventory inventory;
	public static player Instance;
	public enemy enemy;
	public Vector2 _target;
	public Vector2 targetPosition;
	[Export]
	NodePath handPath;
	Node2D hand;
	Node2D startBattle;
	[Export]
	public int maxHpPlayer=10;
	[Export]
	public int hpPlayer=10;
	public float speedPlayer=200;
	public int actionPointsPlayer=10;
	public bool timerCheck=false;
	public float damage=1;
	
	public  player() {
		inventory=new Inventory();
		marker=new Marker();
	}
	public void hpCheckPLayer() {
		if(hpPlayer<=0) {
			QueueFree();
		}
	}
	public void SetPayerRotation() {
		
	}
	public void moveDetect() 
	{
		_target=Input.GetVector("left", "right", "up", "down");
		Velocity=_target*speedPlayer;
		MoveAndSlide();
	}
	public void attackDetect() {
		if(Input.IsActionJustPressed("mouseClickLeft") ) {
			PackedScene bullet=(PackedScene)ResourceLoader.Load("res://Scenes/Bullet.tscn");
			Node bullet1=bullet.Instantiate();
			AddChild(bullet1);
			bullet1.setParameters(weapon.damage, weapon.speed);
		}
	}
	public void inventoryOpenCheck() {
		
		if(Input.IsActionJustPressed("openInventory")) 
		{
			// TODO: убрать создание инвентаря, чтобы он был создан на сцене
			PackedScene inventory = (PackedScene)ResourceLoader.Load("res://Scenes/InventoryUI.tscn");
			Node subInventoryInstance=inventory.Instantiate();
			AddChild(subInventoryInstance);
		}
	}
	public void inventoryAdd(InventoryItem item) 
	{
		inventory.inventoryAddItem(item);
	}
	public void GetPlayerStopTime() {
		var timer=GetNode<Timer>("Timer");
		if(Input.IsActionJustPressed("stopTime") && !timerCheck)  
		{
			timerCheck=true;
			timer.Start();
			GetTree().Paused=true;
		}
	}
	public void _on_timer_timeout() {
		var timer=GetNode<Timer>("Timer");
		timerCheck=false;
		timer.Stop();
		GetTree().Paused = false;
	}
	public void _on_enemy_check_area_body_entered(Node2D body )
	{
		if(body is enemy en) {
			enemy=en;

		}
	}
	public override void _Ready()
	{
		
		hand = GetNode<Node2D>(handPath);
		Instance=this;
		startBattle=GetNode<Node2D>("BattleControl");
		
	}
	public override void _Process(double delta)
	{
		attackDetect();
		SetPayerRotation();
		GetPlayerStopTime();
		moveDetect();
		hpCheckPLayer();
		inventoryOpenCheck();
	}
}
