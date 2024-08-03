# WhatSocket
Para correr el archivo, debe meterse a la carpeta WhatSocket2. Adentro de esa carpeta, hay otra carpeta llamada igual (WhatSocket2). Estando adentro de esta carpeta, abrir una terminal (preferiblemente PowerShell) y ejecutar el siguiente comando:

dotnet run -port=x
(x --> su puerto deseado)

De no servir, intentar el siguiente comando:

dotnet run --project "WhatSocket2.csproj" -port=x
(x --> su puerto deseado)

A partir de eso, se abre el programa, y puede ingresar un numero de puerto al cual enviar un mensaje, su nombre de usuario y el mensaje por enviar. 
