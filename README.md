# Práctica #3 de Interfaces Inteligentes: Introducción a Físicas 3D

Esta es la tercera práctica de la asignatura **Interfaces Inteligentes** (curso 2026-2027), perteneciente al [Grado en Ingeniería Informática](https://www.ull.es/grados/ingenieria-informatica/) de [La Universidad de La Laguna](https://www.ull.es/).

El objetivo principal de esta práctica es experimentar y comprender el funcionamiento del motor de físicas de Unity. A través de dos hojas de ejercicios, se analizan las interacciones entre diferentes configuraciones de componentes `Rigidbody` (dinámicos y cinemáticos), `Collider`, `Physic Material` y el sistema de colisiones por capas (Layer Collision Matrix).

La metodología seguida para su realización es la siguiente:

* Sincronización del proyecto de Unity con este repositorio.
* Creación del directorio **Scripts** con todo el código C# desarrollado para la segunda parte.
* División de la práctica en escenas específicas según la necesidad de la situación o ejercicio.

[Enlace a la hoja de experimentos/situaciones propuestas.](https://docs.google.com/document/d/1xuS0TPw60dGrWRlk0i0DOMYCXG8RRI68V-GyzjVtDRo/edit?tab=t.0)

[Enlace a la hoja de problemas.](https://docs.google.com/document/d/1rfIMdkudzOZIKlBVq1KNcCnE-7IC48c0jWGYRMmHbOU/edit?tab=t.0)

## Parte 1: Experimentación con Rigidbody y Colliders

En esta primera parte, partimos de una escena base con un Plano, un Cubo (en $y=0.5$) y una Esfera suspendida en el aire encima del cubo. Se han probado 9 configuraciones distintas:

### Situación 1: Cubo físico, resto estático
* **Plano:** `Collider` (estático).
* **Cubo:** `Rigidbody` dinámico + `Collider`.
* **Esfera:** `Collider` (estática).

![Demostración Situación 1](GitImages/Situación01-P03-II.gif)

Vemos en el GIF que la escena queda prácticamente inmóvil. El cubo, al tener masa y gravedad, reposa sobre el plano sin atravesarlo (colisión `Dynamic vs Static`). La esfera, al no tener `Rigidbody`, ignora la física y se queda suspendida en el aire donde fue colocada inicialmente.

### Situación 2: Cubo y esfera físicos
* **Plano:** `Collider`.
* **Cubo:** `Rigidbody` dinámico.
* **Esfera:** `Rigidbody` dinámico.

![Demostración Situación 2](GitImages/Situación02-P03-II.gif)

En esta ocasión, la esfera cae por efecto de la gravedad, impacta contra el cubo y lo desestabiliza. Ambos objetos están sobre el plano. Al tener ambos masa (por defecto 1), la transferencia de energía en el impacto es equitativa y la esfera rueda hacia un lado debido a su posición inicial ligeramente descentrada hasta caerse por el plano.

### Situación 3: Esfera cinemática
* **Plano:** `Collider`.
* **Cubo:** `Rigidbody` dinámico.
* **Esfera:** `Rigidbody` con `Is Kinematic = true`.

![Demostración Situación 3](GitImages/Situación03-P03-II.gif)

El resultado visual es idéntico a la Situación 1: el cubo reposa en el plano y la esfera flota. La diferencia fundamental recae en el concepto: un objeto cinemático (en este caso, la esfera) tiene `Rigidbody` pero su movimiento no es controlado por el motor de físicas (ignora fuerzas y gravedad), sino por código/animaciones (que no están presentes en el experimento).

### Situación 4: Todo físico (plano dinámico)
* **Plano:** `Rigidbody` dinámico.
* **Cubo:** `Rigidbody` dinámico.
* **Esfera:** `Rigidbody` dinámico.

![Demostración Situación 4](GitImages/Situación04-P03-II.gif)

Toda la escena se desploma hacia el vacío. Al añadir un `Rigidbody` estándar al plano, este deja de actuar como un "suelo" estático y pasa a ser un objeto físico más que es arrastrado por la gravedad. Esto demuestra la importancia de mantener los elementos del terreno como estáticos o cinemáticos.

### Situación 5: Plano cinemático, esfera x10 masa
* **Plano:** `Rigidbody` cinemático.
* **Cubo:** `Rigidbody` dinámico (masa = 1).
* **Esfera:** `Rigidbody` dinámico (masa = 10).

![Demostración Situación 5](GitImages/Situación05-P03-II.gif)

El plano cinemático vuelve a sostener la escena (`Kinematic vs Dynamic` genera colisión). Al caer la esfera, su masa es diez veces superior a la del cubo, por lo que lo desetabiliza aún más que cuando tenía masa 1.

### Situación 6: Plano cinemático, esfera x100 masa
* **Plano:** `Rigidbody` cinemático.
* **Cubo:** `Rigidbody` dinámico (masa = 1).
* **Esfera:** `Rigidbody` dinámico (masa = 100).

![Demostración Situación 6](GitImages/Situación06-P03-II.gif)

El comportamiento es igual al anterior pero con un efecto más exagerado. La diferencia de masa es tan grande (100:1) que la esfera apenas nota el impacto, continuando su caída, mientras que el cubo se ve afectado de forma más violenta.

### Situación 7: Todo físico + Fricción
* **Plano:** `Rigidbody` dinámico.
* **Cubo:** `Rigidbody` dinámico.
* **Esfera:** `Rigidbody` dinámico + `Physic Material` con fricción.

![Demostración Situación 7](GitImages/Situación07-P03-II.gif)

Al igual que en la situación 4, todo cae debido a que el plano es dinámico. Sin embargo, gracias al material físico aplicado a la esfera con alta fricción, esta no debería resbalar sobre la superficie del cubo. Se quedaría "pegada" a él y ambos caerían de manera más compacta.

Nota: el efecto del material utilizado se verá mejor en el ejercicio 05 que se expone más adelante.

El material utilizado:

![Captura material rugoso](GitImages/CapturaMaterialRugoso-P03-II.png)

### Situación 8: Esfera Trigger no física
* **Plano:** `Rigidbody` cinemático.
* **Cubo:** `Rigidbody` dinámico.
* **Esfera:** `Collider` con `Is Trigger = true`, sin `Rigidbody`.

![Demostración Situación 8](GitImages/Situación08-P03-II.gif)

La escena se mantiene estática. El cubo reposa en el plano y la esfera flota. Al estar marcada como `isTrigger`, la esfera se convierte en un volumen intangible que no genera respuesta física, ideal para detectar eventos de paso (`OnTriggerEnter`) sin obstaculizar el movimiento.

### Situación 9: Esfera Trigger física
* **Plano:** `Rigidbody` cinemático.
* **Cubo:** `Rigidbody` dinámico.
* **Esfera:** `Rigidbody` dinámico + `Collider` con `Is Trigger = true`.

![Demostración Situación 9](GitImages/Situación09-P03-II.gif)

La esfera cae por la gravedad (ya que es un objeto dinámico), pero al ser un `Trigger`, atraviesa completamente el cubo y el plano sin inmutarlos, cayendo al infinito. Esto confirma que `Is Trigger` anula cualquier tipo de colisión física sólida.

## Parte 2: Scripts y Físicas Aplicadas

### Ejercicio 1: Control de Personaje Físico

* Código desarrollado en [Scripts/Ej1PlayerMovement.cs](Scripts/Ej1PlayerMovement.cs)
* Demostración en GIF:
![Demostración ejercicio 1](GitImages/Ejercicio01-P03-II.gif)

Vemos cómo el personaje se desplaza por la escena manteniendo las propiedades físicas.

En cuanto al script:
* Capturamos las entradas del usuario a través de `Input.GetAxis` en los ejes horizontales y verticales dentro de la función `Update`.
* El movimiento se aplica de forma estricta y segura en la función de físicas `FixedUpdate()` haciendo uso de `rigidbody.MovePosition()`, garantizando así que no "atravesemos" paredes de manera brusca ni se desestabilice el motor, lo cual podría ocurrir si usásemos simple traslación sobre el `Transform`.

### Ejercicio 2: Colisiones, Cambio de Color y Mensajes por Consola

* Código desarrollado en [Scripts/Ej2ColisionInformeColor.cs](Scripts/Ej2ColisionInformeColor.cs)
* Demostración en GIF:
![Demostración ejercicio 2](GitImages/Ejercicio02-P03-II.gif)

En el GIF se aprecian varios objetos cayendo/interactuando y cambiando a un color completamente aleatorio en el mismo instante en que se tocan.

En cuanto al script:
* Se hace uso del evento `OnCollisionEnter(Collision collision)` exclusivo de las colisiones físicas no-trigger.
* Se notifica a consola con quién ha colisionado utilizando el nombre del GameObject implicado (`collision.gameObject.name`).
* Hemos creado un método privado `randomColorGenerator()` que devuelve un color al azar utilizando `Random.Range` para cada componente (R, G, B), el cual se aplica al `MeshRenderer` del objeto instantes después del choque.

### Ejercicio 3: Zonas Trigger (Cambios de Luz, Color y Estadísticas)

* Códigos desarrollados en: 
  - [Scripts/Ej3ZonaCambioColorPersonaje.cs](Scripts/Ej3ZonaCambioColorPersonaje.cs)
  - [Scripts/Ej3ZonaCambioLuz.cs](Scripts/Ej3ZonaCambioLuz.cs)
  - [Scripts/Ej3ZonaAumentoDamage.cs](Scripts/Ej3ZonaAumentoDamage.cs)
  - [Scripts/Ej3PlayerStats.cs](Scripts/Ej3PlayerStats.cs)
* Demostración en GIF:
![Demostración ejercicio 3](GitImages/Ejercicio03-P03-II.gif)

El jugador se desplaza entrando y saliendo de diferentes cubos translúcidos marcados como Triggers. Al entrar cambian propiedades del entorno o del propio jugador y al salir se revierten a la normalidad.

Lo que modifica cada zona en el GIF:
* Zona amarilla: modifica la luz
* Zona violeta: cambia el color del jugador (a blanco)
* Zona amarilla con gradiente violeta: altera tanto la luz como el color del jugador.
* Zona roja: cambia la estadística/variable del jugador Damage (daño). Por consola se muestran los cambios y en el Inspector se puede ver el cambio en tiempo real.

Se usó un material transparente para las zonas para poder ver bien cómo el jugador las atraviesa.

En cuanto a la implementación:
* Hacemos uso intensivo de `OnTriggerEnter` y `OnTriggerExit`.
* En todos los scripts se verifica previamente el `tag` del objeto colisionado usando `other.gameObject.CompareTag("Player")`.
* Se almacenan siempre los valores previos (`originalPlayerColor` y `previousIntensity`) para poder dejarlos como estaban tras abandonar la zona de influencia.
* Hemos delegado la responsabilidad del sistema de daño (interpretando la zona de daño como un aumento o decremento de la estadística de daño/fuerza del jugador). El Player posee un script `Ej3PlayerStats` con una función pública `ModifyDamage()`. La zona simplemente llama a este método incrementando o restando valor.

### Ejercicio 4: Filtros y Matriz de Colisiones por Capas

* Código desarrollado en [Scripts/Ej4RecolectableDetecta.cs](Scripts/Ej4RecolectableDetecta.cs)
* Demostración en GIF:
![Demostración ejercicio 4](GitImages/Ejercicio04-P03-II.gif)

En el GIF se usa a un jugador negro que no tiene el Layer de Player para mostrar que solo el jugador interactúa con los enemigos. Los enemigos no interactúan entre sí. Los recolectables interactúan con todo menos con los enemigos.

Este ejercicio requería usar el menú **Project Settings > Physics**.
* Configuramos tres `Layers` nuevos: Player, Enemigo ("Enemy") y Recolectable ("Collectable").
* Modificamos la **Layer Collision Matrix** para que "Enemy" solo colisione físicamente con "Player".
* Los objetos con capa "Collectable" solo son detectados mediante Triggers. El script `Ej4RecolectableDetecta.cs` alerta por consola al entrar un objeto y lo activa forzosamente como `isTrigger` si nos hemos olvidado de marcarlo en el inspector.

He aquí la Collision Matrix configurada:

![Collision Matrix configurada](GitImages/CapturaCollisionMatrix-P03-II.png)

### Ejercicio 5: Materiales Físicos y Lanzamiento mediante Fuerzas

* Código desarrollado en [Scripts/Ej5LanzarObjeto.cs](Scripts/Ej5LanzarObjeto.cs)
* Demostración en GIF:
![Demostración ejercicio 5](GitImages/Ejercicio05-P03-II.gif)

Vemos tres objetos lanzados al mismo tiempo, los cuales caen en diferentes superficies (resbaladiza para el color hielo, rugosa para el color verde oscuro y de alto rebote para el color rosa chicle) comprobando la reacción que generan los `Physic Materials`.

Vemos que el cubo color hielo se desliza mucho, el rugoso tiene dificultades para avanzar (el primero en quedarse quieto) y el rosa chicle rebota mucho.

En cuanto al script:
* Se ha configurado un input llamado `LanzarObjeto` que detecta un pulsador mediante `Input.GetAxis()`.
* Al accionarlo, se aplica `rigidbody.AddForce(throwDirection * multiplicadorFuerza, ForceMode.Impulse);`. El modo de fuerza `Impulse` es crucial aquí para darle un "golpe seco" instantáneo dependiente de su masa en un solo frame.
* Usamos un flag booleano `objectThrown` para asegurar que cada objeto se lance una única vez.

He aquí el input `LanzarObjeto` configurado:

![Collision Matrix configurada](GitImages/CapturaLanzarObjetoInputManager-P03-II.png)

Captura de los materiales utilizados:

![Captura material resbaladizo](GitImages/CapturaMaterialResbaladizo-P03-II.png)

![Captura material rugoso](GitImages/CapturaMaterialRugoso-P03-II.png)

![Captura material rebote alto](GitImages/CapturaMaterialReboteAlto-P03-II.png)

### Ejercicio 6: Intersección Manual de Componentes sin Rigidbody

* Código desarrollado en [Scripts/Ej6PerseguirObjetivo.cs](Scripts/Ej6PerseguirObjetivo.cs)
* Demostración en GIF:
![Demostración ejercicio 6](GitImages/Ejercicio06-P03-II.gif)

La esfera persigue al cilindro en línea recta. Cuando su volumen se solapa con el cubo intermedio (recordemos que aquí ningún objeto tiene `Rigidbody`), el cubo cambia de color como si fuese una colisión física.

Se usó un material transparente para poder ver bien cómo lo atraviesa.

En cuanto al script:
* **Movimiento:** Ya que no interviene la gravedad ni las físicas, actualizamos directamente la posición usando `Vector3.MoveTowards()` en `Update()`, el cual se desplaza elegantemente sin pasarse de la posición final `targetPosition`.
* **Detección de Intersección:** Al no disponer de motor de físicas para avisarnos (`OnCollision` requiere de Rigidbodies), la detección de contacto se hizo comprobando el volumen de los `Colliders` matemáticamente en cada frame: `obstacleCollider.bounds.Intersects(myCollider.bounds)`. En cuanto devuelve verdadero, aplicamos el cambio visual e instanciamos nuestra variable de control `cuboAlcanzado`.