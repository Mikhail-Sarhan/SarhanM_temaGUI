# Lab 11 tema

## 1. Care este rolul comenzilor GL.PushMatrix() și GL.PopMatrix()? De ce sunt necesare?

- **Rolul GL.PushMatrix():**
  - Salvează starea curentă a matricei.
  - Permite să faci modificări temporare (ex. rotații, translații) fără să afecteze alte obiecte din scenă.

- **Rolul GL.PopMatrix():**
  - Restaurează starea matricei salvată cu GL.PushMatrix().
  - Este util pentru a reveni la transformările anterioare.

- **De ce sunt necesare?**
  - Previn acumularea transformărilor care ar putea afecta alte obiecte.
  - Asigură că fiecare obiect are transformările sale izolate.

**Exemplu:**
```csharp
GL.PushMatrix();
GL.Translate(1.0f, 0.0f, 0.0f); 
DrawCube();                     
GL.PopMatrix();
```
## 2. Explicați efectele metodelor GL.Rotate(), GL.Translate() și GL.Scale() cu exemple.

### **GL.Rotate()**
- **Efect:** Rotește obiectul în jurul unui ax.
- **Parametri:** unghi, axele X, Y, Z.

**Exemplu:**
```csharp
GL.Rotate(45.0f, 0.0f, 1.0f, 0.0f);
```
### **GL.Translate()**
- **Efect:** Mută (translează) obiectul într-o poziție diferită.
- **Parametri:** deplasarea pe axele X, Y, Z.
**Exemplu:**
```csharp
GL.Translate(1.0f, 2.0f, 0.0f);
```

### **GL.Scale()**
- **Efect:**  Schimbă dimensiunea obiectului.
- **Parametri:** factorii de scalare pentru axele X, Y, Z.
**Exemplu:**
```csharp
GL.Scale(2.0f, 1.0f, 1.0f); 
```

## 3. Câte niveluri de manipulări ierarhice suportă o scenă OpenGL folosind GL.PushMatrix() și GL.PopMatrix()?

OpenGL suportă stive de matrice, care limitează numărul de niveluri.

Numărul exact depinde de implementarea OpenGL, dar în mod tipic:

Modelview Matrix Stack: ~32 niveluri.
Projection Matrix Stack: ~2 niveluri.
Dacă se depășește limita, se generează o eroare.




