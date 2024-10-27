using Godot;
using System;
using System.Text.Unicode;
using System.Timers;

public partial class player : CharacterBody2D
{
	public Bullet bulllet_;
	public Marker marker;
	[Export]
	public WeaponRes weapon;
	[Export]
	public float magazine;
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
		bulllet_=new Bullet();
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
	public void setMagazine(){
		magazine=weapon.magazine;
	}
	public void attackDetect() {
		if(Input.IsActionJustPressed("attack")&&magazinCheck(magazine) is true) {
			PackedScene _bullet=(PackedScene)ResourceLoader.Load("res://Scenes/Bullet.tscn");
			var bullet=_bullet.Instantiate<Bullet>();
			GetParent().AddChild(bullet);
			bullet.GlobalPosition=GlobalPosition;
			bullet.setParameters(weapon.damage,weapon.speed,GetGlobalMousePosition());
			magazine=magazine-1;
		}
		else if(magazinCheck(magazine) is false) 
		{
			GD.Print("d");
			magazineRecharge(weapon.rechargeTime);
		}
	}
	public bool magazinCheck(float magazine) 
	{
		if(magazine<=0) {
			return false;
		}
		else {
			return true;
		}
	}
	public void magazineRecharge(float rechargeTime) {
		Godot.Timer timer =GetNode<Godot.Timer>("RechargeTime");
		timer.WaitTime=rechargeTime;
		GD.Print("t");
		timer.OneShot=true;
	if(Input.IsActionJustPressed("recharge")) {
		timer.Start();
		GD.Print("f");
	}
	}
	public void _on_recharge_time_timeout() {
		magazine=weapon.magazine;
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
		var timer=GetNode<Godot.Timer>("Timer");
		if(Input.IsActionJustPressed("stopTime") && !timerCheck)  
		{
			timerCheck=true;
			timer.Start();
			GetTree().Paused=true;
		}
	}
	public void _on_timer_timeout() {
		var timer=GetNode<Godot.Timer>("Timer");
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
		setMagazine();
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
