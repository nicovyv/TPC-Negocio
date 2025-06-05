<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="presentacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4Q6Gf2aSP4eDXB8Miphtr37CMZZQ5oXLH2yaXMJ2w8e2ZtHTl7GptT4jmndRuHDT" crossorigin="anonymous">
    <title></title>
</head>
<body style="margin: 0;
             padding: 0;
             box-sizing: border-box;
             ">
    <main >
          <div class="container " style="margin-top:100px;width:40%;border-style: solid;
    padding: 10px;">
              <h1 class="text-dark">Login</h1>
              <form>
                  <div class="form-group">
                      <label for="exampleInputEmail1">Usuario</label>
                      <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Ingrese Usuario">
                     
                  </div>
                  <div class="form-group">
                      <label for="exampleInputPassword1">Password</label>
                      <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
                  </div>
                  <div class="d-flex justify-content-center">
                      <button type="submit" class="btn btn-primary mt-1">Loguearse</button>
                      <a class="ml-3" href="Productos.aspx">Cancelar</a>
                  </div>
                  
              </form>
          </div>
     
   
    </main>
   
   
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/js/bootstrap.bundle.min.js" integrity="sha384-j1CDi7MgGQ12Z7Qab0qlWQ/Qqz24Gc6BM0thvEMVjHnfYGF0rmFCozFSxQBxwHKO" crossorigin="anonymous"></script>
</body>
</html>
