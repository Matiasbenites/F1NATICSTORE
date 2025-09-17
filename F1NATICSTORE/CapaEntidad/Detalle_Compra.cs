namespace CapaEntidad
{
    public class Detalle_Compra
    {
        public int IdDetalleCompra { get; set; }
        public Compra oCompra { get; set; }
        public Producto oProducto { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public string FechaRegistro { get; set; }
    }
}
