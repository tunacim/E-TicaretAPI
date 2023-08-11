using System;
using ETicaretAPI.Application.ViewModel.Products;
using FluentValidation;

namespace ETicaretAPI.Application.Validators.Products
{
	public class CreateProductValidator:AbstractValidator<VM_Create_Product>
	{
		public CreateProductValidator()
		{
			RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Lütfen Ürün adını boş geçmeyin").MaximumLength(150).MinimumLength(5).WithMessage("lütfen ürün adını 5 ile 100 karakter arasında giriniz");
			RuleFor(p => p.Price).NotEmpty().NotNull().WithMessage("Lütfen Ürün fiyatını boş geçmeyin").Must(s => s >= 0).WithMessage("Fiyat bilgisi negatif olamaz");
			RuleFor(p => p.Stock).NotEmpty().NotNull().WithMessage("Lütfen Ürün stock bilgisini boş geçmeyin").Must(s => s >= 0).WithMessage("Stock bilgisi negatif olamaz");
        }
	}
}

