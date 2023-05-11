using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TravelApp.DAL;
using TravelApp.DAL.Models;

namespace TravelAppWebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {

        TravelAppRepository repos = new TravelAppRepository();
        public IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public string Test()
        {
            //return "App is Running";
            //getting value from appsettings.json
            var localize = _configuration.GetValue<string>("testProperties");
            return localize;
        }

        [HttpPost]
        public bool InsertCustomerDetails(Models.Customer cusObj)
        {
            var status = false;
            try
            {
                Customer obj = new Customer();
                obj.FirstName = cusObj.FirstName;
                obj.LastName = cusObj.LastName;
                obj.EmailId = cusObj.EmailId;
                obj.UserPassword = cusObj.UserPassword;
                obj.Gender = cusObj.Gender;
                obj.ContactNumber = cusObj.ContactNumber;
                obj.DateOfBirth = cusObj.DateOfBirth;
                obj.Address = cusObj.Address;
                status = repos.RegisterNewCustomer(obj);

            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        [HttpPost]
        public JsonResult ValidateUserCredentials(Models.Customer cusObj)
        {
            string[] userRole = new string[3];
            try
            {
                userRole = repos.ValidateUserCredentialsUsingLinq(cusObj.EmailId, cusObj.UserPassword);
            }
            catch (Exception)
            {
                userRole = null;
            }
            return Json(userRole);
        }

        [HttpPost]
        public JsonResult ValidateEmployeeCredentials(Models.Employee emp)
        {
            string[] userRole = new string[10];
            try
            {
                userRole = repos.ValidateEmployeeCredentials(emp.EmailId, emp.Password);
            }
            catch (Exception)
            {
                userRole = null;
            }
            return Json(userRole);
        }
       
        [HttpPut]
        public JsonResult UpdateCustomerProfileUsingAPI(Models.Customer cust)
        {
            bool status = false;
            try
            {
                status = repos.UpdateCustomerProfileUsingLinq(cust.EmailId, cust.FirstName, cust.LastName, cust.Gender, cust.ContactNumber, cust.DateOfBirth, cust.Address);
            }
            catch (Exception)
            {

                status = false;
            }
            return Json(status);
        }

        [HttpGet]
        public JsonResult GetPackages()
        {
            try
            {
                var packageList = repos.DisplayAllPackages();
                return Json(packageList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public JsonResult GetAllPackageDetailsByCategories(int packageId)
        {
            try
            {
                var packageDetailsList = repos.DisplayAllPackageDetailsByCategory(packageId);
                return Json(packageDetailsList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        public JsonResult GetPackageCategories()
        {
            try
            {
                var categories = repos.GetPackageCategories();
                return Json(categories);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[HttpPost]
        //public JsonResult BookPackage(TravelApp.DAL.Models.BookPackage book)
        //{
        //    int status = 0;
        //    TravelApp.DAL.Models.BookPackage booking = new TravelApp.DAL.Models.BookPackage();
        //    booking.EmailId = book.EmailId;
        //    booking.ContactNumber = book.ContactNumber;
        //    booking.Address = book.Address;
        //    booking.DateOfTravel = book.DateOfTravel;
        //    booking.NumberOfAdults = book.NumberOfAdults;
        //    booking.NumberOfChildren = book.NumberOfChildren;
        //    booking.Status = book.Status;
        //    booking.PackageId = book.PackageId;

        //    try
        //    {
        //        status = repos.BookPackageUsingLinq(booking);

        //    }
        //    catch (Exception)
        //    {
        //        status = -99;
        //    }
        //    return Json(status);
        //}

        [HttpGet]
        public JsonResult GetBookings(string emailId)
        {
            try
            {
                var bookingDetails = repos.DisplayBookingDetails(emailId);
                return Json(bookingDetails);
            }
            catch (Exception)
            {
                return null;
            }

        }


        [HttpGet]
        public JsonResult GetHotelDetailsList()
        {
            List<Hotel> SEVHotelObj = null;
            try
            {
                //TravelAwayDBRepository repository = new TravelAwayDAL.TravelAwayRepository();
                List<Hotel> DALHotelObj = repos.GetHotelDetailsList();

                SEVHotelObj = new List<Hotel>();
                foreach (Hotel hotel in DALHotelObj)
                {
                    Hotel obj = new Hotel()
                    {
                        HotelId = hotel.HotelId,
                        HotelName = hotel.HotelName,
                        HotelRating = hotel.HotelRating,
                        SingleRoomPrice = hotel.SingleRoomPrice,
                        DoubleRoomPrice = hotel.DoubleRoomPrice,
                        DeluxeeRoomPrice = hotel.DeluxeeRoomPrice,
                        SuiteRoomPrice = hotel.SuiteRoomPrice
                    };

                    SEVHotelObj.Add(obj);
                }

                return Json(SEVHotelObj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Json(SEVHotelObj);
            }
        }

        [HttpPost]
        public JsonResult AddAccommodationUsingAPI(Models.Accomodation SEVAccommodationObj)
        {
            int status = -1;
            try
            {
                //TravelAwayRepository repository = new TravelAwayDAL.TravelAwayRepository();
                Accomodation DALAccommodationObj = new Accomodation()
                {
                    AccomodationId = SEVAccommodationObj.AccomodationId,
                    BookingId = SEVAccommodationObj.BookingId,
                    HotelName = SEVAccommodationObj.HotelName,
                    City = SEVAccommodationObj.City,
                    HotelRating = SEVAccommodationObj.HotelRating,
                    NoOfRooms = SEVAccommodationObj.NoOfRooms,
                    RoomType = SEVAccommodationObj.RoomType,
                    Price = SEVAccommodationObj.Price,
                };

                status = repos.SelectAccomodationUsingLinq(DALAccommodationObj);

                return Json(status);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Json(status);
            }
        }

        [HttpGet]
        public JsonResult GetAllCityList()
        {
            List<string> SEVCityObj = null;
            try
            {
                // TravelAwayDAL.TravelAwayRepository repository = new TravelAwayDAL.TravelAwayRepository();
                SEVCityObj = repos.GetAllCityList();
                return Json(SEVCityObj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(SEVCityObj);
            }
        }

        [HttpGet]
        public JsonResult GetHotelsByCityNameAndHotelType(string cityName, int hotelType)
        {
            List<Hotel> SEVhotelList = null;
            try
            {

                List<Hotel> DALHotelList = repos.GetHotelsByCityNameAndHotelType(cityName, hotelType);

                SEVhotelList = new List<Hotel>();
                foreach (Hotel obj in DALHotelList)
                {
                    Hotel temp = new Hotel()
                    {
                        HotelId = obj.HotelId,
                        HotelName = obj.HotelName
                    };

                    SEVhotelList.Add(temp);
                }

                return Json(SEVhotelList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Json(SEVhotelList);
            }
        }

        [HttpGet]
        public JsonResult GetCalculatedEstimateCostUsingAPI(string hotelName, string roomType, int numberOfRooms)
        {
            decimal amount = 0;
            try
            {
                amount = repos.GetCalculatedEstimateCost(hotelName, roomType, numberOfRooms);

            }
            catch (Exception ex)
            {
                amount = -99;
                Console.WriteLine(ex);
            }
            return Json(amount);
        }

        [HttpPost]
        public JsonResult CustomerCare(Models.CustomerCare cc)
        {
            bool status = false;
            try
            {
                status = repos.CustomerCareDetails((int)cc.BookingId, cc.QueryStatus, cc.Query, cc.Assignee, cc.QueryAnswer);


            }
            catch (Exception e)
            {
                status = false;
            }
            return Json(status);
        }

        [HttpGet]
        public JsonResult GetCustomerCareBookingId(string emailId)
        {

            try
            {
                var bookings = repos.GetCustomerCareBookingId(emailId);
                return Json(bookings);

            }
            catch (Exception e)
            {
                return null;
            }

        }

        [HttpPost]
        public JsonResult addhotels(Hotel v)
        {
            int result = 0;
            Hotel v1 = new TravelApp.DAL.Models.Hotel();
            v1.HotelName = v.HotelName;
            v1.HotelRating = v.HotelRating;
            v1.SingleRoomPrice = v.SingleRoomPrice;
            v1.DoubleRoomPrice = v.DoubleRoomPrice;
            v1.DeluxeeRoomPrice = v.DeluxeeRoomPrice;
            v1.SuiteRoomPrice = v.SuiteRoomPrice;
            v1.City = v.City;
            v1.PackageId = v.PackageId;

            try
            {
                result = repos.addhotels(v1);

            }
            catch (Exception)
            {
                result = -99;
            }
            return Json(result);
        }

        [HttpGet]
        public JsonResult ViewHotelDetail()
        {
            var hoteldetails = new List<Hotel>();
            try
            {
                hoteldetails = repos.viewHotelDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                hoteldetails = null;
            }
            return Json(hoteldetails);
        }

        [HttpGet]
        public JsonResult viewvehicle()
        {
            var v = new List<Vehicle>();
            try
            {
                v = repos.viewVehicleDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                v = null;
            }
            return Json(v);
        }


        [HttpPost]
        public JsonResult rentvehicles(VehicleBooked v)
        {
            int result = 0;
            VehicleBooked v1 = new TravelApp.DAL.Models.VehicleBooked();
            v1.VehicleId = v.VehicleId;
            v1.VehicleName = v.VehicleName;
            v1.BookingDate = v.BookingDate;
            v1.PickupTime = v.PickupTime;
            v1.NoOfHours = v.NoOfHours;
            v1.NoOfKms = v.NoOfKms;
            v1.TotalCost = v.TotalCost;
            v1.VehicleStatus = v.VehicleStatus;

            try
            {
                result = repos.rentvehicle(v1);

            }
            catch (Exception)
            {
                result = -99;
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult addvehicles(Vehicle v)
        {
            int result = 0;
            Vehicle v1 = new TravelApp.DAL.Models.Vehicle();
            v1.VehicleName = v.VehicleName;
            v1.VehicleType = v.VehicleType;
            v1.RatePerHour = v.RatePerHour;
            v1.RatePerKm = v.RatePerKm;
            v1.BasePrice = v.BasePrice;

            try
            {
                result = repos.addvehicles(v1);

            }
            catch (Exception)
            {
                result = -99;
            }
            return Json(result);
        }

        [HttpPost]
        public bool InsertBookingRating(Models.Rating rating)
        {
            bool status = false;
            try
            {
                TravelApp.DAL.Models.Rating obj = new TravelApp.DAL.Models.Rating();
                obj.RatingId = rating.RatingId;
                obj.Comments = rating.Comments;
                obj.Rating1 = rating.Rating1;
                obj.BookingId = rating.BookingId;
                status = repos.AddRatings(obj);

            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        [HttpPost]
        public JsonResult PaymentStatusUsingAPI(TravelApp.DAL.Models.Payment payment)
        {
            bool status = false;
            try
            {
                TravelApp.DAL.Models.Payment pay = new TravelApp.DAL.Models.Payment();
                pay.PaymentId = payment.PaymentId;
                pay.BookingId = payment.BookingId;
                pay.TotalAmount = payment.TotalAmount;
                pay.PaymentStatus = payment.PaymentStatus;
                // pay.Gender = payment.Gender;

                status = repos.PaymentStatusUsingLinq(pay);

            }
            catch (Exception)
            {
                status = false;
            }
            return Json(status);
        }

        [HttpGet]
        public JsonResult GetTotalPaymentUsingAPI(int bookingId)
        {
            int result = 0;
            try
            {

                result = repos.TotalPaymentUsingLinq(bookingId);
                return Json(result);
            }
            catch (Exception)
            {
                result = -99;
            }
            return Json(result);
        }

        [HttpGet]
        public JsonResult GetPackageIdByCity(string city)
        {
            int status = 0;
            try
            {
                status = repos.getPackageIdByCity(city);
                return Json(status);
            }
            catch (Exception)
            {
                return Json(status);
            }
        }

    }
}
