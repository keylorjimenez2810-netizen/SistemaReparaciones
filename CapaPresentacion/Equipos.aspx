<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="Banco.CapaPresentacion.Equipos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Equipos</title>

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

        /* Contenedor principal */
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
            margin-bottom: 25px;
        }

        /* Formulario */
        .tarjeta {
            background-color: white;
            padding: 25px;
            border-radius: 8px;
            margin-bottom: 25px;
            box-shadow: 0 2px 8px #00000012;
        }

        .campos {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 20px;
        }

        .campo label {
            display: block;
            margin-bottom: 8px;
            font-weight: bold;
        }

        .campo input {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }

        /* Botones */
        .botones {
            margin-top: 25px;
        }

        .boton {
            padding: 12px 20px;
            border: none;
            border-radius: 5px;
            color: white;
            cursor: pointer;
            margin-right: 10px;
        }

        .agregar {
            background-color: #2563eb;
        }

        .editar {
            background-color: #d99524;
        }

        .eliminar {
            background-color: #c94545;
        }

        .boton:hover {
            opacity: 0.85;
        }

        .mensaje {
            display: block;
            margin-top: 15px;
            font-weight: bold;
        }

        /* Tabla */
        .tabla {
            width: 100%;
            border-collapse: collapse;
        }

        .tabla th {
            background-color: #183153;
            color: white;
            padding: 12px;
            text-align: left;
        }

        .tabla td {
            padding: 12px;
            border-bottom: 1px solid #ddd;
        }

        @media (max-width: 600px) {
            .campos {
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

            <h1>Gestión de Equipos</h1>
            <p class="subtitulo">
                Registro y mantenimiento de equipos.
            </p>

            <div class="tarjeta">

                <div class="campos">

                    <div class="campo">
                        <label>ID de Equipo</label>
                        <asp:TextBox ID="txtEquipoID"
                            runat="server">
                        </asp:TextBox>
                    </div>

                    <div class="campo">
                        <label>Tipo de Equipo</label>
                        <asp:TextBox ID="txtTipoEquipo"
                            runat="server">
                        </asp:TextBox>
                    </div>

                    <div class="campo">
                        <label>Modelo</label>
                        <asp:TextBox ID="txtModelo"
                            runat="server">
                        </asp:TextBox>
                    </div>

                    <div class="campo">
                        <label>ID del Usuario</label>
                        <asp:TextBox ID="txtUsuarioID"
                            runat="server">
                        </asp:TextBox>
                    </div>

                </div>

                <div class="botones">

                    <asp:Button ID="btnAgregar"
                        runat="server"
                        Text="Agregar"
                        CssClass="boton agregar"
                        OnClick="btnAgregar_Click" />

                    <asp:Button ID="btnEditar"
                        runat="server"
                        Text="Modificar"
                        CssClass="boton editar"
                        OnClick="btnEditar_Click" />

                    <asp:Button ID="btnBorrar"
                        runat="server"
                        Text="Eliminar"
                        CssClass="boton eliminar"
                        OnClick="btnBorrar_Click" />

                </div>

                <asp:Label ID="lblMensaje"
                    runat="server"
                    CssClass="mensaje">
                </asp:Label>

            </div>

            <div class="tarjeta">

                <h2>Equipos registrados</h2>

                <asp:GridView ID="GridView1"
                    runat="server"
                    CssClass="tabla"
                    AutoGenerateColumns="True"
                    GridLines="None"
                    EmptyDataText="No hay equipos registrados.">
                </asp:GridView>

            </div>

        </div>

    </form>
</body>
</html>
