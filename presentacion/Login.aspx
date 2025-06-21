<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="presentacion.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Iniciar Sesión</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
        }
        .login-container {
            max-width: 400px;
            margin: auto;
            margin-top: 8vh;
            padding: 2rem;
            background-color: white;
            border-radius: 10px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
        }
        .navbar {
            border-bottom: 2px solid #0d6efd;
        }
    </style>
</head>
<body>
    <header>
        <nav class="navbar bg-dark">
            <div class="container-fluid justify-content-between">
                <span class="navbar-brand mb-0 h1 text-light">ACCEDER</span>
                <span class="navbar-brand mb-0 h1 text-light">BACK OFFICE COMERCIO</span>
            </div>
        </nav>
    </header>

    <main>
        <div class="login-container">
            <h4 class="text-center mb-4">Iniciar Sesión</h4>

            <form id="formLogin" runat="server">
                <div class="mb-3">
                    <label for="txtEmail" class="form-label">Email Usuario</label>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Ingrese su email" />
                </div>

                <div class="mb-3">
                    <label for="txtPassword" class="form-label">Password</label>
                    <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" placeholder="Ingrese su password" />
                </div>

                <div class="d-flex justify-content-between align-items-center mt-4">
                    <asp:Button runat="server"
                                OnClick="btnLogin_Click"
                                ID="btnLogin"
                                CssClass="btn btn-primary"
                                Text="Acceder" />
                    <a href="Bienvenida.aspx" class="text-secondary">Cancelar</a>
                </div>
            </form>
        </div>
    </main>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
