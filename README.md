# 🎵 MusicBox – Proyecto II (C# / .NET)

**MusicBox** es un proyecto académico que implementa una *caja musical digital*. El sistema es capaz de **leer una partitura escrita como texto**, **almacenarla en una lista doblemente enlazada**, y **reproducirla** utilizando las **frecuencias reales de las notas musicales** y **duraciones proporcionales**, con control de tempo y reproducción en ambos sentidos.

El proyecto fue desarrollado en **C# con .NET**, siguiendo principios de **programación orientada a objetos**, **separación de responsabilidades** y **diseño desacoplado**, de forma que sea fácil de probar, mantener y defender.

---

## 📌 Objetivos del proyecto

* Interpretar una partitura musical en formato texto.
* Modelar los eventos musicales mediante estructuras de datos lineales.
* Implementar una **lista doblemente enlazada** para permitir recorrido *forward* y *backward*.
* Reproducir notas con:

  * frecuencia correcta (Hz)
  * duración proporcional a la figura musical
* Permitir modificar dinámicamente la duración de la **negra**.
* Validar el sistema mediante **pruebas unitarias**.

---

## 🧠 Conceptos teóricos aplicados

* **Listas doblemente enlazadas**
* **Parsing de strings**
* **Programación orientada a objetos (POO)**
* **Inversión de dependencias (IPlayerAudio)**
* **Separación de capas (Domain / Core / Playback / CLI)**
* **Testing unitario con xUnit**

---

## 🏗️ Arquitectura del sistema

El proyecto está dividido en módulos claramente definidos:

### 🔹 MusicBox.Domain

* Representa el *modelo del dominio*.
* Contiene:

  * `Note` (notas musicales)
  * `Figure` (figuras musicales)
  * `MusicEvent`
  * `Tempo`

### 🔹 MusicBox.Structures

* Implementa la **lista doblemente enlazada genérica**.
* Permite recorrer la partitura en ambos sentidos sin reconstruir datos.

### 🔹 MusicBox.Core

* Lógica central del sistema.
* Incluye:

  * `ScoreParser`
  * `MusicBoxApp`

### 🔹 MusicBox.Playback

* Encargado de la reproducción.
* Contiene:

  * `Player`
  * `IPlayerAudio` (interfaz)
  * `BeepAudioEngine` (implementación concreta)

### 🔹 MusicBox.Cli

* Interfaz de usuario por consola.
* Permite interactuar con el sistema mediante comandos.

### 🔹 MusicBox.Tests

* Pruebas unitarias con **xUnit**.

---

## 🎼 Formato de la partitura

La partitura se introduce como un string con el siguiente formato:

```text
(Nota, Figura), (Nota, Figura), ...
```

### Notas soportadas

* Do
* Re
* Mi
* Fa
* Sol
* La
* Si

### Figuras soportadas

* Redonda
* Blanca
* Negra
* Corchea
* Semicorchea

---

## ⏱️ Control de tempo

La **negra** es la figura base y su duración puede configurarse entre:

* **100 ms** (mínimo)
* **5000 ms** (máximo)

Las demás figuras se calculan proporcionalmente:

| Figura      | Proporción   |
| ----------- | ------------ |
| Redonda     | 4 × negra    |
| Blanca      | 2 × negra    |
| Negra       | 1 × negra    |
| Corchea     | 0.5 × negra  |
| Semicorchea | 0.25 × negra |

---

## 🖥️ Uso del CLI

Para ejecutar la aplicación:

```bash
dotnet run --project src/MusicBox.Cli/MusicBox.Cli.csproj
```

### Comandos disponibles

| Comando        | Descripción                                         |
| -------------- | --------------------------------------------------- |
| `demo`         | Carga y reproduce una partitura de demostración     |
| `load <texto>` | Carga una partitura personalizada                   |
| `set <ms>`     | Cambia la duración de la negra                      |
| `fwd`          | Reproduce hacia adelante                            |
| `bwd`          | Reproduce hacia atrás                               |
| `count`        | Muestra la cantidad de notas                        |
| `verbose on`   | Muestra nota, Hz y duración durante la reproducción |
| `verbose off`  | Desactiva el modo verbose                           |
| `help`         | Muestra ayuda                                       |
| `exit`         | Finaliza el programa                                |

---

## 🎶 Ejemplo de uso

```text
demo
verbose on
set 250
fwd
bwd
```

Salida esperada:

```text
Playing: Do (261.63 Hz) - Negra (250 ms)
Playing: Re (293.66 Hz) - Corchea (125 ms)
...
```

---

## 🧪 Pruebas unitarias

Las pruebas están implementadas con **xUnit** y cubren:

* Parsing válido e inválido
* Límites de tempo
* Duraciones proporcionales
* Reproducción forward y backward

Ejecutar tests:

```bash
dotnet test MusicBox.sln
```

---

## 📂 Estructura del repositorio

```
MusicBox/
├─ src/
│  ├─ MusicBox.Domain/
│  ├─ MusicBox.Structures/
│  ├─ MusicBox.Core/
│  ├─ MusicBox.Playback/
│  └─ MusicBox.Cli/
│
├─ tests/
│  └─ MusicBox.Tests/
│
├─ docs/
│  ├─ UML/
│  └─ TestPlan.pdf
│
├─ MusicBox.sln
└─ README.md
```

---

## 🧑‍🏫 Notas para la evaluación

* El uso de una **lista doblemente enlazada** permite recorrer la partitura en ambos sentidos de forma eficiente.
* La interfaz `IPlayerAudio` desacopla la lógica de reproducción del método concreto de audio.
* El modo `verbose` demuestra explícitamente que las **frecuencias y duraciones son correctas**.
* El comando `demo` permite validar rápidamente el funcionamiento completo del sistema.

---

## 👨‍💻 Autor

**Julian**
Proyecto académico – Ingeniería en Computación

---

✅ Proyecto completo, funcional y listo para evaluación.
