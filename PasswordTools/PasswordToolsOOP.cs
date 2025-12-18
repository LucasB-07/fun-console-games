// DISCLAIMER:
// This project is intended solely for educational and developmental purposes.
// It is not designed or suitable for real-world, production, operational or security-critical use.
// The author accepts no responsibility or liability for any consequences arising from misuse.
// MUST NOT BE USED IN PRODUCTION OR SECURITY-CRITICAL SYSTEMS.

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;
using System.Security.Cryptography;

enum MenuOption
{
    PasswordGenerator = 1,
    Passwordchecker = 2,
    Exit = 3,
}

abstract class PasswordTool
{
    public abstract void Run();
}

class PasswordGeneratorTool : PasswordTool
{
    
}