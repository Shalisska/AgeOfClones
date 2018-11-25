namespace Application.Management.Models
{
    public class SocialStatusManagementModel
    {
        public SocialStatusManagementModel() { }
        public SocialStatusManagementModel(
            int id,
            string name,
            int performanceCostPerDay,
            int weight,
            decimal benefit,
            int benefitTimeDays,
            decimal referralPaymentsClonero,
            int licenseCount,
            int licensePrice,
            int timeToGetLicenceHours,
            int priceForAllLicenses,
            bool haveKingdom,
            int universityLevel,
            bool havePalace,
            bool raiseFlag,
            bool haveTown,
            int townManufacturingLevel,
            int maxFields,
            int maxNumberOfLivestock)
        {
            Id = id;
            Name = name;
            PerformanceCostPerDay = performanceCostPerDay;
            Weight = weight;
            Benefit = benefit;
            BenefitTimeDays = benefitTimeDays;
            ReferralPaymentsClonero = referralPaymentsClonero;
            LicenseCount = licenseCount;
            LicensePrice = licensePrice;
            TimeToGetLicenceHours = timeToGetLicenceHours;
            PriceForAllLicenses = priceForAllLicenses;
            HaveKingdom = haveKingdom;
            UniversityLevel = universityLevel;
            HavePalace = havePalace;
            RaiseFlag = raiseFlag;
            HaveTown = haveTown;
            TownManufacturingLevel = townManufacturingLevel;
            MaxFields = maxFields;
            MaxNumberOfLivestock = maxNumberOfLivestock;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Ежедневные затраты работоспособности
        /// </summary>
        public int PerformanceCostPerDay { get; set; }

        /// <summary>
        /// Вес статуса
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Пособие начинающему клону
        /// </summary>
        public decimal Benefit { get; set; }
        /// <summary>
        /// Срок выплаты пособия
        /// </summary>
        public int BenefitTimeDays { get; set; }

        /// <summary>
        /// Реферальные выплаты в клонеро
        /// </summary>
        public decimal ReferralPaymentsClonero { get; set; }

        /// <summary>
        /// Количество лицензий
        /// </summary>
        public int LicenseCount { get; set; }
        /// <summary>
        /// Цена лицензии
        /// </summary>
        public int LicensePrice { get; set; }
        /// <summary>
        /// Время на получение лицензии
        /// </summary>
        public int TimeToGetLicenceHours { get; set; }

        /// <summary>
        /// Общая стоимость получения лицензий
        /// </summary>
        public int PriceForAllLicenses { get; set; }

        /// <summary>
        /// Наличие княжества
        /// </summary>
        public bool HaveKingdom { get; set; }
        /// <summary>
        /// Уровень развития университета
        /// </summary>
        public int UniversityLevel { get; set; }
        /// <summary>
        /// Наличие дворца
        /// </summary>
        public bool HavePalace { get; set; }
        /// <summary>
        /// Поднято ли знамя
        /// </summary>
        public bool RaiseFlag { get; set; }
        /// <summary>
        /// Наличие города
        /// </summary>
        public bool HaveTown { get; set; }
        /// <summary>
        /// Уровень развития предприятий в городе
        /// </summary>
        public int TownManufacturingLevel { get; set; }

        /// <summary>
        /// Максимальное количество доступных полей
        /// </summary>
        public int MaxFields { get; set; }
        /// <summary>
        /// Максимальное количество доступной скотины (КРС и свиньи)
        /// </summary>
        public int MaxNumberOfLivestock { get; set; }
    }
}
