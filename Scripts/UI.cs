using Godot;
using System;

public partial class UI : Control
{
	Texture currentTexture;
	public void HpBarChange(float newHP, float maxHP) {
		var bar=GetNode<ProgressBar>("ProgressBar");
		bar.MaxValue=maxHP;
		bar.MinValue=0;
		bar.Value=newHP;

	}
	public void TimeBarChange(float newTime, float maxTime) {
		var bar=GetNode<ProgressBar>("ProgressBar2");
		bar.MaxValue=maxTime;
		bar.MinValue=0;
		bar.Value=newTime;

	}
	public void rechargeBar(float ammo, float magazine) {
		var bar=GetNode<ProgressBar>("RechargeBar");
		bar.ShowPercentage=false;
		bar.Value=ammo;
		bar.MaxValue=magazine;
		bar.MinValue=0;
	}
		public void IconChange() 
	{
		var icon=GetNode<TextureRect>("TextureRect");
	}
	public void SetTexture(NodePath texturePath) {
		currentTexture=GD.Load<Texture>(texturePath);
	}
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		var timer=player.Instance.GetNode<Timer>("Timer");
		HpBarChange(player.Instance.hpPlayer,player.Instance.maxHpPlayer);
		TimeBarChange((float)timer.TimeLeft,(float)timer.WaitTime);
		rechargeBar(player.Instance.magazine, player.Instance.weapon.magazine);
	}
}
