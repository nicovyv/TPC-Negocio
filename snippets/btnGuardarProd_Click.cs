protected void btnGuardarProd_Click(object sender, EventArgs e)
{
    Page.Validate();
    if (!Page.IsValid)
    {
        return;
    }

    ProductoNegocio negocio = new ProductoNegocio();
    Producto nuevo = new Producto();

    try
    {
        if (!ValidarCamposObligatorios())
        {
            return;
        }

        int idProducto = 0;

        if (Request.QueryString["id"] != null)
            int.TryParse(Request.QueryString["id"], out idProducto);

        nuevo.Id = idProducto;
        bool esModificacion = nuevo.Id != 0;

        if (!negocio.ValidaCodigoProducto(txtCodProd.Text, idProducto))
        {
            lblErrorCodProd.Text = "El código de producto ya existe";
            lblErrorCodProd.CssClass = "text-danger";
            lblErrorCodProd.Visible = true;
            return;
        }

        nuevo.Codigo = txtCodProd.Text;
        nuevo.Nombre = txtNombreProd.Text;
        nuevo.Descripcion = txtDescProd.Text;

        nuevo.Marca = new Marca();
        nuevo.Marca.Id = int.Parse(ddlMarcaProd.SelectedValue);

        nuevo.Categoria = new Categoria();
        nuevo.Categoria.Id = int.Parse(ddlCatProd.SelectedValue);

        if (!int.TryParse(txtStockMinimoProd.Text, out int stockMinimo))
        {
            lblErrorStockMinimoProd.Text = "Debe ingresar un número válido";
            lblErrorStockMinimoProd.CssClass = "text-danger";
            lblErrorStockMinimoProd.Visible = true;
            return;
        }

        nuevo.StockMinimo = stockMinimo;

        nuevo.Proveedores = new List<Proveedor>();
        foreach (ListItem item in cblProveedoresProd.Items)
        {
            if (item.Selected)
            {
                Proveedor proveedor = new Proveedor();
                proveedor.Id = int.Parse(item.Value);
                nuevo.Proveedores.Add(proveedor);
            }
        }

        if (esModificacion)
        {
            if (!decimal.TryParse(txtPrecioVentaProd.Text, out decimal precioVenta))
            {
                lblErrorPrecioVentaProd.Text = "Debe ingresar un precio de venta válido";
                lblErrorPrecioVentaProd.CssClass = "text-danger";
                lblErrorPrecioVentaProd.Visible = true;
                return;
            }

            nuevo.PrecioVenta = precioVenta;

            if (!decimal.TryParse(txtPrecioCompraProd.Text, out decimal precioCompra))
                precioCompra = 0;

            nuevo.PrecioCompra = precioCompra;

            negocio.Modificar(nuevo);
        }
        else
        {
            nuevo.PrecioVenta = 0;
            nuevo.PrecioCompra = 0;

            negocio.Agregar(nuevo);
        }

        Response.Redirect("Productos.aspx");
    }
    catch (Exception)
    {
        throw;
    }
}
