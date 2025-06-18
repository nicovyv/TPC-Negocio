<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="presentacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4Q6Gf2aSP4eDXB8Miphtr37CMZZQ5oXLH2yaXMJ2w8e2ZtHTl7GptT4jmndRuHDT" crossorigin="anonymous">
    <title></title>
</head>
<body>
    <header>
        <!-- As a heading -->
        <nav class="navbar bg-dark">
            <div class="container-fluid">
                <span class="navbar-brand mb-0 h1 text-light">ACCEDER</span>
                <div>
                     <span class="navbar-brand mb-0 h1 text-light">BACK OFFICE COMERCIO</span>
                </div>
            </div>
        </nav>
    </header>
    <main >
          <div class="container border border-dark border-3 rounded" style="margin-top:100px;width:40%;padding: 10px;">
              
              <form id="formLogin" runat="server" >
                  <div class="form-group">
                      <label for="exampleInputEmail1">Usuario</label>
                      
                        <asp:TextBox runat="server"  type="text" CssClass="form-control" ID="txtEmail"  placeholder="Ingrese Usuario"/>
                  </div>
                  <div class="form-group">
                      <label for="exampleInputPassword1">Password</label>
                      <asp:TextBox runat="server" type="password" CssClass="form-control" id="txtPassword" placeholder="Ingrese su contraseña"/>
                  </div>
                  <div class="d-flex justify-content-end">
                      <asp:Button
                          runat="server" 
                          OnClick="btnLogin_Click"
                          type="submit"
                          ID="btnLogin" 
                          CssClass="btn btn-primary mt-1"
                          Text="Acceder"
                          >
                      </asp:Button>
                      <a class="ml-3" href="Bienvenida.aspx">Cancelar</a>
                  </div>
                  
              </form>
          </div>
     
   
    </main>
   
   
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/js/bootstrap.bundle.min.js" integrity="sha384-j1CDi7MgGQ12Z7Qab0qlWQ/Qqz24Gc6BM0thvEMVjHnfYGF0rmFCozFSxQBxwHKO" crossorigin="anonymous"></script>
</body>
</html>
