using Godot;
using System.Threading.Tasks;

public partial class FadeManager : Node
{
	private AnimationPlayer animacion;
	private ColorRect fade;

	public async Task FadeToBlack()
	{
		fade = GetNode<ColorRect>("/root/World/FadeCanvas/FadeRect");
		animacion = fade.GetNode<AnimationPlayer>("AnimationPlayer");
		animacion.Play("fade_in");
		await ToSignal(animacion, "animation_finished");
	}

	public async Task FadeFromBlack()
	{
		fade = GetNode<ColorRect>("/root/World/FadeCanvas/FadeRect");
		animacion = fade.GetNode<AnimationPlayer>("AnimationPlayer");
		animacion.Play("fade_out");
		await ToSignal(animacion, "animation_finished");
	}
}
