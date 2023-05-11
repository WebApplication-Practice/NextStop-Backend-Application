//// See https://aka.ms/new-console-template for more information
using Microsoft.SqlServer.Server;
using System;
using System.Net.Sockets;
using TravelApp.DAL;
using TravelApp.DAL.Models;

//Console.WriteLine("Hello, World!");

TravelAppRepository travelAppRepository = new TravelAppRepository();

travelAppRepository.Test();

Customer customer = new Customer();

customer.FirstName = "Sannidhi";
customer.LastName = "S";
customer.EmailId = "xyz@email.com";
customer.ContactNumber = 1234567890;
customer.Gender = "F";
customer.Address = "CLK";
//Note: The(year, month, day, hour, minute, second) format is followed.
customer.DateOfBirth = new DateTime(1999, 03, 07, 09, 15, 00);
customer.UserPassword = "Sanni@123";

//var res = travelAppRepository.RegisterNewCustomer(customer);

//if(res)
//{
//    Console.WriteLine("Customer added successfully!");
//} else
//{
//    Console.WriteLine("Try Again!!");
//}


