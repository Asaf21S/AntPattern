# AntPattern

A C# simulation of ant-inspired behavior and emergent pattern formation based on scent trails in a 2D grid environment.  
Based on [Langton's ant turing machine](https://en.wikipedia.org/wiki/Langton%27s_ant).

---

## Overview

This project simulates how simple agents—modeled after ants—can form complex patterns through local interactions. Ants move across a grid, influenced by scent strength left by themselves. Over time, this produces visually interesting and self-organized trail patterns.

---

## Features

- Ant agents with direction, movement, and scent-based logic
- Scent trails that decay over time
- Real-time grid visualization using Windows Forms (`System.Drawing`)
- Customizable simulation parameters: number of ants, grid size, scent decay, etc.

---

## Technologies Used

- C#
- .NET Framework (Windows Forms)
- `System.Drawing` for visualization
