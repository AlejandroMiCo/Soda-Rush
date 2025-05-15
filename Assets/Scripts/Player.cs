using Godot;
using System;

public partial class Player : CharacterBody2D
{

	[Export] public float speed = 200f;
	private Vector2 velocity;
	private AnimationNodeStateMachinePlayback stm;
	[Export] public AnimationTree aTree;
	[Export] public Sprite2D sprite;
	[Export] public float jumpForce = 50f;

	private float SPEED = 200f;
	private bool canFloat = true;
	private bool isFloating = false;
	private bool lookingRight = false;

	private bool isFloatingJumpUnlock = false;

  	private Vector2 savedPosition;
	private bool savedDoubleJumpUnlock;

	// Se ejecuta cuando el nodo se carga en la escena
	public override void _Ready()
	{
		base._Ready();
		stm = (AnimationNodeStateMachinePlayback)aTree.Get("parameters/playback");
	}

	public override void _PhysicsProcess(double delta)
	{

		base._PhysicsProcess(delta);
		speed = SPEED;

		//Obtiene el nombre de los controles de godot
		Vector2 direccion = new Vector2(Input.GetActionStrength("right") - Input.GetActionStrength("left"), 0);
		bool onFloor = IsOnFloor();



		if (Input.IsActionJustPressed("attack"))
		{
			stm.Travel("Attack");
			return;
		}

		if (onFloor && Input.IsActionJustPressed("jump"))
		{
			velocity.Y = -jumpForce * 8F;
			stm.Travel("jump");
		}

		if (!onFloor)
		{

			if (Input.IsActionPressed("jump") && !isFloating && velocity.Y > 0)
			{
				isFloating = true;
			}

			if (Input.IsActionJustReleased("jump"))
			{
				isFloating = false;
			}

			if (isFloating && isFloatingJumpUnlock)
			{
				velocity.Y -= 2f;
				speed = SPEED / 3;
			}
			else
			{
				velocity.Y += GetGravity().Y * (float)delta;
			}

			if (stm.GetCurrentNode() != "attack")
			{
				stm.Travel("jump");
			}
		}

		velocity.X = direccion.X * speed;
		Velocity = velocity;

		if (IsOnFloor())
		{
			isFloating = false;

			if (Velocity.X != 0)
			{
				stm.Travel("Run");
			}
			else
			{
				stm.Travel("Idle");
			}
		}

		// Solo se cambia la booleana cuando el valor es distinto de 0 de forma que al quedarse quieto se guarda el valor correcto
		if (Velocity.X != 0)
		{
			lookingRight = direccion.X > 0;
		}

		sprite.FlipH = lookingRight;


		MoveAndSlide();
	}

	public void floatJump()
	{
		canFloat = false;
		isFloating = true;
	}

	public void UnlockFloatJump(){
		isFloatingJumpUnlock = true;
	}

	 // Método para obtener el estado del jugador
	public GameSaveManager.SaveData GetCurrentState()
	{
		return new GameSaveManager.SaveData
		{
			PlayerPosition = this.GlobalPosition, // Posición del jugador
			CurrentRoom = "Escena-04", // Nombre de la habitación actual (esto puede ser dinámico)
			DoubleJumpUnlocked = this.isFloatingJumpUnlock, // Estado del doble salto
		};
	}

	// Método para cargar el estado guardado del jugador
	private void LoadGameState()
	{
		var saveManager = GetTree().Root.GetNode<GameSaveManager>("/root/World/GameSaveManager");
		var saveData = saveManager.LoadGame();


		if (saveData != null)
		{
			// Restaurar la posición del jugador desde el guardado
			this.GlobalPosition = saveData.PlayerPosition;

			// Restaurar las habilidades desbloqueadas
			this.isFloatingJumpUnlock = saveData.DoubleJumpUnlocked;
		}
		else
		{
			GD.Print("No se encontró un guardado previo.");
		}
	}
}
