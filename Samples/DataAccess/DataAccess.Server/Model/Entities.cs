

using System;
using Peanut.Mappings;


namespace DataAccess.Models
{

    [Table]
    interface ICategories
    {
        [ID]
        int CategoryID { get; set; }
        [Column]
        string CategoryName { get; set; }
        [Column]
        string Description { get; set; }
        [Column]
        object Picture { get; set; }
    }
    [Table]
    interface ICustomers
    {
        [ID]
        string CustomerID { get; set; }
        [Column]
        string CompanyName { get; set; }
        [Column]
        string ContactName { get; set; }
        [Column]
        string ContactTitle { get; set; }
        [Column]
        string Address { get; set; }
        [Column]
        string City { get; set; }
        [Column]
        string Region { get; set; }
        [Column]
        string PostalCode { get; set; }
        [Column]
        string Country { get; set; }
        [Column]
        string Phone { get; set; }
        [Column]
        string Fax { get; set; }
    }
    [Table]
    interface IEmployees
    {
        [ID]
        int EmployeeID { get; set; }
        [Column]
        string LastName { get; set; }
        [Column]
        string FirstName { get; set; }
        [Column]
        string Title { get; set; }
        [Column]
        string TitleOfCourtesy { get; set; }
        [Column]
        DateTime BirthDate { get; set; }
        [Column]
        DateTime HireDate { get; set; }
        [Column]
        string Address { get; set; }
        [Column]
        string City { get; set; }
        [Column]
        string Region { get; set; }
        [Column]
        string PostalCode { get; set; }
        [Column]
        string Country { get; set; }
        [Column]
        string HomePhone { get; set; }
        [Column]
        string Extension { get; set; }
        [Column]
        byte[] Photo { get; set; }
        [Column]
        string Notes { get; set; }
        [Column]
        string PhotoPath { get; set; }
    }
    [Table]
    interface IEmployeesTerritories
    {
        [ID]
        int EmployeeID { get; set; }
        [ID]
        int TerritoryID { get; set; }
    }
    [Table]
    interface IInternationalOrders
    {
        [ID]
        int OrderID { get; set; }
        [Column]
        string CustomsDescription { get; set; }
        [Column]
        object ExciseTax { get; set; }
    }
    [Table]
    interface IOrderDetails
    {
        [ID]
        int OrderID { get; set; }
        [ID]
        int ProductID { get; set; }
        [Column]
        decimal UnitPrice { get; set; }
        [Column]
        decimal Quantity { get; set; }
        [Column]
        decimal Discount { get; set; }
    }
    [Table]
    interface IOrders
    {
        [ID]
        int OrderID { get; set; }
        [Column]
        string CustomerID { get; set; }
        [Column]
        int EmployeeID { get; set; }
        [Column]
        DateTime OrderDate { get; set; }
        [Column]
        DateTime RequiredDate { get; set; }
        [Column]
        DateTime ShippedDate { get; set; }
        [Column]
        decimal Freight { get; set; }
        [Column]
        string ShipName { get; set; }
        [Column]
        string ShipAddress { get; set; }
        [Column]
        string ShipCity { get; set; }
        [Column]
        string ShipRegion { get; set; }
        [Column]
        string ShipPostalCode { get; set; }
        [Column]
        string ShipCountry { get; set; }
    }
    [Table]
    interface IPreviousEmployees
    {
        [ID]
        int EmployeeID { get; set; }
        [Column]
        string LastName { get; set; }
        [Column]
        string FirstName { get; set; }
        [Column]
        string Title { get; set; }
        [Column]
        string TitleOfCourtesy { get; set; }
        [Column]
        DateTime BirthDate { get; set; }
        [Column]
        DateTime HireDate { get; set; }
        [Column]
        string Address { get; set; }
        [Column]
        string City { get; set; }
        [Column]
        string Region { get; set; }
        [Column]
        string PostalCode { get; set; }
        [Column]
        string Country { get; set; }
        [Column]
        string HomePhone { get; set; }
        [Column]
        string Extension { get; set; }
        [Column]
        object Photo { get; set; }
        [Column]
        string Notes { get; set; }
        [Column]
        string PhotoPath { get; set; }
    }
    [Table]
    interface IProducts
    {
        [ID]
        int ProductID { get; set; }
        [Column]
        string ProductName { get; set; }
        [Column]
        int SupplierID { get; set; }
        [Column]
        int CategoryID { get; set; }
        [Column]
        string QuantityPerUnit { get; set; }
        [Column]
        object UnitPrice { get; set; }
        [Column]
        object UnitsInStock { get; set; }
        [Column]
        object UnitsOnOrder { get; set; }
        [Column]
        object ReorderLevel { get; set; }
        [Column]
        bool Discontinued { get; set; }
        [Column]
        DateTime DiscontinuedDate { get; set; }
    }
    [Table]
    interface IRegions
    {
        [ID]
        int RegionID { get; set; }
        [Column]
        string RegionDescription { get; set; }
    }
    [Table]
    interface ISuppliers
    {
        [ID]
        int SupplierID { get; set; }
        [Column]
        string CompanyName { get; set; }
        [Column]
        string ContactName { get; set; }
        [Column]
        string ContactTitle { get; set; }
        [Column]
        string Address { get; set; }
        [Column]
        string City { get; set; }
        [Column]
        string Region { get; set; }
        [Column]
        string PostalCode { get; set; }
        [Column]
        string Country { get; set; }
        [Column]
        string Phone { get; set; }
        [Column]
        string Fax { get; set; }
        [Column]
        string HomePage { get; set; }
    }
    [Table]
    interface ITerritories
    {
        [ID]
        int TerritoryID { get; set; }
        [Column]
        string TerritoryDescription { get; set; }
        [Column]
        int RegionID { get; set; }
    }
}

