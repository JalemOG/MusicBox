# 🎵 MusicBox – Proyecto II (C#)

Proyecto académico que implementa una **Music Box** capaz de leer una partitura en formato texto, almacenarla en una **lista doblemente enlazada** y **reproducirla** usando las **frecuencias reales de las notas musicales** y **duraciones proporcionales**, con control de tempo y reproducción **forward / backward**.

El proyecto está desarrollado en **C# (.NET)** y sigue una arquitectura modular pensada para ser **fácil de testear, extender y defender**.

---

## ✨ Características principales

* ✅ Parsing de partituras con formato:

  ```text
  (Do, negra), (Re, blanca), (Mi, corchea)
  ```
* ✅ Almacenamiento en **lista doblemente enlazada**
* ✅ Reproducción **hacia adelante y hacia atrás**
* ✅ Frecuencias reales (Hz) por nota musical
* ✅ Duraciones proporcionales basadas en la **negra** (100 ms – 5000 ms)
* ✅ Reproductor por consola usando `Console.Beep`
* ✅ Modo **demo** automático
* ✅ Modo **verbose** para mostrar Hz y duración mientras suena
* ✅ Tests unitarios (xUnit)
* ✅ Arquitectura desacoplada (audio intercambiable)

---

## 🧠 Arquitectura del proyecto

El proyecto está dividido en varios módulos:

* **MusicBox.Domain**
  Entidades del dominio (Note, Figure, MusicEvent, Tempo)

* **MusicBox.Structures**
  Implementación de la lista doblemente enlazada genérica

* **MusicBox.Core**
  Lógica principal: parser, orquestación y control del flujo

* **MusicBox.Playback**
  Motor de reproducción (Player) + interfaz de audio

* **MusicBox.Cli**
  Aplicación de consola para interactuar con el sistema

* **MusicBox.Tests**
  Pruebas unitarias (parser, tempo, playback, etc.)

---

## 🚀 Requisitos

* **.NET SDK 9.0** o superior
* Sistema operativo **Windows** (por uso de `Console.Beep`)

Verificar instalación:

```bash
dotnet --version
```

---

## ▶️ Cómo compilar y ejecutar

Desde la raíz del repositorio:

### 1️⃣ Restaurar dependencias

```bash
dotnet restore MusicBox.sln
```

### 2️⃣ Compilar

```bash
dotnet build MusicBox.sln
```

### 3️⃣ Ejecutar la aplicación CLI

```bash
dotnet run --project src/MusicBox.Cli/MusicBox.Cli.csproj
```

---

## 🖥️ Uso del CLI

Al iniciar el programa se muestra un menú interactivo.

### Comandos disponibles

| Comando        | Descripción                                     |
| -------------- | ----------------------------------------------- |
| `demo`         | Carga y reproduce una partitura de demostración |
| `load <texto>` | Carga una partitura manual                      |
| `set <ms>`     | Cambia la duración de la negra (100–5000 ms)    |
| `fwd`          | Reproduce hacia adelante                        |
| `bwd`          | Reproduce hacia atrás                           |
| `count`        | Muestra cuántas notas hay cargadas              |
| `verbose on`   | Muestra nota, Hz y duración al reproducir       |
| `verbose off`  | Desactiva el modo verbose                       |
| `help`         | Muestra ayuda                                   |
| `exit`         | Sale del programa                               |

---

## 🎶 Ejemplo de partitura válida

```text
(Do, negra), (Re, corchea), (Mi, corchea), (Fa, blanca), (Sol, negra)
```

---

## 🧪 Ejecutar tests

El proyecto incluye pruebas unitarias con **xUnit**.

```bash
dotnet test MusicBox.sln
```

Los tests validan:

* Parsing correcto e incorrecto
* Límites de tempo
* Orden forward / backward
* Frecuencias y duraciones generadas

---

## 📂 Estructura del repositorio

```
MusicBox/
├─ src/
│  ├─ MusicBox.Core/
│  ├─ MusicBox.Domain/
│  ├─ MusicBox.Structures/
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

## 📌 Notas para la defensa

* La **lista doblemente enlazada** permite recorrer la partitura en ambos sentidos sin reconstruir datos.
* El uso de una **interfaz de audio (`IPlayerAudio`)** permite cambiar el método de reproducción sin tocar el core.
* El modo `verbose` demuestra claramente que las **frecuencias y duraciones** son correctas.
* El comando `demo` permite validar el funcionamiento completo en segundos.

---

## 👨‍💻 Autor

**Janik Hamilton**
Proyecto académico – Ingeniería en Computadores TEC

---

✅ Proyecto listo para evaluación, pruebas y demostración.
