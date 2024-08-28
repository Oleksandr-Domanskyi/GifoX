using System;
using System.Collections.Generic;
using Product.Service.Core.Domain.Enums;
using static Product.Service.Core.Domain.Enums.Category;

namespace Product.Service.Core.Domain
{
    public class ProductModel
    {
        private Guid _Id;
        private string _Name = default!;
        private string? _Description;
        private List<Image>? _Images;
        private MainCategory _Category = MainCategory.Others;
        private Enum? _SubCategory;
        private double _PrNetto = default!;
        private double _PrBrutto = default!;
        private bool _IsActive = true;
        private DateTime _CreatedDate;
        private DateTime _EndDate;
        private string _UserId = default!;


        public Guid Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string? Description { get => _Description; set => _Description = value; }
        public List<Image>? Images { get => _Images; set => _Images = value; }
        public MainCategory Category { get => _Category; set => _Category = value; }
        public Enum? SubCategory { get => _SubCategory; set => _SubCategory = value; }
        public double PrNetto { get => _PrNetto; set => _PrNetto = value; }
        public double PrBrutto { get => _PrBrutto; set => _PrBrutto = CalculateBrutto(_PrNetto); }
        public bool IsActive { get => _IsActive; set => _IsActive = value; }
        public DateTime CreatedDate { get => _CreatedDate; set => _CreatedDate = value; }
        public DateTime EndDate { get => _EndDate; set => _EndDate = IsActive ? default : value; }
        public string UserId { get => _UserId; set => _UserId = value; }


        public static double CalculateBrutto(double prNetto)
        {
            return prNetto * 1.2;
        }
    }
}
