# ⚡ Roblox Lua Executor

<p align="center">
  <img src="https://img.shields.io/github/stars/ItsMeD4N/Roblox-Lua-Executor?style=for-the-badge"/>
  <img src="https://img.shields.io/github/license/ItsMeD4N/Roblox-Lua-Executor?style=for-the-badge"/>
  <img src="https://img.shields.io/github/last-commit/ItsMeD4N/Roblox-Lua-Executor?style=for-the-badge"/>
</p>

A **super clean and modern Roblox Lua script executor** built with **C# and DLL injection**. Features a dark-themed custom UI, tabbed Lua editor, and built-in support for external APIs like Nezur, Velocity, and Xeno.

---

## 🚀 Features

- 💻 Modern dark-themed UI with fixed size window
- 📂 Load / Save / Inject / Execute Lua scripts
- 🧠 Tab-based script editor (Scintilla or FastColoredTextBox)
- 🔐 Built-in DLL injection system (`Nezur.dll`, `VelocityAPI.dll`, etc.)
- 🔍 Roblox auto-detection and script test support
- ✨ Print, spawn part, access `game.Players.LocalPlayer`

---

## 🛠️ Tech Stack

- Language: C# (.NET WinForms)
- UI: Custom-designed, no resize, top-most behavior
- Injection: DLL-based (manual mapping or LoadLibrary)
- Target: Roblox 64-bit environment

---

## 📦 How to Build

1. Clone the repo:
   ```bash
   git clone https://github.com/ItsMeD4N/Roblox-Lua-Executor.git
   ```
2. Open `Roblox Lua Executor.sln` in Visual Studio
3. Set build target to `x64`
4. Add your own DLLs (`VelocityAPI.dll`, `Nezur.dll`, etc.) to the output folder
5. Build and run!

---

## 🧪 Test Script

```lua
print("UNC Test: Hello from your executor!")

local p = game:GetService("Players").LocalPlayer
print("Hi, " .. p.Name)

local part = Instance.new("Part")
part.Name = "UNC_Test_Block"
part.Size = Vector3.new(5,1,5)
part.Position = Vector3.new(0,10,0)
part.Anchored = true
part.BrickColor = BrickColor.new("Bright blue")
part.Parent = workspace
```

---

## 📜 License

This project is licensed under the [MIT License](LICENSE).

---

## 👑 Author

Made with ⚡ by [ItsMeD4N](https://github.com/ItsMeD4N)
