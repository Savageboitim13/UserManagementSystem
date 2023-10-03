# User Management System
## About
A text-based user management system in progress. <br>
Connecting to a MariaDB server via a SSH port forwarding connection.

__**Possibilities**__ <br>
Username & Password connection -> If configured in SSH <br>
SSH Key File Connection -> Preferred. <br>

## Usage
__**Preinstallations | Requirements**__ <br>
`MySqlConnector v2.2.7` <br>
`System.Configuration.ConfigurationManager v7.0.0"` <br>
`Renci.SshNet v2020.0.2` <br>
`TargetFramework .NET v7.0` <br>
`LangVersion 8.0` | No top-level statements <br>

`dotnet restore` | Installs required libraries

Clone the repository | `git clone https://github.com/Savageboitim13/UserManagementSystem.git` <br>
Replace credentials for SSH sever and MariaDB server in | `/UserManagementSystem/Backend/DB/App.config` <br>

Run | `dotnet run`

## Status - Tested?
Some features may be already implemented, but not tested properly! <br>
So they aren't checked.
- [X] SSH server connection over Private / Public Key Files <br>
- [X] MariaDB server connection over SSH port forwarding <br>
- [X] Store hashed Username & Password <br>
- [ ] Registration <br>
- [ ] LogIn <br>
- [ ] Administrative LogIn <br>
- [ ] Administrative actions (delete / change / add accounts) <br>
