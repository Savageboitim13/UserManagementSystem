# User Management System
# About
- Test-Based
- Hashed (SHA256)
- MariaDB storage

## Usage
__**Preinstallations | Requirements**__
`MySqlConnector v2.2.7` <br>
`System.Configuration.ConfigurationManager v7.0.0"` <br>
`Renci.SshNet v2020.0.2` <br>
`TargetFramework .NET v7.0` <br>
`LangVersion 8.0` <br>

->`dotnet restore` | Installs required libraries

Clone the repository: `git clone https://github.com/Savageboitim13/UserManagementSystem.git`
Replace credentials for SSH sever and MariaDB server in `/UserManagementSystem/Backend/DB/App.config`

Run: `dotnet run`

## Status - Tested?
Some features may be already implemented, but not tested properly!
[x] SSH server connection over Private / Public Key Files
[x] MariaDB server connection over SSH port forwarding
[x] Store hashed Username & Password
[ ] Registration
[ ] LogIn
[ ] Administrative LogIn
[ ] Administrative actions (delete / change / add accounts)