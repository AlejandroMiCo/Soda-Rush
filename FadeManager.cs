using Godot;
using System.Threading.Tasks;

public partial class FadeManager : Node
{
	private AnimationPlayer _anim;
	private ColorRect _fade;

	public override void _Ready()
	{
		_fade = GetNode<ColorRect>("/root/World/FadeCanvas/FadeRect");
		_anim = _fade.GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public async Task FadeToBlack()
	{
		_anim.Play("fade_in");
		await ToSignal(_anim, "animation_finished");
	}

	public async Task FadeFromBlack()
	{
		_anim.Play("fade_out");
		await ToSignal(_anim, "animation_finished");
	}
}
