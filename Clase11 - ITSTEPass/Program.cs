using System.Security;
using System.Text.RegularExpressions;

ConsoleKeyInfo cki;
int menuSelect = 0, passArrayCount = 0;
bool showPassword = true;
List<string> passwords = new List<string>();
int passwordsToAdd = 0;


do
{
    /*Console.WriteLine("¿Cuántas contraseñas desea validar?");
    int passwordAmount = int.Parse(Console.ReadLine());

    for (int i = 0; i < passwordAmount; i++)
    {
        Console.WriteLine($"Ingrese la contraseña {i + 1}:");
        string password = Console.ReadLine();

        if (true)//ValidarContraseña(password)))
        {
            Console.WriteLine("Contraseña válida.");
        }
        else
        {
            Console.WriteLine("Contraseña no válida.");
        }
    } */


    // Console.WriteLine("[1] - Mostrar/esconder password\n\r[2] - Ingresar password\n\r[3] - Passwords guardados\n\r[ESC] - Salir");
    Console.WriteLine("[1] - Ingresar password\n\r[2] - Passwords guardados\n\r[ESC] - Salir");
    menuSelect = Convert.ToInt32(Console.ReadLine());
    ConsoleKeyInfo key;
    switch (menuSelect)
    {
        case 1:
            Console.WriteLine($"Ingrese cantidad de passwords a ingresar");
            passwordsToAdd = Convert.ToInt32(Console.ReadLine());


            for (int i = 0; i < passwordsToAdd; i++)
            {
                bool contrasenaValidada = false;
               
                while (!contrasenaValidada)
                {
                    Console.WriteLine($"Ingrese la contraseña {i + 1}:");
                    string password = "";
                    //SecureString securePwd = new SecureString();


                    do
                    {
                        key = Console.ReadKey(true);

                        password += key.KeyChar;

                    if (((int)key.Key) >= 33 && ((int)key.Key <= 122))
                    {
                        // Append the character to the password.

                        //securePwd.AppendChar(key.KeyChar);
                        Console.Write("*");
                    }
                    } while (key.Key != ConsoleKey.Enter);
                    Console.WriteLine(password);


                    contrasenaValidada = ValidarContraseña(password);
                    if(contrasenaValidada)
                    {
                        passwords.Add(password);
                        Console.WriteLine("Contrasena agregada exitosamente");
                    } else
                    {
                        Console.WriteLine("Contrasena no valida, intente con otra contrasena");
                    }


                };



                /*if (ValidarContraseña(password))
                {
                    Console.WriteLine("Contraseña válida.");
                }
                else
                {
                    Console.WriteLine("Contraseña no válida.");
                }*/
            }

            /* if (showPassword == true)
             {
                 //esconder pass
                 Console.WriteLine("Esconder password");
                 showPassword = false;
             }
             else
             {
                 //mostrar pass
                 Console.WriteLine("Mostrar password");
                 showPassword = true;
             }*/
            break;
        case 2:

            foreach (string password in passwords)
            {
                Console.WriteLine(password);
            }
            //Console.WriteLine($"Ingresar password numero {passArrayCount + 1}");
            //passwords.Insert(passArrayCount, Console.ReadLine());
            //funcion checks
            //passArrayCount++;
            break;
        case 3:
            //passwords.ForEach(Console.WriteLine);
            Console.WriteLine("Funcion 3");

            break;
        default:
            Console.WriteLine("Opcion no valida, ingrese otro numero");
            break;
    }

    Console.WriteLine("\nPresione cualquier tecla si desea continuar");
    Console.WriteLine("Presione ESC si desea salir...");

    cki = Console.ReadKey();
    Console.Clear();
} while (cki.Key != ConsoleKey.Escape);

static bool ValidarContraseña(string contraseña)
{
    if (contraseña.Length < 12) return false;

    bool tieneMayuscula = Regex.IsMatch(contraseña, @"[A-Z]");
    bool tieneMinuscula = Regex.IsMatch(contraseña, @"[a-z]");
    bool tieneNumero = Regex.IsMatch(contraseña, @"\d");
    bool tieneCaracterEspecial = Regex.IsMatch(contraseña, @"[@+\-*/]");

    return tieneMayuscula && tieneMinuscula && tieneNumero && tieneCaracterEspecial;
}