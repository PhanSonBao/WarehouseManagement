namespace WarehouseManagement.Domain.Enums;

public enum MovementType
{ 
    StockIn = 1, // nhập hàng từ nhà cung cấp
    SaleOut = 2, // xuất khi bán hàng
    Return = 3, // trả hàng (từ khách, hoặc trả NCC)
    Adjustment = 4, // điều chỉnh thủ công khi kiểm kho
    Transfer = 5, // chuyển kho (nếu multi-warehouse)
}