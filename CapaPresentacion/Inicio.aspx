
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Banco.CapaPresentacion.Inicio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Inicio - Sistema de Reparaciones</title>

    <style>
        body {
            margin: 0;
            font-family: Arial, sans-serif;
            background-color: #f2f5fa;
            color: #333;
        }

        /* Menú de navegación */
        .menu {
            background-color: #183153;
            padding: 20px 40px;
            color: white;
        }

        .menu h2 {
            margin: 0 0 15px 0;
        }

        .menu a {
            color: white;
            text-decoration: none;
            margin-right: 25px;
        }

        .menu a:hover {
            text-decoration: underline;
        }

        /* Contenido principal */
        .contenedor {
            max-width: 950px;
            margin: 40px auto;
            padding: 0 20px;
        }

        h1 {
            color: #183153;
        }

        .subtitulo {
            color: #666;
            margin-bottom: 30px;
        }

        /* Tarjetas */
        .tarjetas {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 25px;
        }

        .tarjeta {
            background-color: white;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 2px 8px #00000012;
        }

        .tarjeta h2 {
            color: #183153;
        }

        .tarjeta p {
            color: #666;
            line-height: 1.6;
        }

        /* Botones */
        .boton {
            display: inline-block;
            background-color: #2563eb;
            color: white;
            padding: 12px 20px;
            border-radius: 5px;
            text-decoration: none;
            margin-top: 15px;
        }

        .boton:hover {
            background-color: #1d4ed8;
        }

        @media (max-width: 600px) {
            .tarjetas {
                grid-template-columns: 1fr;
            }
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="menu">
            <h2>Sistema de Reparaciones</h2>
            <a href="Inicio.aspx">Inicio</a>
            <a href="Usuarios.aspx">Usuarios</a>
            <a href="Equipos.aspx">Equipos</a>
        </div>

        <div class="contenedor">

            <h1>Bienvenido al Sistema de Reparaciones</h1>

            <p class="subtitulo">
                Administre los usuarios y equipos registrados
                de manera sencilla desde un solo lugar.
            </p>

            <div class="tarjetas">

                <div class="tarjeta">
                    <h2>Gestión de Usuarios</h2>

                    <p>
                        Registre nuevos usuarios, modifique su
                        información o elimine registros existentes.
                    </p>

                    <a href="Usuarios.aspx" class="boton">
                        Ir a Usuarios
                    </a>
                </div>

                <div class="tarjeta">
                    <h2>Gestión de Equipos</h2>

                    <p>
                        Registre y administre los equipos asociados
                        a los usuarios del sistema.
                    </p>

                    <a href="Equipos.aspx" class="boton">
                        Ir a Equipos
                    </a>
                </div>

            </div>

        </div>

    </form>
</body>
</html>
