using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Assignment2
{
    class Bike
    {
        //Necessary Variables Start.
        private string _type;
        private string _make;        
        private string _model;
        private int _year;
        private double _wheelSize;
        private string _frameType;
        private int _securityCode;
        //Necessary Variables End.

        private DateTime _purchaseDate;
        //How much was the bike bought for from the supplier?
        private int _purchaseCost;
        //How much will it be sold for to customer?
        private int _saleCost;
        private bool _isHired;
        private bool _isSold;

        public static int iNumOfBikes;

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public string Make
        {
            get
            {
                return _make;
            }

            set
            {
                _make = value;
            }
        }

        public string Model
        {
            get
            {
                return _model;
            }

            set
            {
                _model = value;
            }
        }

        public int Year
        {
            get
            {
                return _year;
            }

            set
            {
                _year = value;
            }
        }

        public double WheelSize
        {
            get
            {
                return _wheelSize;
            }

            set
            {
                value = Math.Round(value, 2, MidpointRounding.AwayFromZero);
                _wheelSize = value;
            }
        }

        public string FrameType
        {
            get
            {
                return _frameType;
            }

            set
            {
                _frameType = value;
            }
        }

        public int SecurityCode
        {
            get
            {
                return _securityCode;
            }

            set
            {
                _securityCode = value;
            }
        }

        public DateTime PurchaseDate
        {
            get
            {
                return _purchaseDate.Date;
            }

            set
            {
                _purchaseDate = value;
            }
        }

        public int PurchaseCost
        {
            get
            {
                return _purchaseCost;
            }

            set
            {
                _purchaseCost = value;
            }
        }

        public int SaleCost
        {
            get
            {
                return _saleCost;
            }

            set
            {
                _saleCost = value;
            }
        }

        public bool IsHired
        {
            get
            {
                return _isHired;
            }

            set
            {
                _isHired = value;
            }
        }

        public bool IsSold
        {
            get
            {
                return _isSold;
            }

            set
            {
                _isSold = value;
            }
        }
    }

    class GenericHiredBike : Bike
    {
        private string _hiredToName;
        private double _hiredToPhoneNumber;
        private string _hiredToAddress;

        public string HiredToName
        {
            get
            {
                return _hiredToName;
            }

            set
            {
                _hiredToName = value;
            }
        }

        public double HiredToPhoneNumber
        {
            get
            {
                return _hiredToPhoneNumber;
            }

            set
            {
                _hiredToPhoneNumber = value;
            }
        }

        public string HiredToAddress
        {
            get
            {
                return _hiredToAddress;
            }

            set
            {
                _hiredToAddress = value;
            }
        }

        public GenericHiredBike() { }

        public GenericHiredBike(string type, string make, string model, int year, double wheelSize, string frameType, int securityCode, DateTime purchaseDate, int purchaseCost, int saleCost, string hiredToName, double hiredToPhoneNumber, string hiredToAddress)
        {
            Type = type;
            Make = make;
            Model = model;
            Year = year;
            WheelSize = wheelSize;
            FrameType = frameType;
            SecurityCode = securityCode;
            PurchaseDate = purchaseDate;
            PurchaseCost = purchaseCost;
            SaleCost = saleCost;
            IsHired = true;
            IsSold = false;
            HiredToName = hiredToName;
            HiredToPhoneNumber = hiredToPhoneNumber;
            HiredToAddress = hiredToAddress;
        }
    }

    class GenericSoldBike : Bike
    {
        private string _soldToName;
        private double _soldToPhoneNumber;
        private string _soldToAddress;

        public string SoldToName
        {
            get
            {
                return _soldToName;
            }

            set
            {
                _soldToName = value;
            }
        }

        public double SoldToPhoneNumber
        {
            get
            {
                return _soldToPhoneNumber;
            }

            set
            {
                _soldToPhoneNumber = value;
            }
        }

        public string SoldToAddress
        {
            get
            {
                return _soldToAddress;
            }

            set
            {
                _soldToAddress = value;
            }
        }

        public GenericSoldBike() { }

        public GenericSoldBike(string type, string make, string model, int year, double wheelSize, string frameType, int securityCode, DateTime purchaseDate, int purchaseCost, int saleCost, string soldToName, double soldToPhoneNumber, string soldToAddress)
        {
            Type = type;
            Make = make;
            Model = model;
            Year = year;
            WheelSize = wheelSize;
            FrameType = frameType;
            SecurityCode = securityCode;
            PurchaseDate = purchaseDate;
            PurchaseCost = purchaseCost;
            SaleCost = saleCost;
            IsHired = true;
            IsSold = false;
            SoldToName = soldToName;
            SoldToPhoneNumber = soldToPhoneNumber;
            SoldToAddress = soldToAddress;
        }
    }

    class BMX : Bike
    {
        //Exclusive to BMX Class.
        //Length of metal rods attached to wheels.
        private double _pegLength;

        public double PegLength
        {
            get
            {
                return _pegLength;
            }

            set
            {
                _pegLength = value;
            }
        }

        public BMX() { }

        public BMX(string make, string model, int year, double wheelSize, string frameType, int securityCode, DateTime purchaseDate, int purchaseCost, int saleCost, double pegLength)
        {
            Type = "BMX";
            Make = make;
            Model = model;
            Year = year;
            WheelSize = wheelSize;
            FrameType = frameType;
            SecurityCode = securityCode;
            PurchaseDate = purchaseDate;
            PurchaseCost = purchaseCost;
            SaleCost = saleCost;
            IsHired = false;
            IsSold = false;
            PegLength = pegLength;
            iNumOfBikes++;
        }
    }

    class HiredBMX : BMX
    {
        private string _hiredToName;
        private double _hiredToPhoneNumber;
        private string _hiredToAddress;

        public string HiredToName
        {
            get
            {
                return _hiredToName;
            }

            set
            {
                _hiredToName = value;
            }
        }

        public double HiredToPhoneNumber
        {
            get
            {
                return _hiredToPhoneNumber;
            }

            set
            {
                _hiredToPhoneNumber = value;
            }
        }

        public string HiredToAddress
        {
            get
            {
                return _hiredToAddress;
            }

            set
            {
                _hiredToAddress = value;
            }
        }

        public HiredBMX() { }

        public HiredBMX(string make, string model, int year, double wheelSize, string frameType, int securityCode, DateTime purchaseDate, int purchaseCost, int saleCost, double pegLength, string hiredToName, double hiredToPhoneNumber, string hiredToAddress)
        {
            Type = "BMX";
            Make = make;
            Model = model;
            Year = year;
            WheelSize = wheelSize;
            FrameType = frameType;
            SecurityCode = securityCode;
            PurchaseDate = purchaseDate;
            PurchaseCost = purchaseCost;
            SaleCost = saleCost;
            IsHired = true;
            IsSold = false;
            PegLength = pegLength;
            HiredToName = hiredToName;
            HiredToPhoneNumber = hiredToPhoneNumber;
            HiredToAddress = hiredToAddress;
        }
    }

    class SoldBMX : BMX
    {
        private string _soldToName;
        private double _soldToPhoneNumber;
        private string _soldToAddress;

        public string SoldToName
        {
            get
            {
                return _soldToName;
            }

            set
            {
                _soldToName = value;
            }
        }

        public double SoldToPhoneNumber
        {
            get
            {
                return _soldToPhoneNumber;
            }

            set
            {
                _soldToPhoneNumber = value;
            }
        }

        public string SoldToAddress
        {
            get
            {
                return _soldToAddress;
            }

            set
            {
                _soldToAddress = value;
            }
        }

        public SoldBMX() { }

        public SoldBMX(string make, string model, int year, double wheelSize, string frameType, int securityCode, DateTime purchaseDate, int purchaseCost, int saleCost, double pegLength, string soldToName, double soldToPhoneNumber, string soldToAddress)
        {
            Type = "BMX";
            Make = make;
            Model = model;
            Year = year;
            WheelSize = wheelSize;
            FrameType = frameType;
            SecurityCode = securityCode;
            PurchaseDate = purchaseDate;
            PurchaseCost = purchaseCost;
            SaleCost = saleCost;
            IsHired = false;
            IsSold = true;
            PegLength = pegLength;
            SoldToName = soldToName;
            SoldToPhoneNumber = soldToPhoneNumber;
            SoldToAddress = soldToAddress;
        }
    }

    class MountainBike : Bike
    {
        //Exclusive to Mountain Bike class.
        private double _tireWidth;

        public double TireWidth
        {
            get
            {
                return _tireWidth;
            }

            set
            {
                _tireWidth = value;
            }
        }

        public MountainBike() { }

        public MountainBike(string make, string model, int year, double wheelSize, string frameType, int securityCode, DateTime purchaseDate, int purchaseCost, int saleCost, double tireWidth)
        {
            Type = "Mountain Bike";
            Make = make;
            Model = model;
            Year = year;
            WheelSize = wheelSize;
            FrameType = frameType;
            SecurityCode = securityCode;
            PurchaseDate = purchaseDate;
            PurchaseCost = purchaseCost;
            SaleCost = saleCost;
            IsHired = false;
            IsSold = false;
            TireWidth = tireWidth;
            iNumOfBikes++;
        }
    }

    class HiredMountainBike : MountainBike
    {
        private string _hiredToName;
        private double _hiredToPhoneNumber;
        private string _hiredToAddress;

        public string HiredToName
        {
            get
            {
                return _hiredToName;
            }

            set
            {
                _hiredToName = value;
            }
        }

        public double HiredToPhoneNumber
        {
            get
            {
                return _hiredToPhoneNumber;
            }

            set
            {
                _hiredToPhoneNumber = value;
            }
        }

        public string HiredToAddress
        {
            get
            {
                return _hiredToAddress;
            }

            set
            {
                _hiredToAddress = value;
            }
        }

        public HiredMountainBike() { }

        public HiredMountainBike(string make, string model, int year, double wheelSize, string frameType, int securityCode, DateTime purchaseDate, int purchaseCost, int saleCost, double tireWidth, string hiredToName, double hiredToPhoneNumber, string hiredToAddress)
        {
            Type = "Mountain Bike";
            Make = make;
            Model = model;
            Year = year;
            WheelSize = wheelSize;
            FrameType = frameType;
            SecurityCode = securityCode;
            PurchaseDate = purchaseDate;
            PurchaseCost = purchaseCost;
            SaleCost = saleCost;
            IsHired = true;
            IsSold = false;
            TireWidth = tireWidth;
            HiredToName = hiredToName;
            HiredToPhoneNumber = hiredToPhoneNumber;
            HiredToAddress = hiredToAddress;
        }
    }

    class SoldMountainBike : MountainBike
    {
        private string _soldToName;
        private double _soldToPhoneNumber;
        private string _soldToAddress;

        public string SoldToName
        {
            get
            {
                return _soldToName;
            }

            set
            {
                _soldToName = value;
            }
        }

        public double SoldToPhoneNumber
        {
            get
            {
                return _soldToPhoneNumber;
            }

            set
            {
                _soldToPhoneNumber = value;
            }
        }

        public string SoldToAddress
        {
            get
            {
                return _soldToAddress;
            }

            set
            {
                _soldToAddress = value;
            }
        }

        public SoldMountainBike() { }

        public SoldMountainBike(string make, string model, int year, double wheelSize, string frameType, int securityCode, DateTime purchaseDate, int purchaseCost, int saleCost, double tireWidth, string soldToName, double soldToPhoneNumber, string soldToAddress)
        {
            Type = "Mountain Bike";
            Make = make;
            Model = model;
            Year = year;
            WheelSize = wheelSize;
            FrameType = frameType;
            SecurityCode = securityCode;
            PurchaseDate = purchaseDate;
            PurchaseCost = purchaseCost;
            SaleCost = saleCost;
            IsHired = false;
            IsSold = true;
            TireWidth = tireWidth;
            SoldToName = soldToName;
            SoldToPhoneNumber = soldToPhoneNumber;
            SoldToAddress = soldToAddress;
        }
    }

    class RoadBike : Bike
    {
        //Exclusive to Road Bike class.
        private bool _hasSolidTires;

        public bool HasSolidTires
        {
            get
            {
                return _hasSolidTires;
            }

            set
            {
                _hasSolidTires = value;
            }
        }

        public RoadBike() { }

        public RoadBike(string make, string model, int year, double wheelSize, string frameType, int securityCode, DateTime purchaseDate, int purchaseCost, int saleCost, bool hasSolidTires)
        {
            Type = "Road Bike";
            Make = make;
            Model = model;
            Year = year;
            WheelSize = wheelSize;
            FrameType = frameType;
            SecurityCode = securityCode;
            PurchaseDate = purchaseDate;
            PurchaseCost = purchaseCost;
            SaleCost = saleCost;
            IsHired = false;
            IsSold = false;
            HasSolidTires = hasSolidTires;
            iNumOfBikes++;
        }
    }

    class HiredRoadBike : RoadBike
    {
        private string _hiredToName;
        private double _hiredToPhoneNumber;
        private string _hiredToAddress;

        public string HiredToName
        {
            get
            {
                return _hiredToName;
            }

            set
            {
                _hiredToName = value;
            }
        }

        public double HiredToPhoneNumber
        {
            get
            {
                return _hiredToPhoneNumber;
            }

            set
            {
                _hiredToPhoneNumber = value;
            }
        }

        public string HiredToAddress
        {
            get
            {
                return _hiredToAddress;
            }

            set
            {
                _hiredToAddress = value;
            }
        }

        public HiredRoadBike() { }

        public HiredRoadBike(string make, string model, int year, double wheelSize, string frameType, int securityCode, DateTime purchaseDate, int purchaseCost, int saleCost, bool hasSolidTires, string hiredToName, double hiredToPhoneNumber, string hiredToAddress)
        {
            Type = "Road Bike";
            Make = make;
            Model = model;
            Year = year;
            WheelSize = wheelSize;
            FrameType = frameType;
            SecurityCode = securityCode;
            PurchaseDate = purchaseDate;
            PurchaseCost = purchaseCost;
            SaleCost = saleCost;
            IsHired = true;
            IsSold = false;
            HasSolidTires = hasSolidTires;
            HiredToName = hiredToName;
            HiredToPhoneNumber = hiredToPhoneNumber;
            HiredToAddress = hiredToAddress;
        }
    }

    class SoldRoadBike : RoadBike
    {
        private string _soldToName;
        private double _soldToPhoneNumber;
        private string _soldToAddress;

        public string SoldToName
        {
            get
            {
                return _soldToName;
            }

            set
            {
                _soldToName = value;
            }
        }

        public double SoldToPhoneNumber
        {
            get
            {
                return _soldToPhoneNumber;
            }

            set
            {
                _soldToPhoneNumber = value;
            }
        }

        public string SoldToAddress
        {
            get
            {
                return _soldToAddress;
            }

            set
            {
                _soldToAddress = value;
            }
        }

        public SoldRoadBike() { }

        public SoldRoadBike(string make, string model, int year, double wheelSize, string frameType, int securityCode, DateTime purchaseDate, int purchaseCost, int saleCost, bool hasSolidTires, string soldToName, double soldToPhoneNumber, string soldToAddress)
        {
            Type = "Road Bike";
            Make = make;
            Model = model;
            Year = year;
            WheelSize = wheelSize;
            FrameType = frameType;
            SecurityCode = securityCode;
            PurchaseDate = purchaseDate;
            PurchaseCost = purchaseCost;
            SaleCost = saleCost;
            IsHired = false;
            IsSold = true;
            HasSolidTires = hasSolidTires;
            SoldToName = soldToName;
            SoldToPhoneNumber = soldToPhoneNumber;
            SoldToAddress = soldToAddress;
        }
    }

    class ChildBike : Bike
    {
        //Exclusive to Child Bike class.
        private bool _hasTrainingWheels;

        public bool HasTrainingWheels
        {
            get
            {
                return _hasTrainingWheels;
            }

            set
            {
                _hasTrainingWheels = value;
            }
        }

        public ChildBike() { }

        public ChildBike(string make, string model, int year, double wheelSize, string frameType, int securityCode, DateTime purchaseDate, int purchaseCost, int saleCost, bool hasTrainingWheels)
        {
            Type = "Child Bike";
            Make = make;
            Model = model;
            Year = year;
            WheelSize = wheelSize;
            FrameType = frameType;
            SecurityCode = securityCode;
            PurchaseDate = purchaseDate;
            PurchaseCost = purchaseCost;
            SaleCost = saleCost;
            IsHired = false;
            IsSold = false;
            HasTrainingWheels = hasTrainingWheels;
            iNumOfBikes++;
        }
    }

    class HiredChildBike : ChildBike
    {
        private string _hiredToName;
        private double _hiredToPhoneNumber;
        private string _hiredToAddress;

        public string HiredToName
        {
            get
            {
                return _hiredToName;
            }

            set
            {
                _hiredToName = value;
            }
        }

        public double HiredToPhoneNumber
        {
            get
            {
                return _hiredToPhoneNumber;
            }

            set
            {
                _hiredToPhoneNumber = value;
            }
        }

        public string HiredToAddress
        {
            get
            {
                return _hiredToAddress;
            }

            set
            {
                _hiredToAddress = value;
            }
        }

        public HiredChildBike() { }

        public HiredChildBike(string make, string model, int year, double wheelSize, string frameType, int securityCode, DateTime purchaseDate, int purchaseCost, int saleCost, bool hasTrainingWheels, string hiredToName, double hiredToPhoneNumber, string hiredToAddress)
        {
            Type = "Child Bike";
            Make = make;
            Model = model;
            Year = year;
            WheelSize = wheelSize;
            FrameType = frameType;
            SecurityCode = securityCode;
            PurchaseDate = purchaseDate;
            PurchaseCost = purchaseCost;
            SaleCost = saleCost;
            IsHired = true;
            IsSold = false;
            HasTrainingWheels = hasTrainingWheels;
            HiredToName = hiredToName;
            HiredToPhoneNumber = hiredToPhoneNumber;
            HiredToAddress = hiredToAddress;
        }
    }

    class SoldChildBike : ChildBike
    {
        private string _soldToName;
        private double _soldToPhoneNumber;
        private string _soldToAddress;

        public string SoldToName
        {
            get
            {
                return _soldToName;
            }

            set
            {
                _soldToName = value;
            }
        }

        public double SoldToPhoneNumber
        {
            get
            {
                return _soldToPhoneNumber;
            }

            set
            {
                _soldToPhoneNumber = value;
            }
        }

        public string SoldToAddress
        {
            get
            {
                return _soldToAddress;
            }

            set
            {
                _soldToAddress = value;
            }
        }

        public SoldChildBike() { }

        public SoldChildBike(string make, string model, int year, double wheelSize, string frameType, int securityCode, DateTime purchaseDate, int purchaseCost, int saleCost, bool hasTrainingWheels, string soldToName, double soldToPhoneNumber, string soldToAddress)
        {
            Type = "Child Bike";
            Make = make;
            Model = model;
            Year = year;
            WheelSize = wheelSize;
            FrameType = frameType;
            SecurityCode = securityCode;
            PurchaseDate = purchaseDate;
            PurchaseCost = purchaseCost;
            SaleCost = saleCost;
            IsHired = false;
            IsSold = true;
            HasTrainingWheels = hasTrainingWheels;
            SoldToName = soldToName;
            SoldToPhoneNumber = soldToPhoneNumber;
            SoldToAddress = soldToAddress;
        }
    }
}