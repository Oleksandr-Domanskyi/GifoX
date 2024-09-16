using System;
using System.Collections.Generic;
using Product.Core.Domain;
using Product.Service.Core.Domain;
using static Shared.Shared.Core.ProductShared.Enums.Category;

namespace Product.Product.Core.Domain
{
    public class ProductModel
    {
        private Guid _Id;
        private string _Name = default!;
        private string? _Description;
        private List<string>? _Characteristics;
        private List<Image>? _Images;
        private MainCategory _Category = MainCategory.Others;
        private SubMainCategory _SubCategory;
        private double _PrNetto = default!;
        private double _PrBrutto =default!;
        private List<ClientFeedback>? _ClientFeedbacks;
        private bool _IsActive = true;
        private DateTime _CreatedDate;
        private DateTime? _EndDate;
        private string _UserId = default!;


        public Guid Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string? Description { get => _Description; set => _Description = value; }
        public List<string>? Characteristics { get => _Characteristics; set => _Characteristics = value; }
        public List<Image>? Images { get => _Images; set => _Images = value; }
        public MainCategory Category { get => _Category; set => _Category = value; }
        public SubMainCategory SubCategory { get => _SubCategory; set => _SubCategory = value; }
        public double PrNetto { get => _PrNetto; set => _PrNetto = value; }
        public double PrBrutto { get => _PrBrutto; set => _PrBrutto = CalculateBrutto(_PrNetto); }
        public List<ClientFeedback>? ClientFeedbacks { get => _ClientFeedbacks; set => _ClientFeedbacks = value; }
        public bool IsActive { get => _IsActive; set => _IsActive = value; }
        public DateTime CreatedDate { get => _CreatedDate; set => _CreatedDate = value; }
        public DateTime? EndDate { get => _EndDate; set => _EndDate = IsActive ? null : value; }
        public string UserId { get => _UserId; set => _UserId = value; }


        public static double CalculateBrutto(double prNetto)
        {
            return prNetto * 1.2;
        }
    }
}
