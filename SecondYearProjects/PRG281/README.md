
# 🛒 Stock Inventory System for Small Shops

## 📌 Project Overview

The **Stock Inventory System** is a C# console-based application designed to help small shop owners and their staff manage inventory efficiently. It eliminates the need for manual stock tracking, reduces human error, and introduces automated reorder alerts to prevent stockouts.

---

## 🎯 Problem Statement

Many small local stores still rely on pen-and-paper or spreadsheets to track stock. This method is error-prone, lacks automation, and doesn’t scale well. Products often run out without warning, and overstocking leads to wasted resources.

This project provides a simple, user-friendly system that allows shopkeepers to:

- Monitor inventory in real-time
- Receive low-stock notifications
- Assign roles (Admin and Staff)
- Save and retrieve stock data from a file

---

## 🛠 Features

- ✅ **Add / Remove / Update Products**


---

## 🧱 Technologies Used

- Language: **C#**
- Framework: **.NET Console Application**
- Concepts:
  - Object-Oriented Programming (OOP)
  - Events and Delegates


---

## 📂 Project Structure

```plaintext
/StockInventorySystem
│
├── Program.cs               // Main entry point
├── Product.cs               // Defines Product class
├── Inventory.cs             // Manages product list and file operations
├── User.cs                  // Handles user login and roles
├── InventoryManager.cs      // Handles low-stock events
├── LowStockEventArgs.cs     // Custom EventArgs for stock alerts
├── inventory.txt            // Example data file (optional)
└── README.md                // Project documentation
```

---

## 🚀 Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/yourusername/StockInventorySystem.git
cd StockInventorySystem
```

### 2. Open in Visual Studio

- Open the `.sln` file in **Visual Studio 2022 or later**
- Build the solution
- Run the console app

---


## 📝 Future Improvements

- GUI version using WinForms or WPF
- Export reports to CSV or PDF
- Barcode scanning integration
- Multi-store cloud sync

---

## 📄 License

This project is developed as part of the **PRG2781** coursework at **Belgium Campus ITversity**. Free for educational use.

---

## 👨‍💻 Author

Freerk Van Den Bos  
[GitHub: FreerkvdB](https://github.com/FreerkvdB)]

---
