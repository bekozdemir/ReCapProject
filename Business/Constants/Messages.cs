﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Car has added";
        public static string CarPriceInvalid = "Daily price of the car is invalid";
        public static string InvalidEntry = "Invalid entry!";
        public static string CarDeleted = "Car has deleted";
        public static string CarUpdated = "Car has modified";
        public static string CarListed = "Cars have listed";
        public static string Maintenance = "Under maintenance";
        public static string SuccessfullOperation = "İşlem başarılı";
        public static string ImageLimitExceeded = "Bir arabanın 5 adetten fazla resimi olamaz.";
        public static string ImageDoesntExists = "Resim bulunmamakta";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";
    }
}
