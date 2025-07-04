using Godot;
using System;

public partial class MainMenu : Control
{
    private void OnPlayButtonPressed()
    {
        // Cambiar a la escena del juego
        GetTree().ChangeSceneToFile("res://World.tscn"); // Cambia esta ruta si tu escena se llama distinto
    }

    private void OnExitButtonPressed()
    {
        // Salir del juego
        GetTree().Quit();
    }
}
