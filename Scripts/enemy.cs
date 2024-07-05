using Godot;
using System;

public partial class enemy : CharacterBody2D
{
	public bool IsBattleStart=false;
	public bool enemyStep=false;
	public float maxHP=5;
	[Export]
	public float hp=5;
	[Export]
	public float enemySpeed=5;
	public int actionPointsEnemy=50;
	Vector2 velocity=new Vector2();
	Vector2 force=new Vector2();
	public void hpCheckEnemy() {
		if(hp<=0) {
			QueueFree();
		}
	}
	public void takeDamage(float damage) {
		hp-=damage;
		HpBarChange(hp);
		hpCheckEnemy();
	}
	public void _on_area_2d_body_entered(Node2D body) {
		if(body is player pl) {
			pl.hpPlayer--;
		}
	}
	public void GetPLayerPosition() {
		Vector2 direction=player.Instance.GlobalPosition-Position;
		direction=direction.Normalized();
		velocity=direction*enemySpeed;
		velocity+=force;
		actionPointsEnemy=actionPointsEnemy-5;
		var collision = MoveAndCollide(velocity);
		if(collision!=null){
			var col = collision.GetCollider();
			if(col is enemy en){
				en.force += velocity / 10.0f;
			}
		}
	}
	public void Knockback(Vector2 direction, float factor) 
	{
		force += direction * factor;
	}
	public void updateForce(double delta) {
		force = force.Lerp(Vector2.Zero, (float)delta);
	
	}
	public void BattleStopTime() {
		if(IsBattleStart==true) {
		enemySpeed=0;
		}
	}
	public void HpBarChange(float newHP) {
		var bar=GetNode<ProgressBar>("ProgressBar");
		bar.MaxValue=maxHP;
		bar.MinValue=0;
		bar.Value=newHP;
	}
		public override void _Ready()
	{
		
	}

	public override void _Process(double delta)
	{
		hpCheckEnemy();
		GetPLayerPosition();
		updateForce(delta);
		HpBarChange(hp);
		BattleStopTime();
	}

	public void onBodyCollide(Node2D body){

	}
}
