// Define el espacio de nombres para los DTOs de la aplicación
namespace CouponBook.Dtos
{
    // DTO para la creación de una redención
    public class RedemptionCreateDto
    {
        // Identificador del cupón que se está redimiendo
        public int CouponId { get; set; }

        // Identificador del usuario cliente que realiza la redención
        public int CustomerUserId { get; set; }

        // Valor final con descuento aplicado
        public Decimal FinalValueWithDiscount { get; set; }

        // Identificador de la compra asociada a la redención
        public int PurchaseId { get; set; }
    }

    // DTO para listar todas las redenciones y obtener una por ID
    public class RedemptionIdDto
    {
        // Identificador único de la redención
        public int Id { get; set; }

        // Identificador del cupón que se está redimiendo
        public int CouponId { get; set; }

        // Identificador del usuario cliente que realizó la redención
        public int CustomerUserId { get; set; }

        // Valor final con descuento aplicado
        public Decimal FinalValueWithDiscount { get; set; }

        // Identificador de la compra asociada a la redención
        public int PurchaseId { get; set; }
    }

    // DTO para listar todas las redenciones por fecha
    public class RedemptiondateDto
    {
        // Identificador único de la redención
        public int Id { get; set; }

        // Identificador del cupón que se está redimiendo
        public int CouponId { get; set; }

        // Identificador del usuario cliente que realizó la redención
        public int CustomerUserId { get; set; }

        // Valor final con descuento aplicado
        public Decimal FinalValueWithDiscount { get; set; }

        // Identificador de la compra asociada a la redención
        public int PurchaseId { get; set; }
    }
}



