# Roblox Multiple Accounts

This project enables you to run multiple instances of Roblox on the same machine, allowing you to use multiple accounts simultaneously. The program ensures that you can open as many Roblox clients as your computer can handle by managing Roblox's singleton mutex and handling potential cookie-related issues.

## Features

- Run multiple Roblox clients simultaneously.
- Handles the "773 error" automatically if detected.
- Simple and lightweight console application.

## Getting Started

### Prerequisites

- .NET Framework (version 4.6 or later)

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/damlano/roblox-multiple-accounts.git
    ```

2. Navigate to the project directory:

    ```bash
    cd roblox-multiple-accounts
    ```

3. Build the project using your preferred .NET build tool or IDE.

### Usage

1. Run the compiled executable.

2. The application will check for the existence of the `RobloxCookies.dat` file and attempt to apply a fix for the "773 error" if necessary.

3. If the "773 error" fix is not needed or cannot be applied, the application will notify you.

4. Once the application is running, you can open multiple Roblox clients.

5. To close the application, press any key.

## Configuration

- To disable the "773 error" fix, create a file named `no773fix.txt` in the same directory as the executable.

## Contributing

Contributions are welcome! If you have any suggestions or improvements, please open an issue or submit a pull request.

## License

Hereby i grant anyone to use this and edit this project feel free to do whatever you want with it.

## Contact

For any issues make a issue thing

---

Enjoy using multiple Roblox accounts on your computer! If you encounter any problems, feel free to reach out for support.
