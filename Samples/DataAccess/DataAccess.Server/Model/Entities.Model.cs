using System;
using Peanut.Mappings;

namespace DataAccess.Models
{
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class Categories : Peanut.Mappings.DataObject
    {
        private int mCategoryID;
        public static Peanut.FieldInfo<int> categoryID = new Peanut.FieldInfo<int>("Categories", "CategoryID");
        private string mCategoryName;
        public static Peanut.FieldInfo<string> categoryName = new Peanut.FieldInfo<string>("Categories", "CategoryName");
        private string mDescription;
        public static Peanut.FieldInfo<string> description = new Peanut.FieldInfo<string>("Categories", "Description");
        private object mPicture;
        public static Peanut.FieldInfo<object> picture = new Peanut.FieldInfo<object>("Categories", "Picture");
        ///<summary>
        ///Type:int
        ///</summary>
        [ID()]
        public virtual int CategoryID
        {
            get
            {
                return mCategoryID;
                
            }
            set
            {
                mCategoryID = value;
                EntityState.FieldChange("CategoryID");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string CategoryName
        {
            get
            {
                return mCategoryName;
                
            }
            set
            {
                mCategoryName = value;
                EntityState.FieldChange("CategoryName");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Description
        {
            get
            {
                return mDescription;
                
            }
            set
            {
                mDescription = value;
                EntityState.FieldChange("Description");
                
            }
            
        }
        ///<summary>
        ///Type:object
        ///</summary>
        [Column()]
        public virtual object Picture
        {
            get
            {
                return mPicture;
                
            }
            set
            {
                mPicture = value;
                EntityState.FieldChange("Picture");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class Customers : Peanut.Mappings.DataObject
    {
        private string mCustomerID;
        public static Peanut.FieldInfo<string> customerID = new Peanut.FieldInfo<string>("Customers", "CustomerID");
        private string mCompanyName;
        public static Peanut.FieldInfo<string> companyName = new Peanut.FieldInfo<string>("Customers", "CompanyName");
        private string mContactName;
        public static Peanut.FieldInfo<string> contactName = new Peanut.FieldInfo<string>("Customers", "ContactName");
        private string mContactTitle;
        public static Peanut.FieldInfo<string> contactTitle = new Peanut.FieldInfo<string>("Customers", "ContactTitle");
        private string mAddress;
        public static Peanut.FieldInfo<string> address = new Peanut.FieldInfo<string>("Customers", "Address");
        private string mCity;
        public static Peanut.FieldInfo<string> city = new Peanut.FieldInfo<string>("Customers", "City");
        private string mRegion;
        public static Peanut.FieldInfo<string> region = new Peanut.FieldInfo<string>("Customers", "Region");
        private string mPostalCode;
        public static Peanut.FieldInfo<string> postalCode = new Peanut.FieldInfo<string>("Customers", "PostalCode");
        private string mCountry;
        public static Peanut.FieldInfo<string> country = new Peanut.FieldInfo<string>("Customers", "Country");
        private string mPhone;
        public static Peanut.FieldInfo<string> phone = new Peanut.FieldInfo<string>("Customers", "Phone");
        private string mFax;
        public static Peanut.FieldInfo<string> fax = new Peanut.FieldInfo<string>("Customers", "Fax");
        ///<summary>
        ///Type:string
        ///</summary>
        [ID()]
        public virtual string CustomerID
        {
            get
            {
                return mCustomerID;
                
            }
            set
            {
                mCustomerID = value;
                EntityState.FieldChange("CustomerID");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string CompanyName
        {
            get
            {
                return mCompanyName;
                
            }
            set
            {
                mCompanyName = value;
                EntityState.FieldChange("CompanyName");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string ContactName
        {
            get
            {
                return mContactName;
                
            }
            set
            {
                mContactName = value;
                EntityState.FieldChange("ContactName");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string ContactTitle
        {
            get
            {
                return mContactTitle;
                
            }
            set
            {
                mContactTitle = value;
                EntityState.FieldChange("ContactTitle");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Address
        {
            get
            {
                return mAddress;
                
            }
            set
            {
                mAddress = value;
                EntityState.FieldChange("Address");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string City
        {
            get
            {
                return mCity;
                
            }
            set
            {
                mCity = value;
                EntityState.FieldChange("City");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Region
        {
            get
            {
                return mRegion;
                
            }
            set
            {
                mRegion = value;
                EntityState.FieldChange("Region");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string PostalCode
        {
            get
            {
                return mPostalCode;
                
            }
            set
            {
                mPostalCode = value;
                EntityState.FieldChange("PostalCode");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Country
        {
            get
            {
                return mCountry;
                
            }
            set
            {
                mCountry = value;
                EntityState.FieldChange("Country");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Phone
        {
            get
            {
                return mPhone;
                
            }
            set
            {
                mPhone = value;
                EntityState.FieldChange("Phone");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Fax
        {
            get
            {
                return mFax;
                
            }
            set
            {
                mFax = value;
                EntityState.FieldChange("Fax");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class Employees : Peanut.Mappings.DataObject
    {
        private int mEmployeeID;
        public static Peanut.FieldInfo<int> employeeID = new Peanut.FieldInfo<int>("Employees", "EmployeeID");
        private string mLastName;
        public static Peanut.FieldInfo<string> lastName = new Peanut.FieldInfo<string>("Employees", "LastName");
        private string mFirstName;
        public static Peanut.FieldInfo<string> firstName = new Peanut.FieldInfo<string>("Employees", "FirstName");
        private string mTitle;
        public static Peanut.FieldInfo<string> title = new Peanut.FieldInfo<string>("Employees", "Title");
        private string mTitleOfCourtesy;
        public static Peanut.FieldInfo<string> titleOfCourtesy = new Peanut.FieldInfo<string>("Employees", "TitleOfCourtesy");
        private DateTime mBirthDate;
        public static Peanut.FieldInfo<DateTime> birthDate = new Peanut.FieldInfo<DateTime>("Employees", "BirthDate");
        private DateTime mHireDate;
        public static Peanut.FieldInfo<DateTime> hireDate = new Peanut.FieldInfo<DateTime>("Employees", "HireDate");
        private string mAddress;
        public static Peanut.FieldInfo<string> address = new Peanut.FieldInfo<string>("Employees", "Address");
        private string mCity;
        public static Peanut.FieldInfo<string> city = new Peanut.FieldInfo<string>("Employees", "City");
        private string mRegion;
        public static Peanut.FieldInfo<string> region = new Peanut.FieldInfo<string>("Employees", "Region");
        private string mPostalCode;
        public static Peanut.FieldInfo<string> postalCode = new Peanut.FieldInfo<string>("Employees", "PostalCode");
        private string mCountry;
        public static Peanut.FieldInfo<string> country = new Peanut.FieldInfo<string>("Employees", "Country");
        private string mHomePhone;
        public static Peanut.FieldInfo<string> homePhone = new Peanut.FieldInfo<string>("Employees", "HomePhone");
        private string mExtension;
        public static Peanut.FieldInfo<string> extension = new Peanut.FieldInfo<string>("Employees", "Extension");
        private byte[] mPhoto;
        public static Peanut.FieldInfo<byte[]> photo = new Peanut.FieldInfo<byte[]>("Employees", "Photo");
        private string mNotes;
        public static Peanut.FieldInfo<string> notes = new Peanut.FieldInfo<string>("Employees", "Notes");
        private string mPhotoPath;
        public static Peanut.FieldInfo<string> photoPath = new Peanut.FieldInfo<string>("Employees", "PhotoPath");
        ///<summary>
        ///Type:int
        ///</summary>
        [ID()]
        public virtual int EmployeeID
        {
            get
            {
                return mEmployeeID;
                
            }
            set
            {
                mEmployeeID = value;
                EntityState.FieldChange("EmployeeID");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string LastName
        {
            get
            {
                return mLastName;
                
            }
            set
            {
                mLastName = value;
                EntityState.FieldChange("LastName");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string FirstName
        {
            get
            {
                return mFirstName;
                
            }
            set
            {
                mFirstName = value;
                EntityState.FieldChange("FirstName");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Title
        {
            get
            {
                return mTitle;
                
            }
            set
            {
                mTitle = value;
                EntityState.FieldChange("Title");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string TitleOfCourtesy
        {
            get
            {
                return mTitleOfCourtesy;
                
            }
            set
            {
                mTitleOfCourtesy = value;
                EntityState.FieldChange("TitleOfCourtesy");
                
            }
            
        }
        ///<summary>
        ///Type:DateTime
        ///</summary>
        [Column()]
        public virtual DateTime BirthDate
        {
            get
            {
                return mBirthDate;
                
            }
            set
            {
                mBirthDate = value;
                EntityState.FieldChange("BirthDate");
                
            }
            
        }
        ///<summary>
        ///Type:DateTime
        ///</summary>
        [Column()]
        public virtual DateTime HireDate
        {
            get
            {
                return mHireDate;
                
            }
            set
            {
                mHireDate = value;
                EntityState.FieldChange("HireDate");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Address
        {
            get
            {
                return mAddress;
                
            }
            set
            {
                mAddress = value;
                EntityState.FieldChange("Address");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string City
        {
            get
            {
                return mCity;
                
            }
            set
            {
                mCity = value;
                EntityState.FieldChange("City");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Region
        {
            get
            {
                return mRegion;
                
            }
            set
            {
                mRegion = value;
                EntityState.FieldChange("Region");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string PostalCode
        {
            get
            {
                return mPostalCode;
                
            }
            set
            {
                mPostalCode = value;
                EntityState.FieldChange("PostalCode");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Country
        {
            get
            {
                return mCountry;
                
            }
            set
            {
                mCountry = value;
                EntityState.FieldChange("Country");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string HomePhone
        {
            get
            {
                return mHomePhone;
                
            }
            set
            {
                mHomePhone = value;
                EntityState.FieldChange("HomePhone");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Extension
        {
            get
            {
                return mExtension;
                
            }
            set
            {
                mExtension = value;
                EntityState.FieldChange("Extension");
                
            }
            
        }
        ///<summary>
        ///Type:byte[]
        ///</summary>
        [Column()]
        public virtual byte[] Photo
        {
            get
            {
                return mPhoto;
                
            }
            set
            {
                mPhoto = value;
                EntityState.FieldChange("Photo");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Notes
        {
            get
            {
                return mNotes;
                
            }
            set
            {
                mNotes = value;
                EntityState.FieldChange("Notes");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string PhotoPath
        {
            get
            {
                return mPhotoPath;
                
            }
            set
            {
                mPhotoPath = value;
                EntityState.FieldChange("PhotoPath");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class EmployeesTerritories : Peanut.Mappings.DataObject
    {
        private int mEmployeeID;
        public static Peanut.FieldInfo<int> employeeID = new Peanut.FieldInfo<int>("EmployeesTerritories", "EmployeeID");
        private int mTerritoryID;
        public static Peanut.FieldInfo<int> territoryID = new Peanut.FieldInfo<int>("EmployeesTerritories", "TerritoryID");
        ///<summary>
        ///Type:int
        ///</summary>
        [ID()]
        public virtual int EmployeeID
        {
            get
            {
                return mEmployeeID;
                
            }
            set
            {
                mEmployeeID = value;
                EntityState.FieldChange("EmployeeID");
                
            }
            
        }
        ///<summary>
        ///Type:int
        ///</summary>
        [ID()]
        public virtual int TerritoryID
        {
            get
            {
                return mTerritoryID;
                
            }
            set
            {
                mTerritoryID = value;
                EntityState.FieldChange("TerritoryID");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class InternationalOrders : Peanut.Mappings.DataObject
    {
        private int mOrderID;
        public static Peanut.FieldInfo<int> orderID = new Peanut.FieldInfo<int>("InternationalOrders", "OrderID");
        private string mCustomsDescription;
        public static Peanut.FieldInfo<string> customsDescription = new Peanut.FieldInfo<string>("InternationalOrders", "CustomsDescription");
        private object mExciseTax;
        public static Peanut.FieldInfo<object> exciseTax = new Peanut.FieldInfo<object>("InternationalOrders", "ExciseTax");
        ///<summary>
        ///Type:int
        ///</summary>
        [ID()]
        public virtual int OrderID
        {
            get
            {
                return mOrderID;
                
            }
            set
            {
                mOrderID = value;
                EntityState.FieldChange("OrderID");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string CustomsDescription
        {
            get
            {
                return mCustomsDescription;
                
            }
            set
            {
                mCustomsDescription = value;
                EntityState.FieldChange("CustomsDescription");
                
            }
            
        }
        ///<summary>
        ///Type:object
        ///</summary>
        [Column()]
        public virtual object ExciseTax
        {
            get
            {
                return mExciseTax;
                
            }
            set
            {
                mExciseTax = value;
                EntityState.FieldChange("ExciseTax");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class OrderDetails : Peanut.Mappings.DataObject
    {
        private int mOrderID;
        public static Peanut.FieldInfo<int> orderID = new Peanut.FieldInfo<int>("OrderDetails", "OrderID");
        private int mProductID;
        public static Peanut.FieldInfo<int> productID = new Peanut.FieldInfo<int>("OrderDetails", "ProductID");
        private decimal mUnitPrice;
        public static Peanut.FieldInfo<decimal> unitPrice = new Peanut.FieldInfo<decimal>("OrderDetails", "UnitPrice");
        private decimal mQuantity;
        public static Peanut.FieldInfo<decimal> quantity = new Peanut.FieldInfo<decimal>("OrderDetails", "Quantity");
        private decimal mDiscount;
        public static Peanut.FieldInfo<decimal> discount = new Peanut.FieldInfo<decimal>("OrderDetails", "Discount");
        ///<summary>
        ///Type:int
        ///</summary>
        [ID()]
        public virtual int OrderID
        {
            get
            {
                return mOrderID;
                
            }
            set
            {
                mOrderID = value;
                EntityState.FieldChange("OrderID");
                
            }
            
        }
        ///<summary>
        ///Type:int
        ///</summary>
        [ID()]
        public virtual int ProductID
        {
            get
            {
                return mProductID;
                
            }
            set
            {
                mProductID = value;
                EntityState.FieldChange("ProductID");
                
            }
            
        }
        ///<summary>
        ///Type:decimal
        ///</summary>
        [Column()]
        public virtual decimal UnitPrice
        {
            get
            {
                return mUnitPrice;
                
            }
            set
            {
                mUnitPrice = value;
                EntityState.FieldChange("UnitPrice");
                
            }
            
        }
        ///<summary>
        ///Type:decimal
        ///</summary>
        [Column()]
        public virtual decimal Quantity
        {
            get
            {
                return mQuantity;
                
            }
            set
            {
                mQuantity = value;
                EntityState.FieldChange("Quantity");
                
            }
            
        }
        ///<summary>
        ///Type:decimal
        ///</summary>
        [Column()]
        public virtual decimal Discount
        {
            get
            {
                return mDiscount;
                
            }
            set
            {
                mDiscount = value;
                EntityState.FieldChange("Discount");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class Orders : Peanut.Mappings.DataObject
    {
        private int mOrderID;
        public static Peanut.FieldInfo<int> orderID = new Peanut.FieldInfo<int>("Orders", "OrderID");
        private string mCustomerID;
        public static Peanut.FieldInfo<string> customerID = new Peanut.FieldInfo<string>("Orders", "CustomerID");
        private int mEmployeeID;
        public static Peanut.FieldInfo<int> employeeID = new Peanut.FieldInfo<int>("Orders", "EmployeeID");
        private DateTime mOrderDate;
        public static Peanut.FieldInfo<DateTime> orderDate = new Peanut.FieldInfo<DateTime>("Orders", "OrderDate");
        private DateTime mRequiredDate;
        public static Peanut.FieldInfo<DateTime> requiredDate = new Peanut.FieldInfo<DateTime>("Orders", "RequiredDate");
        private DateTime mShippedDate;
        public static Peanut.FieldInfo<DateTime> shippedDate = new Peanut.FieldInfo<DateTime>("Orders", "ShippedDate");
        private decimal mFreight;
        public static Peanut.FieldInfo<decimal> freight = new Peanut.FieldInfo<decimal>("Orders", "Freight");
        private string mShipName;
        public static Peanut.FieldInfo<string> shipName = new Peanut.FieldInfo<string>("Orders", "ShipName");
        private string mShipAddress;
        public static Peanut.FieldInfo<string> shipAddress = new Peanut.FieldInfo<string>("Orders", "ShipAddress");
        private string mShipCity;
        public static Peanut.FieldInfo<string> shipCity = new Peanut.FieldInfo<string>("Orders", "ShipCity");
        private string mShipRegion;
        public static Peanut.FieldInfo<string> shipRegion = new Peanut.FieldInfo<string>("Orders", "ShipRegion");
        private string mShipPostalCode;
        public static Peanut.FieldInfo<string> shipPostalCode = new Peanut.FieldInfo<string>("Orders", "ShipPostalCode");
        private string mShipCountry;
        public static Peanut.FieldInfo<string> shipCountry = new Peanut.FieldInfo<string>("Orders", "ShipCountry");
        ///<summary>
        ///Type:int
        ///</summary>
        [ID()]
        public virtual int OrderID
        {
            get
            {
                return mOrderID;
                
            }
            set
            {
                mOrderID = value;
                EntityState.FieldChange("OrderID");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string CustomerID
        {
            get
            {
                return mCustomerID;
                
            }
            set
            {
                mCustomerID = value;
                EntityState.FieldChange("CustomerID");
                
            }
            
        }
        ///<summary>
        ///Type:int
        ///</summary>
        [Column()]
        public virtual int EmployeeID
        {
            get
            {
                return mEmployeeID;
                
            }
            set
            {
                mEmployeeID = value;
                EntityState.FieldChange("EmployeeID");
                
            }
            
        }
        ///<summary>
        ///Type:DateTime
        ///</summary>
        [Column()]
        public virtual DateTime OrderDate
        {
            get
            {
                return mOrderDate;
                
            }
            set
            {
                mOrderDate = value;
                EntityState.FieldChange("OrderDate");
                
            }
            
        }
        ///<summary>
        ///Type:DateTime
        ///</summary>
        [Column()]
        public virtual DateTime RequiredDate
        {
            get
            {
                return mRequiredDate;
                
            }
            set
            {
                mRequiredDate = value;
                EntityState.FieldChange("RequiredDate");
                
            }
            
        }
        ///<summary>
        ///Type:DateTime
        ///</summary>
        [Column()]
        public virtual DateTime ShippedDate
        {
            get
            {
                return mShippedDate;
                
            }
            set
            {
                mShippedDate = value;
                EntityState.FieldChange("ShippedDate");
                
            }
            
        }
        ///<summary>
        ///Type:decimal
        ///</summary>
        [Column()]
        public virtual decimal Freight
        {
            get
            {
                return mFreight;
                
            }
            set
            {
                mFreight = value;
                EntityState.FieldChange("Freight");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string ShipName
        {
            get
            {
                return mShipName;
                
            }
            set
            {
                mShipName = value;
                EntityState.FieldChange("ShipName");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string ShipAddress
        {
            get
            {
                return mShipAddress;
                
            }
            set
            {
                mShipAddress = value;
                EntityState.FieldChange("ShipAddress");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string ShipCity
        {
            get
            {
                return mShipCity;
                
            }
            set
            {
                mShipCity = value;
                EntityState.FieldChange("ShipCity");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string ShipRegion
        {
            get
            {
                return mShipRegion;
                
            }
            set
            {
                mShipRegion = value;
                EntityState.FieldChange("ShipRegion");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string ShipPostalCode
        {
            get
            {
                return mShipPostalCode;
                
            }
            set
            {
                mShipPostalCode = value;
                EntityState.FieldChange("ShipPostalCode");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string ShipCountry
        {
            get
            {
                return mShipCountry;
                
            }
            set
            {
                mShipCountry = value;
                EntityState.FieldChange("ShipCountry");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class PreviousEmployees : Peanut.Mappings.DataObject
    {
        private int mEmployeeID;
        public static Peanut.FieldInfo<int> employeeID = new Peanut.FieldInfo<int>("PreviousEmployees", "EmployeeID");
        private string mLastName;
        public static Peanut.FieldInfo<string> lastName = new Peanut.FieldInfo<string>("PreviousEmployees", "LastName");
        private string mFirstName;
        public static Peanut.FieldInfo<string> firstName = new Peanut.FieldInfo<string>("PreviousEmployees", "FirstName");
        private string mTitle;
        public static Peanut.FieldInfo<string> title = new Peanut.FieldInfo<string>("PreviousEmployees", "Title");
        private string mTitleOfCourtesy;
        public static Peanut.FieldInfo<string> titleOfCourtesy = new Peanut.FieldInfo<string>("PreviousEmployees", "TitleOfCourtesy");
        private DateTime mBirthDate;
        public static Peanut.FieldInfo<DateTime> birthDate = new Peanut.FieldInfo<DateTime>("PreviousEmployees", "BirthDate");
        private DateTime mHireDate;
        public static Peanut.FieldInfo<DateTime> hireDate = new Peanut.FieldInfo<DateTime>("PreviousEmployees", "HireDate");
        private string mAddress;
        public static Peanut.FieldInfo<string> address = new Peanut.FieldInfo<string>("PreviousEmployees", "Address");
        private string mCity;
        public static Peanut.FieldInfo<string> city = new Peanut.FieldInfo<string>("PreviousEmployees", "City");
        private string mRegion;
        public static Peanut.FieldInfo<string> region = new Peanut.FieldInfo<string>("PreviousEmployees", "Region");
        private string mPostalCode;
        public static Peanut.FieldInfo<string> postalCode = new Peanut.FieldInfo<string>("PreviousEmployees", "PostalCode");
        private string mCountry;
        public static Peanut.FieldInfo<string> country = new Peanut.FieldInfo<string>("PreviousEmployees", "Country");
        private string mHomePhone;
        public static Peanut.FieldInfo<string> homePhone = new Peanut.FieldInfo<string>("PreviousEmployees", "HomePhone");
        private string mExtension;
        public static Peanut.FieldInfo<string> extension = new Peanut.FieldInfo<string>("PreviousEmployees", "Extension");
        private object mPhoto;
        public static Peanut.FieldInfo<object> photo = new Peanut.FieldInfo<object>("PreviousEmployees", "Photo");
        private string mNotes;
        public static Peanut.FieldInfo<string> notes = new Peanut.FieldInfo<string>("PreviousEmployees", "Notes");
        private string mPhotoPath;
        public static Peanut.FieldInfo<string> photoPath = new Peanut.FieldInfo<string>("PreviousEmployees", "PhotoPath");
        ///<summary>
        ///Type:int
        ///</summary>
        [ID()]
        public virtual int EmployeeID
        {
            get
            {
                return mEmployeeID;
                
            }
            set
            {
                mEmployeeID = value;
                EntityState.FieldChange("EmployeeID");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string LastName
        {
            get
            {
                return mLastName;
                
            }
            set
            {
                mLastName = value;
                EntityState.FieldChange("LastName");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string FirstName
        {
            get
            {
                return mFirstName;
                
            }
            set
            {
                mFirstName = value;
                EntityState.FieldChange("FirstName");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Title
        {
            get
            {
                return mTitle;
                
            }
            set
            {
                mTitle = value;
                EntityState.FieldChange("Title");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string TitleOfCourtesy
        {
            get
            {
                return mTitleOfCourtesy;
                
            }
            set
            {
                mTitleOfCourtesy = value;
                EntityState.FieldChange("TitleOfCourtesy");
                
            }
            
        }
        ///<summary>
        ///Type:DateTime
        ///</summary>
        [Column()]
        public virtual DateTime BirthDate
        {
            get
            {
                return mBirthDate;
                
            }
            set
            {
                mBirthDate = value;
                EntityState.FieldChange("BirthDate");
                
            }
            
        }
        ///<summary>
        ///Type:DateTime
        ///</summary>
        [Column()]
        public virtual DateTime HireDate
        {
            get
            {
                return mHireDate;
                
            }
            set
            {
                mHireDate = value;
                EntityState.FieldChange("HireDate");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Address
        {
            get
            {
                return mAddress;
                
            }
            set
            {
                mAddress = value;
                EntityState.FieldChange("Address");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string City
        {
            get
            {
                return mCity;
                
            }
            set
            {
                mCity = value;
                EntityState.FieldChange("City");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Region
        {
            get
            {
                return mRegion;
                
            }
            set
            {
                mRegion = value;
                EntityState.FieldChange("Region");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string PostalCode
        {
            get
            {
                return mPostalCode;
                
            }
            set
            {
                mPostalCode = value;
                EntityState.FieldChange("PostalCode");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Country
        {
            get
            {
                return mCountry;
                
            }
            set
            {
                mCountry = value;
                EntityState.FieldChange("Country");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string HomePhone
        {
            get
            {
                return mHomePhone;
                
            }
            set
            {
                mHomePhone = value;
                EntityState.FieldChange("HomePhone");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Extension
        {
            get
            {
                return mExtension;
                
            }
            set
            {
                mExtension = value;
                EntityState.FieldChange("Extension");
                
            }
            
        }
        ///<summary>
        ///Type:object
        ///</summary>
        [Column()]
        public virtual object Photo
        {
            get
            {
                return mPhoto;
                
            }
            set
            {
                mPhoto = value;
                EntityState.FieldChange("Photo");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Notes
        {
            get
            {
                return mNotes;
                
            }
            set
            {
                mNotes = value;
                EntityState.FieldChange("Notes");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string PhotoPath
        {
            get
            {
                return mPhotoPath;
                
            }
            set
            {
                mPhotoPath = value;
                EntityState.FieldChange("PhotoPath");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class Products : Peanut.Mappings.DataObject
    {
        private int mProductID;
        public static Peanut.FieldInfo<int> productID = new Peanut.FieldInfo<int>("Products", "ProductID");
        private string mProductName;
        public static Peanut.FieldInfo<string> productName = new Peanut.FieldInfo<string>("Products", "ProductName");
        private int mSupplierID;
        public static Peanut.FieldInfo<int> supplierID = new Peanut.FieldInfo<int>("Products", "SupplierID");
        private int mCategoryID;
        public static Peanut.FieldInfo<int> categoryID = new Peanut.FieldInfo<int>("Products", "CategoryID");
        private string mQuantityPerUnit;
        public static Peanut.FieldInfo<string> quantityPerUnit = new Peanut.FieldInfo<string>("Products", "QuantityPerUnit");
        private object mUnitPrice;
        public static Peanut.FieldInfo<object> unitPrice = new Peanut.FieldInfo<object>("Products", "UnitPrice");
        private object mUnitsInStock;
        public static Peanut.FieldInfo<object> unitsInStock = new Peanut.FieldInfo<object>("Products", "UnitsInStock");
        private object mUnitsOnOrder;
        public static Peanut.FieldInfo<object> unitsOnOrder = new Peanut.FieldInfo<object>("Products", "UnitsOnOrder");
        private object mReorderLevel;
        public static Peanut.FieldInfo<object> reorderLevel = new Peanut.FieldInfo<object>("Products", "ReorderLevel");
        private bool mDiscontinued;
        public static Peanut.FieldInfo<bool> discontinued = new Peanut.FieldInfo<bool>("Products", "Discontinued");
        private DateTime mDiscontinuedDate;
        public static Peanut.FieldInfo<DateTime> discontinuedDate = new Peanut.FieldInfo<DateTime>("Products", "DiscontinuedDate");
        ///<summary>
        ///Type:int
        ///</summary>
        [ID()]
        public virtual int ProductID
        {
            get
            {
                return mProductID;
                
            }
            set
            {
                mProductID = value;
                EntityState.FieldChange("ProductID");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string ProductName
        {
            get
            {
                return mProductName;
                
            }
            set
            {
                mProductName = value;
                EntityState.FieldChange("ProductName");
                
            }
            
        }
        ///<summary>
        ///Type:int
        ///</summary>
        [Column()]
        public virtual int SupplierID
        {
            get
            {
                return mSupplierID;
                
            }
            set
            {
                mSupplierID = value;
                EntityState.FieldChange("SupplierID");
                
            }
            
        }
        ///<summary>
        ///Type:int
        ///</summary>
        [Column()]
        public virtual int CategoryID
        {
            get
            {
                return mCategoryID;
                
            }
            set
            {
                mCategoryID = value;
                EntityState.FieldChange("CategoryID");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string QuantityPerUnit
        {
            get
            {
                return mQuantityPerUnit;
                
            }
            set
            {
                mQuantityPerUnit = value;
                EntityState.FieldChange("QuantityPerUnit");
                
            }
            
        }
        ///<summary>
        ///Type:object
        ///</summary>
        [Column()]
        public virtual object UnitPrice
        {
            get
            {
                return mUnitPrice;
                
            }
            set
            {
                mUnitPrice = value;
                EntityState.FieldChange("UnitPrice");
                
            }
            
        }
        ///<summary>
        ///Type:object
        ///</summary>
        [Column()]
        public virtual object UnitsInStock
        {
            get
            {
                return mUnitsInStock;
                
            }
            set
            {
                mUnitsInStock = value;
                EntityState.FieldChange("UnitsInStock");
                
            }
            
        }
        ///<summary>
        ///Type:object
        ///</summary>
        [Column()]
        public virtual object UnitsOnOrder
        {
            get
            {
                return mUnitsOnOrder;
                
            }
            set
            {
                mUnitsOnOrder = value;
                EntityState.FieldChange("UnitsOnOrder");
                
            }
            
        }
        ///<summary>
        ///Type:object
        ///</summary>
        [Column()]
        public virtual object ReorderLevel
        {
            get
            {
                return mReorderLevel;
                
            }
            set
            {
                mReorderLevel = value;
                EntityState.FieldChange("ReorderLevel");
                
            }
            
        }
        ///<summary>
        ///Type:bool
        ///</summary>
        [Column()]
        public virtual bool Discontinued
        {
            get
            {
                return mDiscontinued;
                
            }
            set
            {
                mDiscontinued = value;
                EntityState.FieldChange("Discontinued");
                
            }
            
        }
        ///<summary>
        ///Type:DateTime
        ///</summary>
        [Column()]
        public virtual DateTime DiscontinuedDate
        {
            get
            {
                return mDiscontinuedDate;
                
            }
            set
            {
                mDiscontinuedDate = value;
                EntityState.FieldChange("DiscontinuedDate");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class Regions : Peanut.Mappings.DataObject
    {
        private int mRegionID;
        public static Peanut.FieldInfo<int> regionID = new Peanut.FieldInfo<int>("Regions", "RegionID");
        private string mRegionDescription;
        public static Peanut.FieldInfo<string> regionDescription = new Peanut.FieldInfo<string>("Regions", "RegionDescription");
        ///<summary>
        ///Type:int
        ///</summary>
        [ID()]
        public virtual int RegionID
        {
            get
            {
                return mRegionID;
                
            }
            set
            {
                mRegionID = value;
                EntityState.FieldChange("RegionID");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string RegionDescription
        {
            get
            {
                return mRegionDescription;
                
            }
            set
            {
                mRegionDescription = value;
                EntityState.FieldChange("RegionDescription");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class Suppliers : Peanut.Mappings.DataObject
    {
        private int mSupplierID;
        public static Peanut.FieldInfo<int> supplierID = new Peanut.FieldInfo<int>("Suppliers", "SupplierID");
        private string mCompanyName;
        public static Peanut.FieldInfo<string> companyName = new Peanut.FieldInfo<string>("Suppliers", "CompanyName");
        private string mContactName;
        public static Peanut.FieldInfo<string> contactName = new Peanut.FieldInfo<string>("Suppliers", "ContactName");
        private string mContactTitle;
        public static Peanut.FieldInfo<string> contactTitle = new Peanut.FieldInfo<string>("Suppliers", "ContactTitle");
        private string mAddress;
        public static Peanut.FieldInfo<string> address = new Peanut.FieldInfo<string>("Suppliers", "Address");
        private string mCity;
        public static Peanut.FieldInfo<string> city = new Peanut.FieldInfo<string>("Suppliers", "City");
        private string mRegion;
        public static Peanut.FieldInfo<string> region = new Peanut.FieldInfo<string>("Suppliers", "Region");
        private string mPostalCode;
        public static Peanut.FieldInfo<string> postalCode = new Peanut.FieldInfo<string>("Suppliers", "PostalCode");
        private string mCountry;
        public static Peanut.FieldInfo<string> country = new Peanut.FieldInfo<string>("Suppliers", "Country");
        private string mPhone;
        public static Peanut.FieldInfo<string> phone = new Peanut.FieldInfo<string>("Suppliers", "Phone");
        private string mFax;
        public static Peanut.FieldInfo<string> fax = new Peanut.FieldInfo<string>("Suppliers", "Fax");
        private string mHomePage;
        public static Peanut.FieldInfo<string> homePage = new Peanut.FieldInfo<string>("Suppliers", "HomePage");
        ///<summary>
        ///Type:int
        ///</summary>
        [ID()]
        public virtual int SupplierID
        {
            get
            {
                return mSupplierID;
                
            }
            set
            {
                mSupplierID = value;
                EntityState.FieldChange("SupplierID");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string CompanyName
        {
            get
            {
                return mCompanyName;
                
            }
            set
            {
                mCompanyName = value;
                EntityState.FieldChange("CompanyName");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string ContactName
        {
            get
            {
                return mContactName;
                
            }
            set
            {
                mContactName = value;
                EntityState.FieldChange("ContactName");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string ContactTitle
        {
            get
            {
                return mContactTitle;
                
            }
            set
            {
                mContactTitle = value;
                EntityState.FieldChange("ContactTitle");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Address
        {
            get
            {
                return mAddress;
                
            }
            set
            {
                mAddress = value;
                EntityState.FieldChange("Address");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string City
        {
            get
            {
                return mCity;
                
            }
            set
            {
                mCity = value;
                EntityState.FieldChange("City");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Region
        {
            get
            {
                return mRegion;
                
            }
            set
            {
                mRegion = value;
                EntityState.FieldChange("Region");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string PostalCode
        {
            get
            {
                return mPostalCode;
                
            }
            set
            {
                mPostalCode = value;
                EntityState.FieldChange("PostalCode");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Country
        {
            get
            {
                return mCountry;
                
            }
            set
            {
                mCountry = value;
                EntityState.FieldChange("Country");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Phone
        {
            get
            {
                return mPhone;
                
            }
            set
            {
                mPhone = value;
                EntityState.FieldChange("Phone");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Fax
        {
            get
            {
                return mFax;
                
            }
            set
            {
                mFax = value;
                EntityState.FieldChange("Fax");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string HomePage
        {
            get
            {
                return mHomePage;
                
            }
            set
            {
                mHomePage = value;
                EntityState.FieldChange("HomePage");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class Territories : Peanut.Mappings.DataObject
    {
        private int mTerritoryID;
        public static Peanut.FieldInfo<int> territoryID = new Peanut.FieldInfo<int>("Territories", "TerritoryID");
        private string mTerritoryDescription;
        public static Peanut.FieldInfo<string> territoryDescription = new Peanut.FieldInfo<string>("Territories", "TerritoryDescription");
        private int mRegionID;
        public static Peanut.FieldInfo<int> regionID = new Peanut.FieldInfo<int>("Territories", "RegionID");
        ///<summary>
        ///Type:int
        ///</summary>
        [ID()]
        public virtual int TerritoryID
        {
            get
            {
                return mTerritoryID;
                
            }
            set
            {
                mTerritoryID = value;
                EntityState.FieldChange("TerritoryID");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string TerritoryDescription
        {
            get
            {
                return mTerritoryDescription;
                
            }
            set
            {
                mTerritoryDescription = value;
                EntityState.FieldChange("TerritoryDescription");
                
            }
            
        }
        ///<summary>
        ///Type:int
        ///</summary>
        [Column()]
        public virtual int RegionID
        {
            get
            {
                return mRegionID;
                
            }
            set
            {
                mRegionID = value;
                EntityState.FieldChange("RegionID");
                
            }
            
        }
        
    }
    
}
