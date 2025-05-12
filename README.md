# 🎮 SODA RUSH

## Problemas durante el desarrollo

El dia 01/05/2025 se averió el equipo con el que se realizaba este proyecto y aun
no se conoce la fecha a la que se podrá volver a utilizar.

Como solución temporal he conseguido un ordenador con el que intentar avanzar
mientras se repara el ordenador principal.

Por este motivo el avance de esta semana no puede ser tan grande como el de
otras semanas y no habra video ya que el ordenador provisional a duras penas soporta
el motor godot.

## ☝️ Aspectos a tener en cuenta

Se opto por usar Visual Studio code debido a las facilidades que ofrece para
programar código con c# asi como las extensiones compatibles con desarollo en
godot.

Extensiones usadas:

- C# Tools for Godot versión 0.2.1
- C# Dev Kit versión 1.18.23

Herramientas Pensadas para ser usadas:

- Metroidvania System(MetSys) en su versión mas actualizada(_No implementada de momento_)

## 📕 Diario de actualizaciones

```
24/03/2025: Creación del Poryecto, configuración de godot y visual estudio code
24-31/03/2025: Negociaciones con artista para los assets del personaje **principal**
31/03/2025: Avance con tutoriales del motor godot
01/04/2025: Se ha progresado con el diseño del personaje principal junto con el artista,
            creacion de un personaje con assets de prueba
            y primera version de la maquina de estados
12/04/2025: Actualizacion con los movimientos básicos del personaje asi como físicas
            simples y un mapa linial para probarlas.
14/04/2025: Se añadio el movimiento del segundo salto sostenido.
20/04/2025: Se ha configurado la primera escena del juego, asi como su camara.
20-21/04/2025: Se ha intentado implementar el cambio entre escenas, pero no se ha logrado, de momento.
27/04/2025: Tras no ser capaz de hacer un cambio de escena con MetSys, se ha optado por
            implementar 2 enemigos básicos que siguen un camnino pre-definido.
            (El zombie hacer el moonwalk y es un feature intencionado).
29/04/25: Se ha implementado (POR FIN) el cambio de escenas sin el uso de MetSys para el cambio de escenas.
05/05/25: Se han añadido mas puertas y una escena mas donde se espera depositar el power up del
salto sostenido. Se han añadido sonidos para ser usados mas adelante.
06/05/25: Se han creado y conectado las salas básicas pensadas para usar las diferentes
            habulidades del personje princial.
12/05/25: Se ha cambiado algunos sprites del personaje principal para usar las animaciones del artista.
          Se han limitado las camaras en todas las escenas para solo mostrar aquello que se quiera mostrar
          y para que la camara se detenga al llegar a una puerta.S
```

## 📝 Errores

- [ ] Se ha encontrado un error en relacionado con los saltos, de vez en cuando el impulso del salto del personaje se dispara.
- [x] Se encontro un problema con las texturas anteriores por el cual no se podía configurar de forma adeucada el sistema de auto tiles.

**\*Corrección** : Se ha optado por usar unos tails que si fueran compatibles haciendo mas agil el desarrollo de los mapas.\*

- [x] Problemas y errores con el cambio de escenas.
  - [x] Se han encontrado ciertos problemas con la implementación del cambio de escenas y se han encontrado problemas como funcionalidades que el motor no soporta para C# o funciones no compotibles.
  - [x] Se han encontrado mas problemas con el cambio de escenas, debido a la dificultad para mezclar C# y GDScript. Los metodos proporcionados por MetSys.

**\*Corrección** : Tras mucho investigar y mucha prueba y error se ha llegado a una solución que pese a no ser la mas elegante es práctica y tampoco es demasido engorrosa ni complicada para la gestión entre el cambío de habitaciones.\*

## 📈 Progreso (en formato mini-videos)

 <details>
    <summary>Salto sostenido</summary>

  ![SodaRush - Movimientos básicos](https://github.com/user-attachments/assets/4d58c2d1-249c-4e78-9e64-d148f5527c7b)
</details>

 <details>
    <summary>Enemigos Básicos</summary>

![SodaRush - Enemigos básicos](https://github.com/user-attachments/assets/a6ce4031-e78b-4f9e-a822-31685afa6710)
</details>

 <details>
    <summary>Cambio de escenas</summary>

![SodaRush - Cambio de escenas](https://github.com/user-attachments/assets/6a719379-7c00-45e5-af8e-9099f500718c)
</details>

## 🎨 Progreso de la artista

  <p align="center">
  <img src="https://github.com/user-attachments/assets/e75d414c-740a-430e-b147-84eafddee02e" width="200" alt="Artista 1" />
  <img src="https://github.com/user-attachments/assets/70bc01c6-2001-4a84-ac20-570984db24bf" width="200" alt="Artista2 2" />
  <img src="https://github.com/user-attachments/assets/17baa085-01c9-4729-b91e-38f28e435b02" width="200" alt="Artista3 3" />
</p>

![artista4](https://github.com/user-attachments/assets/02fa9488-50cc-4126-af25-de6b734bfaa3)

## 💻 Tutoriales, docuemntaciones y enlaces interesantes utilizados

- Vídeo para el salto sostenido: https://www.youtube.com/embed/aQ6l7HNELLg?si=SUBtNdPrhulkqzVk
  [![Alt text](https://img.youtube.com/vi/aQ6l7HNELLg/0.jpg)](https://www.youtube.com/watch?v=aQ6l7HNELLg)

- Vídeo para el uso de tiles y auto tiles: https://www.youtube.com/watch?v=CLcFC6ku240
  [![Alt text](https://img.youtube.com/vi/CLcFC6ku240/0.jpg)](https://www.youtube.com/watch?v=CLcFC6ku240)

- Vídeo para ajustar los limites de la camara: https://www.youtube.com/watch?v=kQbkue9sCAg
  [![Alt text](https://img.youtube.com/vi/kQbkue9sCAg/0.jpg)](https://www.youtube.com/watch?v=kQbkue9sCAg)

- Enlace util para conocer más sobre como organizar código en godot y otros consejos útiles:
  https://new.pythonforengineers.com/blog/how-to-structure-your-godot-project-so-you-dont-get-confused/

## 🤖 Props de ia usados

- **_Nota: Debido a ciertos problemas los props originales para la creracion del diseño del personaje principal se han perdido._**

- Imagenes generadas por ia que se le han facilitado a la artista:
  <p align="center">
  <img src="https://github.com/user-attachments/assets/e7a6aaaf-c84e-415f-ade4-689b758187db" width="200" alt="Imagen 1" />
  <img src="https://github.com/user-attachments/assets/d545aaa8-787c-4024-bf9b-308cf630f647" width="200" alt="Imagen 2" />
  <img src="https://github.com/user-attachments/assets/84d6c205-4ace-47f8-ad4b-481dcf6ebfa1" width="200" alt="Imagen 3" />
</p>
